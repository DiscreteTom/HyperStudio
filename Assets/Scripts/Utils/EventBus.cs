using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.General {
  public class EventBus {
    Dictionary<object, object> dict;

    public EventBus() {
      this.dict = new Dictionary<object, object>();
    }

    public void AddListener(object key, UnityAction action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new UnityEvent());
      }
      ((UnityEvent)this.dict[key]).AddListener(action);
    }
    public void AddListener<T0>(object key, UnityAction<T0> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new UnityEvent<T0>());
      }
      ((UnityEvent<T0>)this.dict[key]).AddListener(action);
    }
    public void AddListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new UnityEvent<T0, T1>());
      }
      ((UnityEvent<T0, T1>)this.dict[key]).AddListener(action);
    }
    public void AddListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new UnityEvent<T0, T1, T2>());
      }
      ((UnityEvent<T0, T1, T2>)this.dict[key]).AddListener(action);
    }
    public void AddListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new UnityEvent<T0, T1, T2, T3>());
      }
      ((UnityEvent<T0, T1, T2, T3>)this.dict[key]).AddListener(action);
    }

    public void RemoveListener(object key, UnityAction action) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent)this.dict[key]).RemoveListener(action);
    }
    public void RemoveListener<T0>(object key, UnityAction<T0> action) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0>)this.dict[key]).RemoveListener(action);
    }
    public void RemoveListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0, T1>)this.dict[key]).RemoveListener(action);
    }
    public void RemoveListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0, T1, T2>)this.dict[key]).RemoveListener(action);
    }
    public void RemoveListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0, T1, T2, T3>)this.dict[key]).RemoveListener(action);
    }

    public void Invoke(object key) {
      Debug.Log(key);
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent)this.dict[key]).Invoke();
    }
    public void Invoke<T0>(object key, T0 arg0) {
      Debug.Log(key);
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0>)this.dict[key]).Invoke(arg0);
    }
    public void Invoke<T0, T1>(object key, T0 arg0, T1 arg1) {
      Debug.Log(key);
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0, T1>)this.dict[key]).Invoke(arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(object key, T0 arg0, T1 arg1, T2 arg2) {
      Debug.Log(key);
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0, T1, T2>)this.dict[key]).Invoke(arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(object key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      Debug.Log(key);
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((UnityEvent<T0, T1, T2, T3>)this.dict[key]).Invoke(arg0, arg1, arg2, arg3);
    }
  }
}