using UnityEngine;

public class MonitorControl : MonoBehaviour {
  bool dragging;

  void Start() {
    this.dragging = false;
  }

  void Update() {
    // move the object when the mouse button is held down
    if (this.dragging) {
      Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
      Vector3 objPosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);
      // keep the distance from the camera the same
      var distance = (this.transform.position - UnityEngine.Camera.main.transform.position).magnitude;
      this.transform.position = (objPosition - UnityEngine.Camera.main.transform.position).normalized * distance + UnityEngine.Camera.main.transform.position;
      // keep the object facing the camera
      this.transform.LookAt(2 * this.transform.position - UnityEngine.Camera.main.transform.position);
    }

    if (Input.GetMouseButtonUp(0)) {
      Debug.Log("Not dragging");
      this.dragging = false;
    }
  }

  void OnMouseOver() {
    if (Input.GetMouseButtonDown(0)) {
      Debug.Log("Dragging");
      this.dragging = true;
    }

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
        var direction = (this.transform.position - UnityEngine.Camera.main.transform.position).normalized;
        this.transform.position = this.transform.position + direction * scroll;
      }
    }

    // press esc to delete the object
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Destroy(this.gameObject);
    }
  }
}