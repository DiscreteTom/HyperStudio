using System;
using System.Runtime.InteropServices;

public static class TransformProvider {
#if UNITY_EDITOR
  [DllImport(@"Assets/Plugins/x86_64/TransformProvider.dll")]
  public static extern void TP_Init();
  [DllImport(@"Assets/Plugins/x86_64/TransformProvider.dll")]
  public static extern void TP_Shutdown();
  [DllImport(@"Assets/Plugins/x86_64/TransformProvider.dll")]
  public static extern IntPtr TP_GetPosition();
  [DllImport(@"Assets/Plugins/x86_64/TransformProvider.dll")]
  public static extern IntPtr TP_GetRotation();
#else
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/TransformProvider.dll")]
  public static extern void TP_Init();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/TransformProvider.dll")]
  public static extern void TP_Shutdown();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/TransformProvider.dll")]
  public static extern IntPtr TP_GetPosition();
  [DllImport(@"HyperStudio_Data/Plugins/x86_64/TransformProvider.dll")]
  public static extern IntPtr TP_GetRotation();
#endif
}

