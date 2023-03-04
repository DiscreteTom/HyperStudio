using System.Collections.Generic;
using DT.General;
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
Hold `Ctrl + '+'/'-'` to bend the screen.
Press `Ctrl + 0` to toggle bend.
Hold `Ctrl + J/K/L/U/I/O` to rotate screen.
Press `Ctrl + R` to reset viewpoint direction.
Press `Ctrl + Shift + R` to reload the scene.
Press `Ctrl + S` to save screen's location, rotation and scale to config.
Hold `Ctrl + V` to record view zone for the screen.
Press `Ctrl + Shift + V` to disable view zone for the screen.
Hold `Ctrl + A` to show all screens(not include removed).
Press `Ctrl + F` to toggle `AutoLookAtCamera`.
Press `ESC` to exit.";

    this.OnUpdate.AddListener(() => {
      if (Input.GetKey(KeyCode.Tab)) text.enabled = true;
      else text.enabled = false;
    });
  }
}