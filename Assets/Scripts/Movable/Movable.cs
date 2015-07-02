using UnityEngine;

/// <summary>
///   Handles the goob movement and collisions.
/// </summary>
public class GoobMove : MonoBehaviour {
  #region Constructor

  public GoobMove() {
    MovementDirection = MovementDirection.None;
  }

  #endregion

  #region Methods

  /// <summary>
  ///   Moves the goob in a direction, if it's not moving already.
  /// </summary>
  /// <param name="movementDirection">Desired movement direction</param>
  public void Move(MovementDirection movementDirection) {
    if (MovementDirection != MovementDirection.None) {
      // we are already moving
      return;
    }

    // start moving in the direction
    MovementDirection = movementDirection;
  }

  /// <summary>
  ///   Stops the goob.
  /// </summary>
  public void Stop() {
    MovementDirection = MovementDirection.None;
  }

  /// <summary>
  ///   Stops the goob and aligns it to a 1x1 grid.
  /// </summary>
  public void StopAndAlign() {
    Stop();

    // align
    var newPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),
                                  transform.position.z);
    transform.position = newPosition;

    // check my position for other goobs
    CheckGoobs();
  }

  public void Update() {
    // update previous position

    // move the goob
    switch (MovementDirection) {
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

  /// <summary>
  ///   Checks the position for other stationary goobs.
  /// </summary>
  private void CheckGoobs() {
    // get goobs
    GameObject[] goobs = GameObject.FindGameObjectsWithTag("Goob");

    // check them
    foreach (GameObject goob in goobs) {
      // is it me?
      if (goob == gameObject)
        continue;

      // is it moving?
      if (goob.GetComponent<GoobMove>().IsMoving)
        continue;

      // check position
      var deltaPos = new Vector2(Mathf.Abs(transform.position.x - goob.transform.position.x),
                                 Mathf.Abs(transform.position.y - goob.transform.position.y));

      if (Mathf.Max(deltaPos.x, deltaPos.y) < 0.2f) {
        // same grid cell, self-destruction imminent
        Destroy(gameObject);
        break;
      }
    }
  }

  #endregion

  #region Properties

  /// <summary>
  ///   Returns true if the goob is moving.
  /// </summary>
  public bool IsMoving {
    get { return MovementDirection != MovementDirection.None; }
  }

  /// <summary>
  ///   Returns the movement direction of the goob.
  /// </summary>
  public MovementDirection MovementDirection { get; private set; }

  #endregion

  #region Fields

  // movement speed of the goob
  public float MovementSpeed = 2f;

  #endregion
}