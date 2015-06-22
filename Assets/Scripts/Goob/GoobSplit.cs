using UnityEngine;

/// <summary>
///   Handles the splitting of the Goob. This is controlled by the mouse.
/// </summary>
public class GoobSplit : MonoBehaviour {
  #region Methods

  public void OnMouseOver() {
    // check the mouse
    if (!mHold && Input.GetButtonDown("Mouse 0")) {
      mHold = true;
      Debug.Log("Pressed");
    }
  }

  public void Update() {
    // check the mouse
    if (mHold && Input.GetButtonUp("Mouse 0")) {
      mHold = false;
      Debug.Log("Released");
    }
  }

  #endregion

  #region Fields

  private bool mHold;

  #endregion
}