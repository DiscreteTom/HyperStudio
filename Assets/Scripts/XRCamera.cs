using System;
using DT.UniStart;
using UnityEngine;

public class XRCamera : CBC {
  void Start() {
    var eb = this.Get<IEventBus>();

    // manage transform provider lifecycle
    TransformProvider.TP_Init();
    this.onDestroy.AddListener(TransformProvider.TP_Shutdown);

    var initPosition = this.transform.position;
    var positionOffset = Vector3.zero;
    var rotationOffset = Quaternion.identity;

    this.onUpdate.AddListener(() => {
      // update the camera position & rotation from transform provider
      float rx, ry, rz, rw; // range: [-1, 1]
      float x, y, z;
      int r_enabled, p_enabled;
      unsafe {
        IntPtr r_addr = TransformProvider.TP_GetRotation();
        r_enabled = *(int*)(r_addr + 0);
        rx = *(float*)(r_addr + 1);
        ry = *(float*)(r_addr + 5);
        rz = *(float*)(r_addr + 9);
        rw = *(float*)(r_addr + 13);
        IntPtr p_addr = TransformProvider.TP_GetPosition();
        p_enabled = *(int*)(p_addr + 0);
        x = *(float*)(p_addr + 1);
        y = *(float*)(p_addr + 5);
        z = *(float*)(p_addr + 9);
      }

      if (r_enabled != 0) {
        this.transform.rotation = Quaternion.Inverse(rotationOffset) * (new Quaternion(rx, ry, rz, rw));
      }
      if (p_enabled != 0) {
        this.transform.position = new Vector3(x, y, z) - positionOffset + initPosition;
      }

      // ctrl + R to reset
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R)) {
        positionOffset = this.transform.position - initPosition;
        rotationOffset = new Quaternion(rx, ry, rz, rw);
        eb.Invoke("tip", "Reset View");
      }
    });
  }
}
