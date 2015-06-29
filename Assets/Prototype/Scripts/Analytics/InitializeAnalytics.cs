using UnityEngine;

/// <summary>
///   Initializes Infinario analytics.
/// </summary>
public class InitializeAnalytics : MonoBehaviour {
  #region Methods

  public void Start() {
    Infinario = new Infinario.Infinario("174bedd6-1ca3-11e5-9063-b083fedeed2e");
  }

  #endregion

  #region Properties

  public Infinario.Infinario Infinario { get; private set; }

  #endregion
}