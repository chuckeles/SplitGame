using UnityEngine;

/// <summary>
///   On the trigger stops one animation and starts another one.
/// </summary>
public class Trigger : MonoBehaviour {
  #region Methods

  public void OnTriggerEnter2D(Collider2D collision) {
    // check if it is a goob
    if (collision.tag == "Goob") {
      // update animations
      if (AnimationToStop)
        AnimationToStop.CrossFade("End");

      if (AnimationToStart)
        AnimationToStart.Play();
    }
  }

  #endregion

  #region Fields

  public Animation AnimationToStart;
  public Animation AnimationToStop;

  #endregion
}