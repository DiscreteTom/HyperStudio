using DT.UniStart;
using HyperDesktopDuplication;
using UnityEngine;

public class MonitorManager : CBC {
  [SerializeField] float scale = 100;

  void Start() {
    var eb = this.Get<IEventBus>();

    this.Watch(eb, "hdd.manager.initialized", () => {
      var manager = this.Get<HDD_Manager>();

      var primaryCenter = Vector3.zero;
      for (int i = 0; i < manager.Monitors.Count; ++i) {
        var info = manager.Monitors[i];
        if (info.IsPrimary) {
          primaryCenter = new Vector3((info.Right - info.Left) / 2 + info.Left, (info.Top - info.Bottom) / 2 + info.Bottom, 0) / scale;
          break;
        }
      }

      for (var i = 0; i < manager.Monitors.Count; i++) {
        // skip hidden monitors
        // TODO: identify monitors by serial number or something, don't rely on the order
        if (Config.instance.Monitors.Length > i) {
          var config = Config.instance.Monitors[i];
          if (!config.Show) continue;
        }

        var info = manager.Monitors[i];
        var obj = manager.CreateMonitor(i);

        if (Config.instance.Monitors.Length > i) {
          // apply config
          var config = Config.instance.Monitors[i];
          obj.transform.position = config.Position;
          obj.transform.rotation = Quaternion.Euler(config.Rotation);
          obj.transform.localScale = config.Scale;
          // texture.bend = config.Bend;
          // texture.radius = config.BendRadius;
        } else {
          obj.transform.localScale = new Vector3(1 / scale, 1 / scale, 1);
          // place the monitor according to the system settings
          obj.transform.localPosition = new Vector3((info.Right - info.Left) / 2 + info.Left, (info.Top - info.Bottom) / 2 + info.Bottom, 0) / scale - primaryCenter;
          // look at camera
          // obj.transform.LookAt(2 * obj.transform.position - Camera.main.transform.position);
        }
      }
    });
  }
}