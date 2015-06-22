using UnityEngine;

/// <summary>
///   Handles the splitting of the Goob. This is controlled by the mouse.
/// </summary>
public class GoobSplit : MonoBehaviour {
  #region Methods

  public void OnMouseOver() {
    // check the mouse
    if (Input.GetButtonDown("Mouse 0")) {
      mHold = true;
      Debug.Log("Pressed");
    }
    else if (Input.GetButtonUp("Mouse 0")) {
      mHold = false;
      Debug.Log("Released");
    }
  }

  #endregion

  #region Fields

  private bool mHold;

  #endregion
}