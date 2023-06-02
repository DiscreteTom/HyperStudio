using UnityEngine;

namespace HyperDesktopDuplication {
  public class DesktopRenderer : MonoBehaviour {
    public bool visible { get; private set; }

    void OnBecameVisible() {
      this.visible = true;
    }

    void OnBecameInvisible() {
      this.visible = false;
    }
  }
}