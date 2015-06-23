using UnityEngine;

/// <summary>
///   Activates a door on press.
/// </summary>
public class Button : MonoBehaviour {
  #region Methods

  public void OnTriggerEnter2D(Collider2D collision) {
    // is it a goob?
    if (collision.tag != "Goob")
      return;

    // check the approach direction
    MovementDirection goobDirection = collision.GetComponent<GoobMove>().MovementDirection;

    // get my direction
    float direction = transform.rotation.eulerAngles.z;

    // "normalize"
    while (direction < 0)
      direction += 360;
    while (direction > 360)
      direction -= 360;

    // round
    direction = Mathf.Round(direction);

    // transform
    MovementDirection myDirection;

    if (direction < 10)
      myDirection = MovementDirection.Right;
    else if (direction < 100)
      myDirection = MovementDirection.Up;
    else if (direction < 190)
      myDirection = MovementDirection.Left;
    else
      myDirection = MovementDirection.Down;

    // can the button be pressed?
    if (goobDirection == MovementDirection.Right && myDirection == MovementDirection.Left ||
        goobDirection == MovementDirection.Down && myDirection == MovementDirection.Up ||
        goobDirection == MovementDirection.Left && myDirection == MovementDirection.Right ||
        goobDirection == MovementDirection.Up && myDirection == MovementDirection.Down)
      Activate();
  }

  /// <summary>
  ///   Activates the button.
  /// </summary>
  private void Activate() {
    // press the button
    Pressed = true;

    // remove trigger
    Destroy(GetComponent<Collider2D>());

    // change sprite
    GetComponent<SpriteRenderer>().sprite = PressedButtonSprite;
  }

  #endregion

  #region Properties

  // whether the button is pressed
  public bool Pressed { get; private set; }

  #endregion

  #region Fields

  // sprite to use when pressed
  public Sprite PressedButtonSprite;

  #endregion
}