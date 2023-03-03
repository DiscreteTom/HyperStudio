using UnityEngine;

public class XRCamera : MonoBehaviour {
  void Start() {
    XRSDK.XRSDK_Init();
    XRSDK.Reset();
  }

  void Update() {
    float x, y, z, w; // range: [-1, 1]
    unsafe {
      long addr = XRSDK.GetArSensor();
      x = *(float*)(addr + 44);
      y = *(float*)(addr + 48);
      z = *(float*)(addr + 52);
      w = *(float*)(addr + 56);
    }

    this.transform.rotation = new Quaternion(x, y, z, w);
  }
}
