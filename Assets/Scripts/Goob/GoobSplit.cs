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

      // set the position
      mMouseClickPosition = Input.mousePosition;

      // adjust to world coords
      mMouseClickPosition = MainCameraSingleton.Instance.GetComponent<Camera>().ScreenToWorldPoint(mMouseClickPosition);
    }
  }

  public void Start() {
    // test requirements
    if (GetComponent<GoobMove>() == null)
      throw new MissingComponentException("GoobMove is required but not attached");
  }

  public void Update() {
    // check the mouse
    if (mHold && Input.GetButtonUp("Mouse 0")) {
      mHold = false;

      // create another goob
      GameObject anotherGoob = Instantiate(gameObject);

      // set parent
      anotherGoob.transform.parent = transform.parent;

      // get mouse position
      Vector2 mousePosition = Input.mousePosition;

      // adjust to world coords
      mousePosition = MainCameraSingleton.Instance.GetComponent<Camera>().ScreenToWorldPoint(mousePosition);

      // get delta
      Vector2 mouseDelta = mousePosition - mMouseClickPosition;

      // get the direction
      MovementDirection direction;
      if (Mathf.Abs(mouseDelta.x) > Mathf.Abs(mouseDelta.y)) {
        // horizontal
        direction = MovementDirection.Right;
      }
      else {
        // vertical
        direction = MovementDirection.Up;
      }

      // start moving towards the mouse
      GetComponent<GoobMove>().Move(direction);

      // instruct the other one to move in other direction
      anotherGoob.GetComponent<GoobMove>()
        .Move(direction == MovementDirection.Right ? MovementDirection.Left : MovementDirection.Down);
    }
  }

  #endregion

  #region Fields

  private bool mHold;
  private Vector2 mMouseClickPosition;

  #endregion
}