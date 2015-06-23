using UnityEngine;

/// <summary>
///   Pushes stationary goobs in it's direction.
/// </summary>
public class PushArea : MonoBehaviour {
  #region Methods

  public void OnTriggerEnter2D(Collider2D collision) {
    // check it is goob
    if (collision.tag != "Goob")
      return;

    // get direction
    float direction = transform.rotation.eulerAngles.z;

    // "normalize"
    while (direction < 0)
      direction += 360;
    while (direction > 360)
      direction -= 360;

    // round
    direction = Mathf.Round(direction);

    // transform
    MovementDirection movementDirection;

    if (direction < 10)
      movementDirection = MovementDirection.Right;
    else if (direction < 100)
      movementDirection = MovementDirection.Up;
    else if (direction < 190)
      movementDirection = MovementDirection.Left;
    else
      movementDirection = MovementDirection.Down;

    // apply movement
    collision.GetComponent<GoobMove>().Move(movementDirection);
  }

  #endregion
}