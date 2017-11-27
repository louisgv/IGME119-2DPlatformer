using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
public class TitleScript : MonoBehaviour
{
	/// <summary>
	/// The next button skin
	/// </summary>
	private GUISkin nextBtn;
	private GUISkin exitBtn;

	void Start()
	{
		//call this during start to load the resource for the button(s) you wish to create skins for
		nextBtn = Resources.Load ("Next_Button_GUI") as GUISkin;
		exitBtn = Resources.Load ("EndGame_Button_Skin") as GUISkin;
	}

	void OnGUI()
	{
		//change the next gui function called
		GUI.skin = nextBtn;

		const int buttonWidth = 120;
		const int buttonHeight = 60;

        // Determine the next button's place on screen
        // Change these X and Y variables to place the button where you want!
        float buttonX = Screen.width / 2 - (buttonWidth / 2);
        float buttonY = (Screen.height) - (buttonHeight * 4);
		Rect buttonRect1 = new Rect(
			buttonX,
			buttonY,
			buttonWidth,
			buttonHeight
			);
		
		// next button
		if(GUI.Button(buttonRect1,""))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("help_menu");
		}

		GUI.skin = exitBtn;

        // Determine the exit button's place on screen
        // Change these X and Y variables to place the button where you want!
        float button2X = Screen.width / 2 - (buttonWidth / 2);
        float button2Y = (Screen.height) - (buttonHeight * 2);
		Rect buttonRect2 = new Rect(
			button2X,
			button2Y,
			buttonWidth,
			buttonHeight
			);
		
		// next button
		if(GUI.Button(buttonRect2,""))
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.Quit();
		}
	}
}