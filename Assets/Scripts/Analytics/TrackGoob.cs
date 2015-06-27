using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Tracks all goob events.
/// </summary>
public class TrackGoob : MonoBehaviour {
  #region Methods

  /// <summary>
  ///   Tracks the destroy event.
  /// </summary>
  public void TrackDestroy() {
    MainCameraSingleton.Instance.GetComponent<InitializeAnalytics>()
      .Infinario.Track("goob", new Dictionary<string, object> {
        {"action", "destroy"}
      });
  }

  /// <summary>
  ///   Tracks the merge event.
  /// </summary>
  public void TrackMerge() {

    MainCameraSingleton.Instance.GetComponent<InitializeAnalytics>()
      .Infinario.Track("goob", new Dictionary<string, object> {
        {"action", "merge"}
      });
  }

  /// <summary>
  ///   Tracks the split event.
  /// </summary>
  public void TrackSplit(string type) {

    MainCameraSingleton.Instance.GetComponent<InitializeAnalytics>()
      .Infinario.Track("goob", new Dictionary<string, object> {
        {"action", "split"},
        {"type", type}
      });
  }

  #endregion
}