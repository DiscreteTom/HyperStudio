using UnityEngine;

public class MonitorManager : MonoBehaviour {
  [SerializeField] GameObject monitorPrefab;

  void Start() {
    for (var i = 0; i < uDesktopDuplication.Manager.monitors.Count; i++) {
      var monitor = uDesktopDuplication.Manager.monitors[i];
      var obj = Instantiate(this.monitorPrefab, this.transform);
      var texture = obj.GetComponent<uDesktopDuplication.Texture>();
      texture.monitorId = i;
      obj.transform.position = new Vector3(i * 2, 0, 0);
    }
  }
}