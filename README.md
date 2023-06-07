# HyperStudio

![GitHub release (latest by date)](https://img.shields.io/github/v/release/DiscreteTom/HyperStudio?style=flat-square)
![Platform support](https://img.shields.io/badge/platform-windows-blue?style=flat-square)
![Built with Unity3D](https://img.shields.io/badge/Built%20with-Unity3D-lightgrey?style=flat-square)
![license](https://img.shields.io/github/license/DiscreteTom/HyperStudio?style=flat-square)

> **Note**: This is only available on Windows.

Cast your PC screens to AR glasses.

## [Download](https://github.com/DiscreteTom/HyperStudio/releases)

## Features

- Auto apply your monitor layout from your system settings.
- Optionally show on all virtual desktops.
- Move or scale your screen.
- You can adapt to any AR glasses by implementing a `TransformProvider` DLL.

## How to Use

First, select a `TransformProvider`, and replace the `HyperStudio_Data/Plugins/x86_64/TransformProvider.dll`.

> Known `TransformProvider`s:
>
> - [hstp-rayneo-air](https://github.com/DiscreteTom/hstp-rayneo-air)

Then, start a [shremdup](https://github.com/DiscreteTom/shremdup) (v0.1.7+) server **_with administrator privilege_** (to use shared memory across processes). The gRPC port is 3030, so you should run `shremdup.exe 3030`.

> **Note**: You can customize the port in HyperStudio's `config.json`.

Finally, start `HyperStudio.exe` **_with administrator privilege_** to run this app. You can press `Enter` to toggle full screen mode.

> **Note**: Hold `Tab` to show the help info.

## FAQ

- Virtual monitor?
  - https://www.amyuni.com/forum/viewtopic.php?t=3030
  - https://github.com/pavlobu/deskreen/discussions/86

## For Developers

### Write Your Own Transform Provider

You can refer to [hstp-rayneo-air](https://github.com/DiscreteTom/hstp-rayneo-air).

### Related Projects

- [HyperDesktopDuplication](https://github.com/DiscreteTom/HyperDesktopDuplication)
- [shremdup](https://github.com/DiscreteTom/shremdup)
- [rusty-duplication](https://github.com/DiscreteTom/rusty-duplication)

## [CHANGELOG](https://github.com/DiscreteTom/HyperStudio/blob/main/CHANGELOG.md)
