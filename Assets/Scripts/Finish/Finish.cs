using UnityEngine;

/// <summary>
///   Manages the finish block.
/// </summary>
public class Finish : MonoBehaviour {
  #region Methods

  public void Update() {
    // check for a goob on me
    Collider2D goob = Physics2D.OverlapPoint(transform.position);

    // set the is activated
    IsActivated = (goob && !goob.GetComponent<GoobMove>().IsMoving);
  }

  #endregion

  #region Properties

  /// <summary>
  ///   Returns true is there's a stationary goob on the finish block.
  /// </summary>
  public bool IsActivated { get; private set; }

  #endregion
}