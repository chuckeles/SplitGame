using UnityEngine;

namespace SplitGame {

  /// <summary>
  ///   Destroys an object when it is out of viewport.
  /// </summary>
  public class OffscreenDestroy : MonoBehaviour {
    #region Methods

    public void Update() {
      // get camera
      GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

      // get viewport position
      Vector3 pos = camera.GetComponent<Camera>().WorldToViewportPoint(transform.position);

      // check the position
      if (Mathf.Max(Mathf.Abs(pos.x), Mathf.Abs(pos.y)) > 1.2f)
        Destroy(gameObject);
    }

    #endregion
  }

}