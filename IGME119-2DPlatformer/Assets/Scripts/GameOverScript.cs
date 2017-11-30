using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{

    /// <summary>
    /// On pressing the play again button, load the Platformer_Float scene
    /// </summary>
    public void PlayAgainButton() {
        SceneManager.LoadScene("Platformer_Float");
    }

    /// <summary>
    /// On pressing the back button, load the title_menu scene
    /// </summary>
    public void BackButton() {
        SceneManager.LoadScene("title_menu");
    }
}