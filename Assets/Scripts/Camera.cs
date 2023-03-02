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
    float pitch, yaw, roll; // range: [-1, 1]
    unsafe {
      long addr = GetArSensor();
      pitch = *(float*)(addr + 44);
      yaw = *(float*)(addr + 48);
      roll = *(float*)(addr + 52);
    }

    this.transform.eulerAngles = new Vector3(pitch, yaw, roll) * 180;
  }
}
