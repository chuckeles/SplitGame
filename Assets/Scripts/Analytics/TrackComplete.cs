using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Tracks the level complete event.
/// </summary>
public class TrackComplete : MonoBehaviour {
  #region Methods

  /// <summary>
  ///   Sends the tracked event.
  /// </summary>
  public void Track() {
    MainCameraSingleton.Instance.GetComponent<InitializeAnalytics>()
      .Infinario.Track("level", new Dictionary<string, object> {
        {"action", "complete"},
        {"name", Application.loadedLevelName},
        {"time", Time.timeSinceLevelLoad}
      });
  }

  #endregion
}