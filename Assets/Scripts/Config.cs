using System.IO;
using UnityEngine;

[System.Serializable]
public class MonitorConfig {
  public bool Show;
  public Vector3 Position;
  public Vector3 Rotation;
  public Vector3 Scale;
  // public bool Bend;
  // public float BendRadius;
}

[System.Serializable]
public class Config {
  public bool ShowOnAllDesktops;
  public bool AutoLookAtCamera;
  public float TipMessageTimeout;
  public int Port;
  public MonitorConfig[] Monitors;

  public static Config Load() {
    Config config;
    try {
      config = JsonUtility.FromJson<Config>(File.ReadAllText("config.json"));
    } catch {
      config = null;
    }
    var changed = false;
    if (config == null) {
      config = new Config();
      config.ShowOnAllDesktops = true;
      config.AutoLookAtCamera = true;
      config.TipMessageTimeout = 5;
      config.Port = 3030;
      config.Monitors = new MonitorConfig[0];
      changed = true;
    }
    if (changed) Save(config);
    return config;
  }

  public static void Save() {
    Save(Config.instance);
  }

  public static void Save(Config config) {
    File.WriteAllText("config.json", JsonUtility.ToJson(config, true));
  }

  // singleton
  private static Config _instance;
  public static Config instance {
    get {
      if (_instance == null) {
        _instance = Load();
      }
      return _instance;
    }
  }
}