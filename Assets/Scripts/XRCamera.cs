using System.Runtime.InteropServices;
using UnityEngine;

public class XRCamera : MonoBehaviour {
#if UNITY_EDITOR
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern void XRSDK_Init();
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern void Reset();
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern long GetArSensor();
#else
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern void XRSDK_Init();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern void Reset();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern long GetArSensor();
#endif

  void Start() {
    XRSDK_Init();
    Reset();
  }

  void Update() {
    float x, y, z, w; // range: [-1, 1]
    unsafe {
      long addr = GetArSensor();
      x = *(float*)(addr + 44);
      y = *(float*)(addr + 48);
      z = *(float*)(addr + 52);
      w = *(float*)(addr + 56);
    }

    this.transform.rotation = new Quaternion(x, y, z, w);
  }
}
