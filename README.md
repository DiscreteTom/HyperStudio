# HyperStudio

> **Note**: Only Windows is supported.

Cast your PC screens to Leiniao AR glasses.

## Run

To run this app in a specific monitor:

```bash
# https://docs.unity3d.com/Manual/PlayerCommandLineArguments.html
HyperStudio.exe -monitor N
```

> **Note**: N starts from 1 instead of 0.

> **Note**: Make sure you have `config.json` in the exe folder.

## How to Use

- Drag screen using mouse to move the screen.
- Scroll to scale the screen.
- Scroll while pressing `Ctrl` to push away / pull close a screen.
- Press `ESC` to remove a screen.
- Press `Ctrl + '+'/'-'` to bend the screen.
- Press `Ctrl + 0` to toggle bend.
- Press `Ctrl + J/K/L/U/I/O` to rotate screen.
- Press `Ctrl + R` to reset viewpoint direction.
- Press `Ctrl + S` to save screen's location, rotation and scale to config.
- Press `Ctrl + Shift + R` to reload the scene.
- Press `Alt + F4` to exit.

## FAQ

- Sorry this display is unsupported?
  - Disable your discrete GPU driver.
  - https://github.com/hecomi/uDesktopDuplication/issues/30
- Virtual monitor?
  - https://www.amyuni.com/forum/viewtopic.php?t=3030
