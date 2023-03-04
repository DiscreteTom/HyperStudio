using System.Runtime.InteropServices;

public static class XRSDK {
#if UNITY_EDITOR
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern void XRSDK_Init();
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern void Reset();
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern long GetArSensor();
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern void SetPanelLuminance(int value);
#else
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern void XRSDK_Init();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern void Reset();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern long GetArSensor();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/XRSDK.dll")]
  public static extern void SetPanelLuminance(int value);
#endif
}