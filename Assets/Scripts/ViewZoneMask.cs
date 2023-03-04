using DT.General;
using UnityEngine;

public class ViewZoneMask : CBC {
  void Start() {
    var eb = this.Get<EventBus>();
    var mr = this.GetComponent<MeshRenderer>();

    // disable at start
    mr.enabled = false;

    eb.AddListener("viewZoneMesh.enable", () => mr.enabled = true);
    eb.AddListener("viewZoneMesh.disable", () => mr.enabled = false);
    eb.AddListener("viewZoneMesh.update", (Range pitch, Range yaw) => {
      // calculate the center of the panel and move the object there
      var distance = 1;
      var midPitch = (pitch.max + pitch.min) / 2;
      var midYaw = (yaw.max + yaw.min) / 2;
      var y = distance * Mathf.Sin(midYaw);
      var x = distance * Mathf.Cos(midYaw) * Mathf.Cos(midPitch);
      var z = distance * Mathf.Cos(midYaw) * Mathf.Sin(midPitch);
      this.transform.position = new Vector3(x, y, z) + Camera.main.transform.position;
      // make object face to the camera
      this.transform.LookAt(2 * this.transform.position - Camera.main.transform.position);
      // scale according to pitch and yaw
      this.transform.localScale = new Vector3(Mathf.Tan((pitch.max - pitch.min) / 2), Mathf.Tan((yaw.max - yaw.min) / 2), 0.01f) * distance;
    });
  }
}