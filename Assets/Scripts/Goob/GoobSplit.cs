using UnityEngine;

/// <summary>
///   Handles the splitting of the Goob. This is controlled by the mouse.
/// </summary>
[RequireComponent(typeof (GoobMove))]
public class GoobSplit : MonoBehaviour {
  #region Methods

  public void OnMouseOver() {
    // check the mouse
    if (!mHold && Input.GetButtonDown("Mouse 0")) {
      mHold = true;
    }
  }

  public void Update() {
    // check the mouse
    if (mHold && Input.GetButtonUp("Mouse 0")) {
      mHold = false;

      // create another goob
      GameObject anotherGoob = Instantiate(gameObject);

      // start moving towards the mouse

      // instruct the other one to move in other direction

    }
  }

  #endregion

  #region Fields

  private bool mHold;

  #endregion
}