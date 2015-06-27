using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Tracks the restart level event.
/// </summary>
public class TrackRestart : MonoBehaviour {
  #region Methods

  /// <summary>
  ///   Sends the tracked event.
  /// </summary>
  public void Track() {
    MainCameraSingleton.Instance.GetComponent<InitializeAnalytics>()
      .Infinario.Track("level", new Dictionary<string, object> {
        {"action", "restart"},
        {"name", Application.loadedLevelName}
      });
  }

  #endregion
}