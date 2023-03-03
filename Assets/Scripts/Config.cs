using System.IO;
using UnityEngine;

[System.Serializable]
public class Config {
  public bool ShowOnAllDesktops;

  public static Config FromJSON() {
    return JsonUtility.FromJson<Config>(File.ReadAllText("config.json"));
  }

  // singleton
  private static Config _instance;
  public static Config instance {
    get {
      if (_instance == null) {
        _instance = FromJSON();
      }
      return _instance;
    }
  }
}