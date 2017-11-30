using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// Title screen script
/// </summary>
public class TitleScript : MonoBehaviour
{

    /// <summary>
    /// On Clicking the Exit button, Quit the game.
    /// </summary>
    public void ExitButton() {
        Application.Quit();
    }

    /// <summary>
    /// On Clicking the Next Button, proceed to the help menu.
    /// </summary>
    public void NextButton() {
        SceneManager.LoadScene("help_menu");
    }
}