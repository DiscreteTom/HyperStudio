using UnityEngine;

public class MonitorControl : MonoBehaviour {
  bool dragging;
  bool recordingViewZone;
  uDesktopDuplication.Texture texture;
  MeshRenderer mr;
  public bool enableViewZone;
  public Vector3 viewZoneMin;
  public Vector3 viewZoneMax;

  void Start() {
    this.dragging = false;
    this.recordingViewZone = false;
    this.texture = this.GetComponent<uDesktopDuplication.Texture>();
    this.mr = this.GetComponent<MeshRenderer>();

    if (Config.instance.Monitors.Length > this.texture.monitorId) {
      this.enableViewZone = Config.instance.Monitors[this.texture.monitorId].EnableViewZone;
      this.viewZoneMax = Config.instance.Monitors[this.texture.monitorId].ViewZone.Max;
      this.viewZoneMin = Config.instance.Monitors[this.texture.monitorId].ViewZone.Min;
    } else {
      this.enableViewZone = false;
    }
  }

  void Update() {
    // move the object when the mouse button is held down
    if (this.dragging) {
      Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
      Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
      // keep the distance from the camera the same
      var distance = (this.transform.position - Camera.main.transform.position).magnitude;
      this.transform.position = (objPosition - Camera.main.transform.position).normalized * distance + Camera.main.transform.position;
      // keep the object facing the camera
      if (Config.instance.AutoLookAtCamera) {
        this.transform.LookAt(2 * this.transform.position - Camera.main.transform.position);
      }
    }

    // drag
    if (Input.GetMouseButtonUp(0)) {
      this.dragging = false;
    }

    // view zone
    if (this.recordingViewZone) {
      // recording view zone
      var angle = Camera.main.transform.rotation.eulerAngles;
      if (this.viewZoneMin.x > angle.x) this.viewZoneMin.x = angle.x;
      if (this.viewZoneMin.y > angle.y) this.viewZoneMin.y = angle.y;
      if (this.viewZoneMin.z > angle.z) this.viewZoneMin.z = angle.z;
      if (this.viewZoneMax.x < angle.x) this.viewZoneMax.x = angle.x;
      if (this.viewZoneMax.y < angle.y) this.viewZoneMax.y = angle.y;
      if (this.viewZoneMax.z < angle.z) this.viewZoneMax.z = angle.z;
      if (Input.GetKeyUp(KeyCode.V)) this.recordingViewZone = false;
    } else {
      // handle view zone
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A)) {
        // press Ctrl + A to show all monitor
        if (!this.mr.enabled) this.mr.enabled = true;
      } else {
        // check rotation
        if (this.enableViewZone) {
          var rotation = Camera.main.transform.rotation.eulerAngles;
          if (rotation.x > this.viewZoneMin.x && rotation.x < this.viewZoneMax.x && rotation.y > this.viewZoneMin.y && rotation.y < this.viewZoneMax.y && rotation.z > this.viewZoneMin.z && rotation.z < this.viewZoneMax.z) {
            // show
            if (!this.mr.enabled) this.mr.enabled = true;
          } else {
            // hide
            if (this.mr.enabled) this.mr.enabled = false;
          }
        }
      }
    }
  }

  void OnMouseOver() {
    // blink
    this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time * 2, 1));

    // drag
    if (Input.GetMouseButtonDown(0)) {
      this.dragging = true;
    }

    // scale & push & pull
    float scroll = Input.GetAxis("Mouse ScrollWheel");
    if (!Input.GetKey(KeyCode.LeftControl)) {
      // scale the object when the mouse wheel is scrolled
      if (scroll != 0) {
        Vector3 scale = this.transform.localScale;
        scale.x *= 1 + scroll;
        scale.y *= 1 + scroll;
        scale.z *= 1 + scroll;
        this.transform.localScale = scale;
      }
    } else {
      // push away or pull towards the camera when the mouse wheel is scrolled and ctrl is held down
      if (scroll != 0) {
        var direction = (this.transform.position - Camera.main.transform.position).normalized;
        this.transform.position = this.transform.position + direction * scroll;
      }
    }

    // press esc to delete the object
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Destroy(this.gameObject);
    }

    // ctrl + '+'/'-' to bend the monitor, ctrl + '0' to toggle bend
    if (Input.GetKey(KeyCode.LeftControl)) {
      if (Input.GetKey(KeyCode.Equals)) {
        this.texture.radius += 8 * Time.deltaTime;
      }
      if (Input.GetKey(KeyCode.Minus)) {
        this.texture.radius -= 8 * Time.deltaTime;
      }
      if (Input.GetKeyDown(KeyCode.Alpha0)) {
        this.texture.bend = !this.texture.bend;
      }
    }

    // ctrl + j/k/l/u/i/o to rotate monitor
    if (Input.GetKey(KeyCode.LeftControl)) {
      if (Input.GetKey(KeyCode.J)) {
        this.transform.Rotate(Vector3.up, 90 * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.L)) {
        this.transform.Rotate(Vector3.up, -90 * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.I)) {
        this.transform.Rotate(Vector3.right, 90 * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.K)) {
        this.transform.Rotate(Vector3.right, -90 * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.U)) {
        this.transform.Rotate(Vector3.forward, 90 * Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.O)) {
        this.transform.Rotate(Vector3.forward, -90 * Time.deltaTime);
      }
    }

    // press Ctrl + V to record view zone
    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V)) {
      this.recordingViewZone = true;
      this.enableViewZone = true;
      this.viewZoneMin = Camera.main.transform.rotation.eulerAngles;
      this.viewZoneMax = Camera.main.transform.rotation.eulerAngles;
    }

    // ctrl + shift + V to disable view zone
    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.V)) {
      this.enableViewZone = false;
    }
  }

  void OnMouseExit() {
    // cancel blink
    this.GetComponent<Renderer>().material.color = Color.white;
  }
}