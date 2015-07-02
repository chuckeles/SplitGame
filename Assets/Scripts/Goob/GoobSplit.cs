using UnityEngine;

namespace SplitGame {

  /// <summary>
  ///   Handles the splitting of the Goob. This is controlled by the mouse.
  /// </summary>
  [RequireComponent(typeof (Movable))]
  public class GoobSplit : MonoBehaviour {
    #region Methods

    public void OnMouseOver() {
      // check the mouse
      if (!mHold && Input.GetButtonDown("Mouse 0")) {
        mHold = true;

        // set the position
        mMouseClickPosition = Input.mousePosition;

        // adjust to world coords
        mMouseClickPosition = mMainCamera.ScreenToWorldPoint(mMouseClickPosition);
      }
    }

    public void Start() {
      // test requirements
      if (GetComponent<Movable>() == null)
        throw new MissingComponentException("Movable is required but not attached");

      // get the camera
      mMainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Update() {
      // check the mouse
      if (mHold && Input.GetButtonUp("Mouse 0")) {
        mHold = false;

        // check if we are stationary
        if (!GetComponent<Movable>().IsMoving) {

          // create another goob
          GameObject anotherGoob = Instantiate(gameObject);

          // set parent
          anotherGoob.transform.parent = transform.parent;

          // get mouse position
          Vector2 mousePosition = Input.mousePosition;

          // adjust to world coords
          mousePosition = mMainCamera.ScreenToWorldPoint(mousePosition);

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
          GetComponent<Movable>().Move(direction);

          // instruct the other one to move in other direction
          anotherGoob.GetComponent<Movable>()
            .Move(direction == MovementDirection.Right ? MovementDirection.Left : MovementDirection.Down);
        }
      }
    }

    #endregion

    #region Fields

    private bool mHold;
    private Camera mMainCamera;
    private Vector2 mMouseClickPosition;

    #endregion
  }

}