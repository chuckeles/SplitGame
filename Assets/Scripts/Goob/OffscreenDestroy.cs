using UnityEngine;

/// <summary>
///   Destroys an object when it is out of viewport.
/// </summary>
public class OffscreenDestroy : MonoBehaviour {
  #region Methods

  public void Update() {
    // get viewport position
    Vector3 pos = MainCameraSingleton.Instance.GetComponent<Camera>().WorldToViewportPoint(transform.position);

    // check the position
    if (Mathf.Max(Mathf.Abs(pos.x), Mathf.Abs(pos.y)) > 1.2f)
      Destroy(gameObject);
  }

  #endregion
}