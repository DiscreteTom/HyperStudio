# HyperStudio

> **Note**: This is only available on Windows.

Cast your PC screens to Leiniao AR glasses.

## [Download](https://github.com/DiscreteTom/HyperStudio/releases)

## Features

- Auto apply your monitor layout from your system settings.
- Optionally show on all virtual desktops.
- You can set a view zone for each screen, so the screen will only be visible when your head is in a specific angle range.

## Run

Just double click `HyperStudio.exe` to run this app. You can press `Enter` to toggle full screen mode.

> **Note**: Make sure you have `config.json` in the exe folder.

To run this app in a specific monitor:

```bash
# https://docs.unity3d.com/Manual/PlayerCommandLineArguments.html
HyperStudio.exe -monitor N
```

> **Note**: N starts from 1 instead of 0.

## How to Use

- Hold `Tab` to show this help.
- Press `Enter` to toggle full screen.
- Drag screen using mouse to move the screen.
- Scroll to scale the screen.
- Scroll while pressing `Ctrl` to push away / pull close a screen.
- Press `Backspace` to remove a screen.
- Hold `Ctrl + '+'/'-'` to bend the screen.
- Press `Ctrl + 0` to toggle bend.
- Hold `Ctrl + J/K/L/U/I/O` to rotate screen.
- Press `Ctrl + R` to reset viewpoint direction.
- Press `Ctrl + Shift + R` to reload the scene.
- Press `Ctrl + S` to save screen's location, rotation and scale to config.
- Hold `Ctrl + V` to record view zone for the screen.
- Press `Ctrl + Shift + V` to disable view zone for the screen.
- Hold `Ctrl + A` to show all screens(not include removed).
- Press `Ctrl + F` to toggle `AutoLookAtCamera`.
- Press `ESC` to exit.

## FAQ

- Sorry this display is unsupported?
  - Disable your discrete GPU driver.
  - https://github.com/hecomi/uDesktopDuplication/issues/30
- Virtual monitor?
  - https://www.amyuni.com/forum/viewtopic.php?t=3030
  - https://github.com/pavlobu/deskreen/discussions/86
