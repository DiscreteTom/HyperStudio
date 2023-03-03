using UnityEngine;

namespace DT.General {
  public class Entry : ComposableBehaviour {
    public IIoCC core { get; private set; } = new IoCC();

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.core.Add<T>(instance);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.core.Add<T>();
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.core.Get<T>();
    #endregion
  }

  /// <summary>
  /// ComposableBehaviour with core injected.
  /// </summary>
  public class CBC : ComposableBehaviour {
    IIoCC _core = null;
    protected IIoCC core {
      get {
        if (this._core != null) return this._core;

        // first, try to find the core in the root object
        this._core = this.transform.root.GetComponent<Entry>().core;
        if (this._core != null) return this._core;

        // second, try to find the core in the parent object
        this._core = this.GetComponentInParent<Entry>().core;
        if (this._core != null) return this._core;

        // finally, try to find the core in the whole scene
        this._core = GameObject.FindObjectOfType<Entry>().core;
        if (this._core != null) return this._core;

        // if we can't find the core, throw an error
        throw new System.Exception("Can't find core in the scene!");
      }
      set => this._core = value;
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.core.Add<T>(instance);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.core.Add<T>();
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.core.Get<T>();
    #endregion
  }
}