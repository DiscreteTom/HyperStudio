using DT.General;
using UnityEngine;

public class MonitorControl : CBC {
  bool dragging;
  bool recordingViewZone;
  float recordingStartTime;
  uDesktopDuplication.Texture texture;
  MeshRenderer mr;
  EventBus eb;
  public bool enableViewZone;
  public Range pitch;
  public Range yaw;

  void Start() {
    this.dragging = false;
    this.recordingViewZone = false;
    this.pitch = new Range();
    this.yaw = new Range();
    this.texture = this.GetComponent<uDesktopDuplication.Texture>();
    this.mr = this.GetComponent<MeshRenderer>();
    this.eb = this.Get<EventBus>();

    if (Config.instance.Monitors.Length > this.texture.monitorId) {
      this.enableViewZone = Config.instance.Monitors[this.texture.monitorId].EnableViewZone;
      this.pitch = Config.instance.Monitors[this.texture.monitorId].ViewZone.pitch;
      this.yaw = Config.instance.Monitors[this.texture.monitorId].ViewZone.yaw;
    } else {
      this.enableViewZone = false;
    }

    this.OnUpdate.AddListener(() => {
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
        var (newPitch, newYaw) = this.GetCameraAngle();
        if (newPitch < this.pitch.min) this.pitch.min = newPitch;
        if (newPitch > this.pitch.max) this.pitch.max = newPitch;
        if (newYaw < this.yaw.min) this.yaw.min = newYaw;
        if (newYaw > this.yaw.max) this.yaw.max = newYaw;
        eb.Invoke("viewZoneMesh.update", this.pitch, this.yaw);
        if (Input.GetKeyUp(KeyCode.V)) {
          this.recordingViewZone = false;
          eb.Invoke("viewZoneMesh.disable");
          if (Time.time - this.recordingStartTime > 0.3) {
            this.eb.Invoke("tip", "Stop Recording View Zone");
          } else {
            // prevent mistakenly recording
            this.enableViewZone = false;
            this.eb.Invoke("tip", "Release Ctrl+V Too Fast");
          }
        }
      } else {
        // handle view zone
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A)) {
          // press Ctrl + A to show all monitor
          if (!this.mr.enabled) this.mr.enabled = true;
        } else {
          // check rotation
          if (this.enableViewZone) {
            var (newPitch, newYaw) = this.GetCameraAngle();
            if (newPitch > this.pitch.min && newPitch < this.pitch.max && newYaw > this.yaw.min && newYaw < this.yaw.max) {
              // show
              if (!this.mr.enabled) this.mr.enabled = true;
            } else {
              // hide
              if (this.mr.enabled) this.mr.enabled = false;
            }
          }
        }
      }
    });
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

    // press backspace to delete the object
    if (Input.GetKeyDown(KeyCode.Backspace)) {
      Destroy(this.gameObject);
      this.eb.Invoke("tip", "Remove Screen: " + this.texture.monitorId);
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
      var (newPitch, newYaw) = this.GetCameraAngle();
      this.pitch.min = newPitch;
      this.pitch.max = newPitch;
      this.yaw.min = newYaw;
      this.yaw.max = newYaw;
      eb.Invoke("tip", "Start Record View Zone");
      this.recordingStartTime = Time.time;
      eb.Invoke("viewZoneMesh.enable");
    }

    // ctrl + shift + V to disable view zone
    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.V)) {
      if (this.enableViewZone)
        this.eb.Invoke("tip", "Disable View Zone: " + this.texture.monitorId);

      this.enableViewZone = false;
    }
  }

  void OnMouseExit() {
    // cancel blink
    this.GetComponent<Renderer>().material.color = Color.white;
  }

  (float x, float y) GetCameraAngle() {
    var yAngle = Mathf.Asin(Camera.main.transform.forward.y / Camera.main.transform.forward.magnitude);
    var xAngle = Mathf.Acos(Camera.main.transform.forward.x / (Camera.main.transform.forward.magnitude * Mathf.Cos(yAngle))) * Mathf.Sign(Camera.main.transform.forward.z);
    return (xAngle, yAngle);
  }
}