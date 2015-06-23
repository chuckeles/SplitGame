using UnityEngine;

/// <summary>
///   Destroyes a goob on touch.
/// </summary>
public class Destroyer : MonoBehaviour {
  #region Methods

  public void OnTriggerEnter2D(Collider2D collision) {
    // is it a goob?
    if (collision.tag == "Goob") {
      // destroy it
      Destroy(collision.gameObject);
    }

  }

  #endregion
}