using UnityEngine;

/// <summary>
///   Handles the scale of the object in a wobbly style.
/// </summary>
public class WobbleScale : MonoBehaviour {
  #region Methods

  public void Start() {
    TargetScale = transform.localScale;
  }

  public void Update() {
    // get delta
    Vector2 delta = TargetScale - (Vector2) transform.localScale;

    // add to the speed
    ScaleSpeed += delta * ScaleSpeedChangePercent;

    // apply friction
    ScaleSpeed *= (1f - ScaleSpeedFriction);

    // apply to the scale
    transform.localScale += (Vector3) ScaleSpeed * Time.deltaTime;
  }

  #endregion

  #region Fields

  public float ScaleSpeedFriction = 0.05f;
  public float ScaleSpeedChangePercent = 0.1f;
  public Vector2 TargetScale = new Vector2(1f, 1f);
  private Vector2 ScaleSpeed;

  #endregion
}