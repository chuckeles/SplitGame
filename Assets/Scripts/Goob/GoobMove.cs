using UnityEngine;

/// <summary>
///   Handles the goob movement and collisions.
/// </summary>
public class GoobMove : MonoBehaviour {
  #region Types

  public enum MovementDirection {

    Horizontal,
    Vertical

  }

  #endregion

  #region Methods

  public void Move(MovementDirection movementDirection) {}

  #endregion

  #region Fields

  // movement speed of the goob
  public float MovementSpeed = 1f;

  // actual speed of the goob
  private float mHorizontalSpeed = 0;
  private float mVerticalSpeed = 0;

  #endregion
}