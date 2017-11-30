using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Help screen script
/// </summary>
public class AnimaticScript : MonoBehaviour
{

    /// <summary>
    /// On Pressing the Start Button, Load the Platformer_Float Scene.
    /// </summary>
    public void StartButton() {
        SceneManager.LoadScene("Platformer_Float");
    }
}