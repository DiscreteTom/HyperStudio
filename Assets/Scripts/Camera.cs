using System.Runtime.InteropServices;
using UnityEngine;

public class Camera : MonoBehaviour {
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern void XRSDK_Init();
  [DllImport(@"Assets/XR/XRSDK.dll")]
  public static extern long GetArSensor();

  // Start is called before the first frame update
  void Start() {
    XRSDK_Init();
  }

  // Update is called once per frame
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
