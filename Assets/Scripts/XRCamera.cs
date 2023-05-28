using DT.UniStart;
using UnityEngine;
using UnityRawInput;

public class XRCamera : CBC {
  void Start() {
    XRSDK.XRSDK_Init();
    XRSDK.Reset();
    XRSDK.SetPanelLuminance(Config.instance.PanelLuminance);

    var eb = this.Get<EventBus>();
    RawInput.WorkInBackground = true;
    RawInput.Start();
    if (Config.instance.ResetViewHotKey.Enabled) {
      RawInput.OnKeyDown += (key) => {
        if ((uint)key == Config.instance.ResetViewHotKey.Key) {
          if ((Config.instance.ResetViewHotKey.Modifier & 0x01) != 0 && !RawInput.IsKeyDown(RawKey.LeftButtonAlt)) return;
          if ((Config.instance.ResetViewHotKey.Modifier & 0x02) != 0 && !RawInput.IsKeyDown(RawKey.LeftControl)) return;
          if ((Config.instance.ResetViewHotKey.Modifier & 0x04) != 0 && !RawInput.IsKeyDown(RawKey.LeftShift)) return;
          if ((Config.instance.ResetViewHotKey.Modifier & 0x08) != 0 && !RawInput.IsKeyDown(RawKey.LeftWindows)) return;
          XRSDK.Reset();
          eb.Invoke("tip", "Reset View");
        }
      };
    }

    this.onUpdate.AddListener(() => {
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

  void OnApplicationQuit() {
    RawInput.Stop();
  }
}
