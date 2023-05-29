using System.Threading.Tasks;
using Google.Protobuf.Collections;
using UnityEngine;

namespace HyperDesktopDuplication {
  public class HDD_Manager : MonoBehaviour {
    public string server = "localhost:3030";
    public GameObject monitorPrefab;
    public RepeatedField<Shremdup.DisplayInfo> Monitors { get; private set; }
    public bool ready { get; private set; } = false;

    Grpc.Core.Channel channel;
    Shremdup.Shremdup.ShremdupClient client;
    string filenamePrefix;

    void Awake() {
      this.channel = new Grpc.Core.Channel(server, Grpc.Core.ChannelCredentials.Insecure);
      this.client = new Shremdup.Shremdup.ShremdupClient(channel);
      this.filenamePrefix = "Global\\HDD-" + System.DateTime.Now.Ticks.ToString();
      Logger.Log($"filenamePrefix: {this.filenamePrefix}");
    }

    public async Task Refresh() {
      // list displays
      var reply = await this.client.ListDisplaysAsync(new Shremdup.ListDisplaysRequest { });
      for (var i = 0; i < reply.Infos.Count; ++i) {
        var info = reply.Infos[i];
        var width = info.Right - info.Left;
        var height = info.Bottom - info.Top;
        Logger.Log($"display {i}: {width}x{height}, name={info.Name}, primary={info.IsPrimary}");
      }
      this.Monitors = reply.Infos;
      this.ready = true;
    }

    public GameObject CreateMonitor(int id) {
      var info = this.Monitors[id];
      var width = info.Right - info.Left;
      var height = info.Bottom - info.Top;
      var monitor = Instantiate(monitorPrefab);
      monitor.transform.parent = this.transform;
      monitor.gameObject.name = $"Monitor {id}";
      monitor.GetComponent<HDD_Monitor>().Setup(this.client, id, info, this.filenamePrefix);
      return monitor;
    }

    async void OnDestroy() {
      // first, destroy all monitors
      var monitors = GetComponentsInChildren<HDD_Monitor>();
      for (var i = 0; i < monitors.Length; ++i) {
        var monitor = monitors[i];
        await monitor.DestroyMonitor();
      }

      // then close the channel
      try {
        await channel.ShutdownAsync();
        Logger.Log("channel shutdown");
      } catch {
        Logger.Log("channel not shutdown");
      }
    }

    public int primaryIndex {
      get {
        for (var i = 0; i < this.Monitors.Count; ++i) {
          if (this.Monitors[i].IsPrimary) {
            return i;
          }
        }
        return -1;
      }
    }
    public Shremdup.DisplayInfo primaryInfo => this.primaryIndex >= 0 ? this.Monitors[this.primaryIndex] : null;
  }
}
