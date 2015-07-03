using UnityEngine;

/// <summary>
///   Handles the scale of the object in a wobbly style.
/// </summary>
public class WobbleScale : MonoBehaviour {
  #region Methods

  public void Start() {
    // set target object
    Transform sprite = transform.FindChild("Sprite");
    mObjectToScale = sprite ? sprite.gameObject : gameObject;
  }

  public void Update() {
    // get delta
    Vector2 delta = TargetScale - (Vector2) mObjectToScale.transform.localScale;

    // add to the speed
    ScaleSpeed += delta * ScaleSpeedChangePercent;

    // apply friction
    ScaleSpeed *= 1f - ScaleSpeedFriction;

    // apply to the scale
    mObjectToScale.transform.localScale += (Vector3) ScaleSpeed * Time.deltaTime;
  }

  #endregion

  #region Fields

  public float ScaleSpeedFriction = 0.05f;
  public float ScaleSpeedChangePercent = 0.1f;
  public Vector2 TargetScale = new Vector2(1f, 1f);
  private GameObject mObjectToScale;
  private Vector2 ScaleSpeed;

  #endregion
}