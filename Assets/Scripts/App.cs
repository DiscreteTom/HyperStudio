using UnityEngine;

public class App : MonoBehaviour {
#if !UNITY_EDITOR
  void Start() {
    var handle = Win32.GetActiveWindow();
    // -20: GWL_EXSTYLE
    // 0x80: WS_EX_TRANSPARENT
    Win32.SetWindowLongA(handle, -20, 0x80);
  }
#endif
}