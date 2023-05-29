using System;
using DT.UniStart;
using uDesktopDuplication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : Entry {
  void Awake() {
    // show on all desktops
#if !UNITY_EDITOR
    if (Config.instance.ShowOnAllDesktops) {
      var handle = Win32.GetActiveWindow();
      // -20: GWL_EXSTYLE
      // 0x80: WS_EX_TOOLWINDOW, show window on all desktops
      Win32.SetWindowLongA(handle, -20, 0x80);
    }
#endif

    // inject context
#if UNITY_EDITOR
    var eb = this.Add<IEventBus>(new DebugEventBus());
#else
    var eb = this.Add<IEventBus>(new EventBus());
#endif

    this.onUpdate.AddListener(() => {
      // Ctrl + S to save config
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) {
        // get monitor info
        var old = Config.instance.Monitors;
        Config.instance.Monitors = new MonitorConfig[Manager.monitors.Count];
        for (var i = 0; i < Manager.monitors.Count; i++) {
          Config.instance.Monitors[i] = new MonitorConfig();
          Config.instance.Monitors[i].Show = false;
        }
        GameObject.Find("MonitorManager").GetComponentsInChildren<uDesktopDuplication.Texture>().ForEach((texture) => {
          var config = Config.instance.Monitors[texture.monitorId];
          config.Show = true;
          config.Position = texture.transform.position;
          config.Rotation = texture.transform.rotation.eulerAngles;
          config.Scale = texture.transform.localScale;
          config.Bend = texture.bend;
          config.BendRadius = texture.radius;
        });

        Config.Save();
        eb.Invoke("tip", "Saved");
      }

      // Ctrl + Shift + R to reload scene
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R)) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

      // Ctrl + F to toggle LookAt
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F)) {
        Config.instance.AutoLookAtCamera = !Config.instance.AutoLookAtCamera;
        eb.Invoke("tip", "AutoLookAtCamera: " + Config.instance.AutoLookAtCamera);
      }

      // press esc to exit
      if (Input.GetKeyDown(KeyCode.Escape)) {
        this.ExitGame();
      }

      // press enter to toggle full screen
      if (Input.GetKeyDown(KeyCode.Return)) {
        Screen.fullScreen = !Screen.fullScreen;
      }
    });
  }
}