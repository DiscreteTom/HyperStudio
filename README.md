# HyperStudio

![GitHub release (latest by date)](https://img.shields.io/github/v/release/DiscreteTom/HyperStudio?style=flat-square)
![Platform support](https://img.shields.io/badge/platform-windows-blue?style=flat-square)
![Built with Unity3D](https://img.shields.io/badge/Built%20with-Unity3D-lightgrey?style=flat-square)

> **Note**: This is only available on Windows.

Cast your PC screens to Leiniao AR glasses.

## [Download](https://github.com/DiscreteTom/HyperStudio/releases)

## Features

- Auto apply your monitor layout from your system settings.
- Optionally show on all virtual desktops.
- You can set a view zone for each screen, so the screen will only be visible when your head is in a specific angle range.

## Launch the App

### The Simplest Way

Just double click `HyperStudio.exe` to run this app. You can press `Enter` to toggle full screen mode.

> **Note**: Make sure you have `config.json` in the exe folder.

### Set Resolution

```bash
# https://docs.unity3d.com/Manual/PlayerCommandLineArguments.html
HyperStudio.exe -screen-width 2400 -screen-height 1600
```

> **Note**: The desired resolution can exceed the AR monitor's resolution(1920x1080), and you will get a better display effect.

### Run in a Specific Monitor

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
  - Go to System Setting > Display > Graphics, find/add this app, and set options to Power Saving to use the on-chip GPU.
  - Or, you can directly disable your discrete GPU.
  - https://github.com/hecomi/uDesktopDuplication/issues/30
- Virtual monitor?
  - https://www.amyuni.com/forum/viewtopic.php?t=3030
  - https://github.com/pavlobu/deskreen/discussions/86

## [CHANGELOG](https://github.com/DiscreteTom/HyperStudio/blob/main/CHANGELOG.md)

## Credit

Thanks for these cool libs:

- [uDesktopDuplication](https://github.com/hecomi/uDesktopDuplication)
- [UnityRawInput](https://github.com/Elringus/UnityRawInput)
