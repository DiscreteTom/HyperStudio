using System.IO;
using UnityEngine;

[System.Serializable]
public class Range {
  public float min;
  public float max;
}

[System.Serializable]
public class ViewZone {
  public Range pitch; // x
  public Range yaw; // y
}

[System.Serializable]
public class MonitorConfig {
  public bool Show;
  public Vector3 Position;
  public Vector3 Rotation;
  public Vector3 Scale;
  public bool EnableViewZone;
  public ViewZone ViewZone; // show monitor only when camera's rotation in this range
}

[System.Serializable]
public class Config {
  public bool ShowOnAllDesktops;
  public bool AutoLookAtCamera;
  public float TipMessageTimeout;
  public MonitorConfig[] Monitors;

  public static Config Load() {
    return JsonUtility.FromJson<Config>(File.ReadAllText("config.json"));
  }

  public static void Save() {
    File.WriteAllText("config.json", JsonUtility.ToJson(Config.instance, true));
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