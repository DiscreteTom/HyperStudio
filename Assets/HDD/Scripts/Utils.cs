namespace HyperDesktopDuplication {
  public static class Logger {
    static string prefix = "HyperDesktopDuplication: ";

    public static void Log(object message) {
      UnityEngine.Debug.Log(prefix + message);
    }
  }
}