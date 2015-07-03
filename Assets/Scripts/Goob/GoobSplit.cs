using UnityEngine;

namespace SplitGame {

  /// <summary>
  ///   Handles the splitting of the Goob. This is controlled by the mouse.
  /// </summary>
  [RequireComponent(typeof (Movable)), RequireComponent(typeof (WobbleScale))]
  public class GoobSplit : MonoBehaviour {
    #region Methods

    public void OnMouseOver() {
      // check the mouse
      if (mHold || !Input.GetButtonDown("Mouse 0"))
        return;

      mHold = true;

      // set the position
      mMouseClickPosition = Input.mousePosition;

      // adjust to world coords
      mMouseClickPosition = mMainCamera.ScreenToWorldPoint(mMouseClickPosition);
    }

    public void Start() {
      // test requirements
      if (GetComponent<Movable>() == null || GetComponent<WobbleScale>() == null)
        throw new MissingComponentException("Movable is required but not attached");

      // get the camera
      mMainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Update() {
      CheckSplit();
      ScaleGoob();
    }

    /// <summary>
    ///   Checks the mouse and splits the goob if conditions are met.
    /// </summary>
    private void CheckSplit() {
      // check the mouse
      if (!mHold || !Input.GetButtonUp("Mouse 0"))
        return;

      mHold = false;

      // check if we are stationary
      if (GetComponent<Movable>().IsMoving)
        return;

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
      MovementDirection direction = Mathf.Abs(mouseDelta.x) > Mathf.Abs(mouseDelta.y)
                                      ? MovementDirection.Right
                                      : MovementDirection.Up;

      // start moving towards the mouse
      GetComponent<Movable>().Move(direction);

      // instruct the other one to move in other direction
      anotherGoob.GetComponent<Movable>()
        .Move(direction == MovementDirection.Right ? MovementDirection.Left : MovementDirection.Down);
    }

    /// <summary>
    ///   Scales the goob according to the mouse position.
    /// </summary>
    private void ScaleGoob() {
      var wobbleScale = GetComponent<WobbleScale>();

      // check if the mouse is holding the goob
      if (!mHold) {
        wobbleScale.TargetScale.x = 1f;
        wobbleScale.TargetScale.y = 1f;

        return;
      }

      // check if the goob is stationary
      var movable = GetComponent<Movable>();
      if (movable.IsMoving)
        return;

      // get mouse position
      Vector2 mousePosition = Input.mousePosition;

      // adjust to world coords
      mousePosition = mMainCamera.ScreenToWorldPoint(mousePosition);

      // get delta between the goob and the mouse
      Vector2 delta = mousePosition - (Vector2) transform.position;

      // adjust scale to 0 - 1
      delta.x = Mathf.Abs(delta.x) - MinHoldDistance;
      delta.y = Mathf.Abs(delta.y) - MinHoldDistance;
      delta = delta / (MaxHoldDistance - MinHoldDistance);

      // clamp
      delta.x = Mathf.Clamp01(delta.x);
      delta.y = Mathf.Clamp01(delta.y);

      // adjust scale to min - max hold scale
      delta *= (MaxHoldScale - MinHoldScale);
      delta.x += MinHoldScale;
      delta.y += MinHoldScale;

      // set the scale
      wobbleScale.TargetScale.x = delta.x;
      wobbleScale.TargetScale.y = delta.y;
    }

    #endregion

    #region Fields

    public float MaxHoldDistance = 2f;
    public float MaxHoldScale = 1.2f;
    public float MinHoldDistance = .5f;
    public float MinHoldScale = 1f;
    private bool mHold;
    private Camera mMainCamera;
    private Vector2 mMouseClickPosition;

    #endregion
  }

}