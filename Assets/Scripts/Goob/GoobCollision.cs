using UnityEngine;

/// <summary>
///   Stops the goob on collision with a static object.
/// </summary>
[RequireComponent(typeof (GoobMove))]
public class GoobCollision : MonoBehaviour {
  #region Methods

  public void OnTriggerEnter2D(Collider2D collision) {
    // is it a wall?
    if (collision.tag == "Wall") {
      // stop
      GetComponent<GoobMove>().StopAndPrevious();
    }
  }

  public void Start() {
    // test requirements
    if (GetComponent<GoobMove>() == null)
      throw new MissingComponentException("GoobMove is required but not attached");
  }

  #endregion
}