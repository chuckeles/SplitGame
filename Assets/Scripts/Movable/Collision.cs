using UnityEngine;

namespace SplitGame {

  /// <summary>
  ///   Stops the goob on collision with a static object.
  /// </summary>
  [RequireComponent(typeof (Movable))]
  public class Collision : MonoBehaviour {
    #region Methods

    public void OnTriggerEnter2D(Collider2D collision) {
      // is it a wall?
      if (collision.tag == "Wall") {
        // stop
        GetComponent<Movable>().StopAndAlign();
      }
    }

    public void Start() {
      // test requirements
      if (GetComponent<Movable>() == null)
        throw new MissingComponentException("Movable is required but not attached");
    }

    #endregion
  }

}