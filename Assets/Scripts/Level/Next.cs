using UnityEngine;

public class Next : MonoBehaviour {
  #region Methods

  public void GoToNextLevel() {
    // check the finish blocks
    GameObject[] finishBlocks = GameObject.FindGameObjectsWithTag("Finish");

    var weCanGo = true;
    foreach (GameObject finish in finishBlocks) {
      if (!finish.GetComponent<Finish>().IsActivated) {
        // this one is not active
        weCanGo = false;
        break;
      }
    }

    // transition
    if (weCanGo) {
      // track event
      var trackComplete = GetComponent<TrackComplete>();
      if (trackComplete)
        trackComplete.Track();

      // load next level
      Application.LoadLevel(Application.loadedLevel + 1);
    }
  }

  #endregion
}