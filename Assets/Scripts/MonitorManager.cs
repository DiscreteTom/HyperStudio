using uDesktopDuplication;
using UnityEngine;

public class MonitorManager : MonoBehaviour {
  [SerializeField] GameObject monitorPrefab;

  void Start() {
    // center of primary monitor
    var primaryCenter = this.GetCenter(Manager.primary);

    for (var i = 0; i < Manager.monitors.Count; i++) {
      // skip hidden monitors
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
      } else {
        obj.transform.localScale = new Vector3(monitor.width, monitor.height, 1000) / 1000;
        // set screen position just like in the system settings
        obj.transform.position = (this.GetCenter(monitor) - primaryCenter) / 100;
        // look at camera
        obj.transform.LookAt(2 * obj.transform.position - Camera.main.transform.position);
      }
    }
  }

  Vector3 GetCenter(Monitor monitor) {
    return new Vector3(monitor.left + (monitor.right - monitor.left) / 2, -(monitor.top + (monitor.bottom - monitor.top) / 2), 0);
  }
}