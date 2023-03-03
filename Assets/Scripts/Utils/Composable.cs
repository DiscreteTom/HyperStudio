using UnityEngine;
using UnityEngine.Events;

namespace DT.General {
  /// <summary>
  /// Composable Lifecycle Manager.
  /// </summary>
  public class CLM {
    #region Composable Events
    /// <summary>
    /// Called every time when Update is called.
    /// </summary>
    public UnityEvent OnUpdate { get; } = new UnityEvent();
    /// <summary>
    /// Called every time when FixedUpdate is called.
    /// </summary>
    public UnityEvent OnFixedUpdate { get; } = new UnityEvent();
    /// <summary>
    /// Called every time when LateUpdate is called.
    /// </summary>
    public UnityEvent OnLateUpdate { get; } = new UnityEvent();
    #endregion

    #region Next Tick Events
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public UnityEvent OnNextUpdate { get; } = new UnityEvent();
    /// <summary>
    /// Called once on the next FixedUpdate.
    /// </summary>
    public UnityEvent OnNextFixedUpdate { get; } = new UnityEvent();
    /// <summary>
    /// Called once on the next LateUpdate.
    /// </summary>
    public UnityEvent OnNextLateUpdate { get; } = new UnityEvent();
    #endregion

    /// <summary>
    /// Invoke OnNextUpdate and OnUpdate.
    /// </summary>
    public void Update() {
      this.OnNextUpdate.Invoke();
      this.OnNextUpdate.RemoveAllListeners();
      this.OnUpdate.Invoke();
    }
    /// <summary>
    /// Invoke OnNextFixedUpdate and OnFixedUpdate.
    /// </summary>
    public void FixedUpdate() {
      this.OnNextFixedUpdate.Invoke();
      this.OnNextFixedUpdate.RemoveAllListeners();
      this.OnFixedUpdate.Invoke();
    }
    /// <summary>
    /// Invoke OnNextLateUpdate and OnLateUpdate.
    /// </summary>
    public void LateUpdate() {
      this.OnNextLateUpdate.Invoke();
      this.OnNextLateUpdate.RemoveAllListeners();
      this.OnLateUpdate.Invoke();
    }
  }

  /// <summary>
  /// MonoBehaviour with Composable Lifecycle Manager injected.
  /// </summary>
  public class ComposableBehaviour : MonoBehaviour {
    CLM composable = new CLM();

    /// <summary>
    /// Called every time when Update is called.
    /// </summary>
    protected UnityEvent OnUpdate => this.composable.OnUpdate;
    /// <summary>
    /// Called every time when FixedUpdate is called.
    /// </summary>
    protected UnityEvent OnFixedUpdate => this.composable.OnFixedUpdate;
    /// <summary>
    /// Called every time when LateUpdate is called.
    /// </summary>
    protected UnityEvent OnLateUpdate => this.composable.OnLateUpdate;
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    protected UnityEvent OnNextUpdate => this.composable.OnNextUpdate;
    /// <summary>
    /// Called once on the next FixedUpdate.
    /// </summary>
    protected UnityEvent OnNextFixedUpdate => this.composable.OnNextFixedUpdate;
    /// <summary>
    /// Called once on the next LateUpdate.
    /// </summary>
    protected UnityEvent OnNextLateUpdate => this.composable.OnNextLateUpdate;

    protected virtual void Update() => this.composable.Update();
    protected virtual void FixedUpdate() => this.composable.FixedUpdate();
    protected virtual void LateUpdate() => this.composable.LateUpdate();
  }
}