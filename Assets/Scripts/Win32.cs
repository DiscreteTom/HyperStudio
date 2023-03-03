using System.Runtime.InteropServices;

public static class Win32 {
  [DllImport("user32.dll")]
  public static extern int GetActiveWindow();
  [DllImport("user32.dll")]
  public static extern int SetWindowLongA(int hwnd, int index, long style);
}