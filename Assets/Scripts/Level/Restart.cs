using UnityEngine;

public class Restart : MonoBehaviour {
  #region Methods

  public void RestartLevel() {
    Application.LoadLevel(Application.loadedLevel);
  }

  #endregion
}