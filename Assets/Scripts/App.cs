using System;
using uDesktopDuplication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour {
  void Start() {
#if !UNITY_EDITOR
    if (Config.instance.ShowOnAllDesktops) {
      var handle = Win32.GetActiveWindow();
      // -20: GWL_EXSTYLE
      // 0x80: WS_EX_TOOLWINDOW, show window on all desktops
      Win32.SetWindowLongA(handle, -20, 0x80);
    }
#endif
  }

  void Update() {
    // Ctrl + S to save config
    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) {
      // get monitor info
      var old = Config.instance.Monitors;
      Config.instance.Monitors = new MonitorConfig[Manager.monitors.Count];
      for (var i = 0; i < Manager.monitors.Count; i++) {
        Config.instance.Monitors[i] = new MonitorConfig();
        Config.instance.Monitors[i].Show = false;
      }
      Array.ForEach(GameObject.Find("MonitorManager").GetComponentsInChildren<uDesktopDuplication.Texture>(), ((texture) => {
        var config = Config.instance.Monitors[texture.monitorId];
        config.Show = true;
        config.Position = texture.transform.position;
        config.Rotation = texture.transform.rotation.eulerAngles;
        config.Scale = texture.transform.localScale;
        var control = texture.GetComponent<MonitorControl>();
        config.EnableViewZone = control.enableViewZone;
        config.ViewZone.Min = control.viewZoneMin;
        config.ViewZone.Max = control.viewZoneMax;
      }));

      Config.Save();
    }

    // Ctrl + Shift + R to reload scene
    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R)) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Ctrl + F to toggle LookAt
    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F)) {
      Config.instance.AutoLookAtCamera = !Config.instance.AutoLookAtCamera;
    }
  }
}