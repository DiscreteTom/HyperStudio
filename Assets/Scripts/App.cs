using DT.UniStart;
using HyperDesktopDuplication;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : Entry {
  async void Awake() {
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
    var manager = this.Add(this.GetComponentInChildren<HDD_Manager>());
#if UNITY_EDITOR
    var eb = this.Add<IEventBus>(new DebugEventBus());
#else
    var eb = this.Add<IEventBus>(new EventBus());
#endif

    await manager.Refresh();
    eb.Invoke("hdd.manager.initialized");

    this.onUpdate.AddListener(() => {
      // Ctrl + S to save config
      if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)) {
        // get monitor info
        var old = Config.instance.Monitors;
        Config.instance.Monitors = new MonitorConfig[manager.Monitors.Count];
        for (var i = 0; i < manager.Monitors.Count; i++) {
          Config.instance.Monitors[i] = new MonitorConfig();
          Config.instance.Monitors[i].Show = false;
        }
        GameObject.Find("MonitorManager").GetComponentsInChildren<HDD_Monitor>().ForEach((monitor) => {
          var config = Config.instance.Monitors[monitor.id];
          config.Show = true;
          config.Position = monitor.transform.position;
          config.Rotation = monitor.transform.rotation.eulerAngles;
          config.Scale = monitor.transform.localScale;
          // config.Bend = texture.bend;
          // config.BendRadius = texture.radius;
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