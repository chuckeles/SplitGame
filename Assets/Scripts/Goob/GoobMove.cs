using UnityEngine;

/// <summary>
///   Handles the goob movement and collisions.
/// </summary>
public class GoobMove : MonoBehaviour {
  #region Methods

  /// <summary>
  ///   Moves the goob in a direction, if it's not moving already.
  /// </summary>
  /// <param name="movementDirection">Desired movement direction</param>
  public void Move(MovementDirection movementDirection) {
    if (mMovementDirection != MovementDirection.None) {
      // we are already moving
      return;
    }

    // start moving in the direction
    mMovementDirection = movementDirection;
  }

  /// <summary>
  ///   Stops the goob.
  /// </summary>
  public void Stop() {
    mMovementDirection = MovementDirection.None;
  }

  public void Update() {
    // move the goob
    switch (mMovementDirection) {
      case MovementDirection.Up:
        transform.Translate(0, MovementSpeed * Time.deltaTime, 0);
        break;

      case MovementDirection.Right:
        transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
        break;

      case MovementDirection.Down:
        transform.Translate(0, -MovementSpeed * Time.deltaTime, 0);
        break;

      case MovementDirection.Left:
        transform.Translate(-MovementSpeed * Time.deltaTime, 0, 0);
        break;
    }
  }

  #endregion

  #region Fields

  // movement speed of the goob
  public float MovementSpeed = 1f;

  // actual movement of the goob
  private MovementDirection mMovementDirection = MovementDirection.None;

  #endregion
}