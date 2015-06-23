using UnityEngine;

/// <summary>
///   Destroyes a goob on touch.
/// </summary>
public class Destroyer : MonoBehaviour {
  #region Methods

  public void OnTriggerEnter2D(Collider2D collision) {
    // is it a goob?
    if (collision.tag == "Goob") {
      // spawn blood
      GameObject blood = Instantiate(Blood);
      blood.transform.parent = GameObject.Find("Blood").transform;
      blood.transform.position = collision.gameObject.transform.position;

      // destroy it
      Destroy(collision.gameObject);
    }

  }

  #endregion

  #region Fields

  public GameObject Blood;

  #endregion
}