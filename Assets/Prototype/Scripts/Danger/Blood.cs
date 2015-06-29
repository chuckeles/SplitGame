using UnityEngine;

/// <summary>
///   Destroyes the blood after 2 seconds.
/// </summary>
public class Blood : MonoBehaviour {
  #region Methods

  public void Start() {
    Destroy(gameObject, 2);
  }

  #endregion
}