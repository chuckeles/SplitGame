using System;
using UnityEngine;

/// <summary>
///   Stores a pointer to the main camera object.
/// </summary>
public class MainCameraSingleton : MonoBehaviour {
  #region Methods

  public void Start() {
    // set the singleton
    if (Instance)
      throw new Exception("More that one MainCamera object in the scene");
    Instance = gameObject;
  }

  #endregion

  #region Properties

  /// <summary>
  ///   Returns the singleton object.
  /// </summary>
  public static GameObject Instance { get; private set; }

  #endregion
}