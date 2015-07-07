using SplitGame;
using UnityEngine;

/// <summary>
///   Manages the behaviour of a Finish. Finish can be activated by a goob and changes sprite when activated.
/// </summary>
[RequireComponent(typeof (SpriteRenderer))]
public class Finish : MonoBehaviour {
  #region Methods

  public void Start() {
    // test requirements
    if (GetComponent<SpriteRenderer>() == null)
      throw new MissingComponentException("SpriteRenderer is required");
  }

  public void Update() {
    // check goobs
    Collider2D col = Physics2D.OverlapPoint(transform.position);

    if (col && col.tag == "Player") {
      // goob is on me
      if (!col.GetComponent<Movable>().IsMoving) {
        // stationary goob on me, activate
        Activated = true;
        GetComponent<SpriteRenderer>().sprite = OnSprite;
      }
    }
    else {
      // no goob around, deactivate
      Activated = false;
      GetComponent<SpriteRenderer>().sprite = OffSprite;
    }
  }

  #endregion

  #region Properties

  public bool Activated { get; private set; }

  #endregion

  #region Fields

  public Sprite OffSprite;
  public Sprite OnSprite;

  #endregion
}