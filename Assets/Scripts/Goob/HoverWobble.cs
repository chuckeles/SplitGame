using UnityEngine;

namespace SplitGame {

  /// <summary>
  ///   Wobbles the goob on mouse hover.
  /// </summary>
  [RequireComponent(typeof (WobbleScale))]
  public class HoverWobble : MonoBehaviour {
    #region Methods

    public void OnMouseEnter() {
      // wobble
      GetComponent<WobbleScale>().Wobble(WobbleForce);
    }

    #endregion

    #region Fields

    public float WobbleForce = 1.0f;

    #endregion
  }

}