using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace HyperDesktopDuplication {
  public class HDD_Monitor : MonoBehaviour {
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern IntPtr OpenFileMapping(int dwDesiredAccess, bool bInheritHandle, string lpName);
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern IntPtr CreateFileMappingA(int hFile, IntPtr lpAttributes, int flProtect, int dwMaxSizeHi, int dwMaxSizeLow, string lpName);
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, int dwNumberOfBytesToMap);
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    static extern bool UnmapViewOfFile(IntPtr pvBaseAddress);
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    static extern bool CloseHandle(IntPtr handle);
    const int FILE_MAP_ALL_ACCESS = ((0x000F0000) | 0x0001 | 0x0002 | 0x0004 | 0x0008 | 0x0010);

    enum State {
      Idle,
      CreateCapture,
      TakeCapture,
      TakeCaptureDone,
    }

    State state = State.Idle;
    Shremdup.Shremdup.ShremdupClient client;
    IntPtr handle;
    IntPtr address;
    int bufSize;
    Texture2D texture;
    string filename; // name of shared memory
    Transform mouse;
    (int, int) mousePixelPosition;
    Shremdup.PointerShape pointerShapeCache;
    Material mouseMaterial;
    Shremdup.DisplayInfo info;
    DesktopRenderer desktopRenderer;
    bool destroyed;

    public int id { get; private set; } = 0;
    public int pixelWidth => (int)this.info.PixelWidth;
    public int pixelHeight => (int)this.info.PixelHeight;
    public int rotation => this.info.Rotation;
    public bool portrait => this.rotation == 2 || this.rotation == 4;
    public bool landscape => this.rotation == 1 || this.rotation == 3;
    public int width => this.portrait ? this.info.Bottom - this.info.Top : this.info.Right - this.info.Left;
    public int height => this.portrait ? this.info.Right - this.info.Left : this.info.Bottom - this.info.Top;

    public void Setup(Shremdup.Shremdup.ShremdupClient client, int id, Shremdup.DisplayInfo info, string filenamePrefix) {
      this.client = client;
      this.id = id;
      this.filename = $"{filenamePrefix}-{id}";
      this.info = info;
      this.pointerShapeCache = new Shremdup.PointerShape();
      this.destroyed = false;

      this.mouse = this.transform.Find("MouseRenderer");
      this.mouseMaterial = this.mouse.GetComponent<Renderer>().material;
      this.desktopRenderer = this.GetComponentInChildren<DesktopRenderer>();

      this.bufSize = this.pixelWidth * this.pixelHeight * 4; // 4 for BGRA32
      this.texture = new Texture2D(this.portrait ? this.pixelHeight : this.pixelWidth, this.portrait ? this.pixelWidth : this.pixelHeight, TextureFormat.BGRA32, false);
      this.desktopRenderer.GetComponent<Renderer>().material.mainTexture = this.texture;
      Logger.Log($"display {this.id}: texture created with size: {this.pixelWidth}x{this.pixelHeight}");
      this.desktopRenderer.transform.localScale = new Vector3(this.width, this.height, 1); // resize to a proper size
      this.desktopRenderer.transform.localRotation = Quaternion.Euler(0, 0, this.rotation * 90 - 90); // rotate to a proper angle

      this.CreateCapture();
    }

    async void CreateCapture() {
      this.state = State.CreateCapture;

      await client.CreateCaptureAsync(new Shremdup.CreateCaptureRequest { Id = (uint)this.id, Name = filename, Open = false });

      this.handle = OpenFileMapping(FILE_MAP_ALL_ACCESS, false, filename);
      if (handle == IntPtr.Zero) {
        Logger.Log($"display {this.id}: OpenFileMapping() failed: {Marshal.GetLastWin32Error()}");
        return;
      }

      this.address = MapViewOfFile(handle, FILE_MAP_ALL_ACCESS, 0, 0, this.bufSize);
      if (address == IntPtr.Zero) {
        Logger.Log($"display {this.id}: MapViewOfFile() failed");
        return;
      }

      this.TakeCapture();
    }

    async void TakeCapture() {
      this.state = State.TakeCapture;

      try {
        var res = await client.TakeCaptureAsync(new Shremdup.TakeCaptureRequest { Id = (uint)this.id });

        // don't access memory if this is destroyed
        // to avoid crash
        if (this.destroyed) return;

        if (res.DesktopUpdated) {
          // load from shared memory
          texture.LoadRawTextureData(address, bufSize);
          texture.Apply();
        }

        if (res.PointerPosition != null) {
          // update mouse position
          var pos = res.PointerPosition;
          if (pos.Visible) {
            mouse.gameObject.SetActive(true);
          } else {
            mouse.gameObject.SetActive(false);
          }
          // set z to -0.001 to make sure it's in front of the desktop
          // TODO: use width instead of pixel_width?
          // e.g. x = (-this.pixel_width / 2 + pos.X) * this.width / this.pixel_width
          mouse.localPosition = new Vector3(-this.pixelWidth / 2 + pos.X + this.mouse.transform.localScale.x / 2, -this.pixelHeight / 2 + pos.Y + this.mouse.transform.localScale.y / 2, -0.001f);
          this.mousePixelPosition = (pos.X, pos.Y);
        }

        if (res.PointerShape != null) {
          // update mouse shape
          var shape = res.PointerShape;
          this.pointerShapeCache = shape;
          switch (shape.ShapeType) {
            case 1: {
                // DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MONOCHROME
                // IMPORTANT: cursor height = shape.Height / 2
                var cursorTexture = new Texture2D((int)shape.Width, (int)shape.Height / 2, TextureFormat.ARGB32, false);
                var raw = shape.Data.ToByteArray();
                var shift = raw.Length / 2; // use the second half of the raw buffer
                var pixelCount = (int)shape.Width * (int)shape.Height / 2;
                var textureBuffer = new byte[pixelCount * 4];
                for (var i = 0; i < pixelCount; ++i) {
                  var bitMask = (byte)(0b10000000 >> (i % 8)); // 8 pixels per byte
                  var andMask = (byte)(raw[i / 8] & bitMask);
                  var xorMask = (byte)(raw[i / 8 + shift] & bitMask);

                  // IMPORTANT: masks only affect RGB, not A
                  if (andMask != 0 && xorMask != 0) {
                    // if AND and XOR: (any AND 1) XOR 1 => invert any, this shouldn't happen
                    Logger.Log("AND and XOR: any xor 1 == invert, this shouldn't happen");
                  } else if (andMask != 0 && xorMask == 0) {
                    // if AND and not XOR: (any AND 1) XOR 0 => any, transparent
                    textureBuffer[i * 4] = 0; // just set alpha to 0
                  } else if (andMask == 0 && xorMask != 0) {
                    // if not AND and XOR: (any AND 0) XOR 1 => 1, all one, white
                    textureBuffer[i * 4] = 255;
                    textureBuffer[i * 4 + 1] = 255;
                    textureBuffer[i * 4 + 2] = 255;
                    textureBuffer[i * 4 + 3] = 255;
                  } else if (andMask == 0 && xorMask == 0) {
                    // if not AND and not XOR: (any AND 0) XOR 0 == 0, all zero, black
                    textureBuffer[i * 4] = 255; // A is not affected by masks
                    textureBuffer[i * 4 + 1] = 0;
                    textureBuffer[i * 4 + 2] = 0;
                    textureBuffer[i * 4 + 3] = 0;
                  }
                }
                cursorTexture.SetPixelData(textureBuffer, 0);
                cursorTexture.Apply();
                this.mouseMaterial.mainTexture = cursorTexture;
                this.mouse.transform.localScale = new Vector3(shape.Width, shape.Height / 2, 1);
                break;
              }
            case 2: {
                // DXGI_OUTDUPL_POINTER_SHAPE_TYPE_COLOR
                var cursorTexture = new Texture2D((int)shape.Width, (int)shape.Height, TextureFormat.ARGB32, false);
                cursorTexture.SetPixelData(shape.Data.ToByteArray(), 0);
                cursorTexture.Apply();
                this.mouseMaterial.mainTexture = cursorTexture;
                this.mouse.transform.localScale = new Vector3(shape.Width, shape.Height, 1);
                break;
              }
            case 4: {
                // DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MASKED_COLOR
                // will update pointer shape with mask below
                break;
              }
            default: {
                Logger.Log($"display {this.id}: unknown pointer shape type {shape.ShapeType}");
                break;
              }
          }
        }

        if (this.pointerShapeCache.ShapeType == 4 && (res.DesktopUpdated || res.PointerPosition != null || res.PointerShape != null)) {
          // DXGI_OUTDUPL_POINTER_SHAPE_TYPE_MASKED_COLOR
          this.UpdatePointerShapeWithMask();
        }
      } catch (Exception e) {
        Logger.Log($"display {this.id}: TakeCapture failed: {e}");
      }

      this.state = State.TakeCaptureDone;
    }

    void UpdatePointerShapeWithMask() {
      var shape = this.pointerShapeCache;
      var cursorTexture = this.mouseMaterial.mainTexture as Texture2D; // check if we can reuse the existing texture
      if (cursorTexture == null || cursorTexture.width != shape.Width || cursorTexture.height != shape.Height)
        cursorTexture = new Texture2D((int)shape.Width, (int)shape.Height, TextureFormat.ARGB32, false);
      var raw = shape.Data.ToByteArray();
      for (var i = 0; i < raw.Length; i += 4) {
        var cursorPixelIndex = i / 4;
        var desktopX = (cursorPixelIndex % (int)shape.Width) + this.mousePixelPosition.Item1;
        var desktopY = (cursorPixelIndex / (int)shape.Width) + this.mousePixelPosition.Item2;
        var desktopPixelOffset = desktopX + (long)desktopY * this.pixelWidth;
        var desktopPixelAddress = ((long)this.address) + desktopPixelOffset * 4;
        // desktop pixel
        byte r, g, b;
        unsafe {
          // desktop pixel format is BGRA
          b = *(byte*)(desktopPixelAddress);
          g = *(byte*)(desktopPixelAddress + 1);
          r = *(byte*)(desktopPixelAddress + 2);
        }
        if (raw[i] == 0xFF) {
          // XOR with the desktop pixel
          raw[i] = 255;
          raw[i + 1] ^= r;
          raw[i + 2] ^= g;
          raw[i + 3] ^= b;
        }
        // else: transparent, just keep the the alpha channel `raw[i]` to 0
      }
      cursorTexture.SetPixelData(raw, 0);
      cursorTexture.Apply();
      this.mouseMaterial.mainTexture = cursorTexture;
      this.mouse.transform.localScale = new Vector3(shape.Width, shape.Height, 1);
    }

    void Update() {
      // call take capture in Update to control the request interval
      if (this.state == State.TakeCaptureDone && this.desktopRenderer.visible) this.TakeCapture();
    }

    public void DestroyMonitor() {
      if (this.destroyed) return;
      this.destroyed = true;

      // first, set to idle to prevent further updates
      this.state = State.Idle;

      // close shared memory file
      if (address != IntPtr.Zero && !UnmapViewOfFile(address)) {
        Logger.Log($"display {this.id}: UnmapViewOfFile() failed");
        Logger.Log(Marshal.GetLastWin32Error());
      }
      if (handle != IntPtr.Zero && !CloseHandle(handle)) {
        Logger.Log($"display {this.id}: CloseHandle() failed");
        Logger.Log(Marshal.GetLastWin32Error());
      }

      // stop server capture
      try {
        client.DeleteCapture(new Shremdup.DeleteCaptureRequest { Id = (uint)this.id });
        Logger.Log($"display {this.id}: capture deleted");
      } catch (Exception e) {
        Logger.Log($"display {this.id}: delete capture failed: {e}");
      }
    }

    void OnDestroy() {
      if (!this.destroyed)
        this.DestroyMonitor();
    }
  }
}
