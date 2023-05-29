using System.Collections.Generic;
using DT.UniStart;
using TMPro;
using UnityEngine;

public class TipText : CBC {
  void Start() {
    var msgs = new List<string>();
    var timeout = new Stack<float>();
    var text = this.GetComponent<TMP_Text>();
    var eb = this.Get<IEventBus>();

    text.text = "";

    var updateText = Fn(() => {
      text.text = "";
      msgs.ForEach(msg => text.text += "\n" + msg);
    });

    eb.AddListener("tip", (string msg) => {
      msgs.Add(msg);
      timeout.Push(Time.time + Config.instance.TipMessageTimeout);
      updateText();
    });

    this.onUpdate.AddListener(() => {
      if (timeout.Count > 0 && Time.time > timeout.Peek()) {
        timeout.Pop();
        msgs.RemoveAt(0);
        updateText();
      }
    });
  }
}