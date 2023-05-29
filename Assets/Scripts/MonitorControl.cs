using DT.UniStart;
using UnityEngine;

public class MonitorControl : CBC {
  void Start() {
    var dragging = false;
    var pitch = new Range();
    var yaw = new Range();
    var texture = this.GetComponent<uDesktopDuplication.Texture>();
    var mr = this.GetComponent<MeshRenderer>();
    var eb = this.Get<IEventBus>();

    var getCameraAngle = Fn(() => {
      var yAngle = Mathf.Asin(Camera.main.transform.forward.y / Camera.main.transform.forward.magnitude);
      var xAngle = Mathf.Acos(Camera.main.transform.forward.x / (Camera.main.transform.forward.magnitude * Mathf.Cos(yAngle))) * Mathf.Sign(Camera.main.transform.forward.z);
      return (xAngle, yAngle);
    });

    this.onUpdate.AddListener(() => {
      // move the object when the mouse button is held down
      if (dragging) {
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
        dragging = false;
      }
    });

    this.onMouseOver.AddListener(() => {
      // blink
      this.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time * 2, 1));

      // drag
      if (Input.GetMouseButtonDown(0)) {
        dragging = true;
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

      // press backspace to delete the object
      if (Input.GetKeyDown(KeyCode.Backspace)) {
        Destroy(this.gameObject);
        eb.Invoke("tip", "Remove Screen: " + texture.monitorId);
      }

      // ctrl + '+'/'-' to bend the monitor, ctrl + '0' to toggle bend
      if (Input.GetKey(KeyCode.LeftControl)) {
        if (Input.GetKey(KeyCode.Equals)) {
          texture.radius += 8 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Minus)) {
          texture.radius -= 8 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
          texture.bend = !texture.bend;
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
    });

    this.onMouseExit.AddListener(() => {
      // cancel blink
      this.GetComponent<Renderer>().material.color = Color.white;
    });
  }
}