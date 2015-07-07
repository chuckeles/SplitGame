using UnityEngine;

namespace SplitGame {

  /// <summary>
  ///   Wobbles the goob on mouse hover.
  /// </summary>
  [RequireComponent(typeof (WobbleScale))]
  public class CollisionWobble : MonoBehaviour {
    #region Methods

    public void OnTriggerEnter2D(Collider2D collision) {
      // is it a wall?
      if (collision.tag == "Wall") {
        // wobble
        GetComponent<WobbleScale>().Wobble(WobbleForce);
      }
    }

    #endregion

    #region Fields

    public float WobbleForce = 1.0f;

    #endregion
  }

}