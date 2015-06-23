using UnityEngine;

/// <summary>
/// The door acts like a wall when closed and not when open.
/// </summary>
public class Door : MonoBehaviour {

  /// <summary>
  /// Open the door.
  /// </summary>
  public void Open() {
    // remove collider
    Destroy(GetComponent<Collider2D>());

    // set sprite
    GetComponent<SpriteRenderer>().sprite = OpenDoorSprite;
  }

  // sprite to use when open
  public Sprite OpenDoorSprite;

}