using DT.UniStart;
using uDesktopDuplication;
using UnityEngine;

public class MonitorManager : CBC {
  [SerializeField] GameObject monitorPrefab;

  void Start() {
    var getCenter = Fn((Monitor monitor) => new Vector3(monitor.left + (monitor.right - monitor.left) / 2, -(monitor.top + (monitor.bottom - monitor.top) / 2), 0));

    // center of primary monitor
    var primaryCenter = getCenter(Manager.primary);

    for (var i = 0; i < Manager.monitors.Count; i++) {
      // skip hidden monitors
      // TODO: identify monitors by serial number or something, don't rely on the order
      if (Config.instance.Monitors.Length > i) {
        var config = Config.instance.Monitors[i];
        if (!config.Show) continue;
      }

      var monitor = Manager.monitors[i];
      var obj = Instantiate(this.monitorPrefab, this.transform);
      var texture = obj.GetComponent<uDesktopDuplication.Texture>();
      texture.monitorId = i;

      if (Config.instance.Monitors.Length > i) {
        // use config
        var config = Config.instance.Monitors[i];
        obj.transform.position = config.Position;
        obj.transform.rotation = Quaternion.Euler(config.Rotation);
        obj.transform.localScale = config.Scale;
        texture.bend = config.Bend;
        texture.radius = config.BendRadius;
      } else {
        obj.transform.localScale = new Vector3(monitor.width, monitor.height, 1000) / 1000;
        // set screen position just like in the system settings
        obj.transform.position = (getCenter(monitor) - primaryCenter) / 100;
        // look at camera
        obj.transform.LookAt(2 * obj.transform.position - Camera.main.transform.position);
      }
    }
  }
}