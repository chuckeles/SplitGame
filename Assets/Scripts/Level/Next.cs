using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour {
  #region Methods

  /// <summary>
  ///   Checks the Finish blocks and goes to the next level.
  /// </summary>
  public void GoToNextLevel() {
    // transition
    if (mWeCanGo) {
      // load next level
      Application.LoadLevel(Application.loadedLevel + 1);
    }
  }

  public void Update() {
    // check the finish blocks
    GameObject[] finishBlocks = GameObject.FindGameObjectsWithTag("Finish");

    mWeCanGo = true;
    foreach (GameObject finish in finishBlocks) {
      if (!finish.GetComponent<Finish>().IsActivated) {
        // this one is not active
        mWeCanGo = false;
        break;
      }
    }

    // update button color
    var button = GetComponent<UnityEngine.UI.Button>();
    ColorBlock colors = button.colors;

    if (mWeCanGo) {
      colors.normalColor = ReadyButtonColor;
      colors.highlightedColor = ReadyButtonColor;
      colors.pressedColor = Color.Lerp(ReadyButtonColor, Color.black, 0.4f);
    }
    else {
      colors.normalColor = NormalButtonColor;
      colors.highlightedColor = NormalButtonColor;
      colors.pressedColor = Color.Lerp(NormalButtonColor, Color.black, 0.4f);
    }

    button.colors = colors;

    // disable button
    button.interactable = mWeCanGo;
  }

  #endregion

  #region Fields

  public Color NormalButtonColor;
  public Color ReadyButtonColor;
  private bool mWeCanGo;

  #endregion
}