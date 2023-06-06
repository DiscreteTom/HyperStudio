using DT.UniStart;
using TMPro;
using UnityEngine;

public class HelpText : CBC {
  void Start() {
    var text = this.GetComponent<TMP_Text>();
    text.text = @"Hold `Tab` to show this help.
Press `Enter` to toggle full screen.
Drag screen using mouse to move the screen.
Scroll to scale the screen.
Scroll while pressing `Ctrl` to push away / pull close a screen.
Press `Backspace` to remove a screen.
Hold `Ctrl + J/K/L/U/I/O` to rotate screen.
Press `Ctrl + Shift + R` to reload the scene.
Press `Ctrl + S` to save screen's location, rotation and scale to config.
Press `Ctrl + F` to toggle `AutoLookAtCamera`.
Press `ESC` to exit.";

    // hold tab to show help text
    this.onUpdate.AddListener(() => {
      text.enabled = Input.GetKey(KeyCode.Tab);
    });
  }
}