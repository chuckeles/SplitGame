using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
  /// <param name="type">The type of split, must be either "horizontal" or "vertical"</param>
  public void TrackSplit(string type) {
    Assert.IsTrue(type == "horizontal" || type == "vertical", "Unknown split type");

    MainCameraSingleton.Instance.GetComponent<InitializeAnalytics>()
      .Infinario.Track("goob", new Dictionary<string, object> {
        {"action", "split"},
        {"type", type}
      });
  }

  #endregion
}