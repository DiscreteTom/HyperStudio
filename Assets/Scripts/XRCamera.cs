using DT.General;
using UnityEngine;

public class XRCamera : CBC {
  void Start() {
    XRSDK.XRSDK_Init();
    XRSDK.Reset();
    XRSDK.SetPanelLuminance(Config.instance.PanelLuminance);

    var eb = this.Get<EventBus>();

    this.OnUpdate.AddListener(() => {
      // update the camera position by reading the sensor data
      float x, y, z, w; // range: [-1, 1]
      unsafe {
        long addr = XRSDK.GetArSensor();
        x = *(float*)(addr + 44);
        y = *(float*)(addr + 48);
        z = *(float*)(addr + 52);
        w = *(float*)(addr + 56);
      }
      this.transform.rotation = new Quaternion(x, y, z, w);

      // ctrl + R to reset
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R)) {
        XRSDK.Reset();
        eb.Invoke("tip", "Reset View");
      }
    });
  }
}
