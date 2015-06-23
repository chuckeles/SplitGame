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

  /// <summary>
  ///   Stops the goob and moves it to previous position.
  /// </summary>
  public void StopAndPrevious() {
    Stop();

    // move to previous position
    transform.position = mPreviousPosition;
  }

  /// <summary>
  /// Stops the goob and aligns it to a 1x1 grid.
  /// </summary>
  public void StopAndAlign() {
    Stop();

    // align
    Vector3 newPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);
    transform.position = newPosition;
  }

  public void Update() {
    // update previous position
    mPreviousPosition = transform.position;

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
  public float MovementSpeed = 2f;

  // actual movement of the goob
  private MovementDirection mMovementDirection = MovementDirection.None;

  // previous position
  private Vector3 mPreviousPosition;

  #endregion
}