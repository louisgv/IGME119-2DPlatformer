using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Help screen script
/// </summary>
public class HelpScript : MonoBehaviour
{

    /// <summary>
    /// On clicking the Next Button, move to the PlayAnimatic scene.
    /// </summary>
    public void NextButton() {
        SceneManager.LoadScene("PlayAnimatic");
	}
}