## This is the repo for the current RIT IGME-119(2D Animation and Asset Production) Final Project 2D Platformer Game.

 The goal of this README is to provide an FAQ/Guide on how to take advantage of the features provided by this skeleton to create your own customized game for your final project.

## Table of Contents
  0. Contributions / Issues
  1. Game Basics
  2. Texture Replacement
  3. Animations
  4. Jump Height
  5. Movement Speed
  6. Automatic Platform Spawning
  7. Platform Falling
  8. Menu Button Placement
  9. Player-centered Camera*
  10. Infinite Ground

## Contributions / Issues
  If you notice anything about the game that seems broken, or can think about any other way to better this game, please feel free to open an issue on Github. You can find instructions on how to do this [here](https://help.github.com/articles/creating-an-issue/). Think you could fix the issue yourself, or want to add a feature you think future players will want? Your help is welcome and wanted! Simply [fork](https://help.github.com/articles/fork-a-repo/) this repository, and submit a [pull request](https://help.github.com/articles/creating-a-pull-request-from-a-fork/) once you've updated your fork. We'll look through your update and if it looks good, we'll make it a part of the game!

## Game Basics
  The game is, by default, an auto-scrolling 2D Platformer.
  * Press Space or Left-Click to Attack.
  * Press Up to Jump.
  * Press Left/Right to move Left/Right.

## Texture Replacement
  The majority of the class you are taking is based around asset production. As such, the majority of your work (if not all) will consist of replacing textures in this game. The majority of textures are found in the *Assets/Resources/Textures* folder. There are instructions on replacing the assets in the highest level directory of the project.

## Animations
  Animations are preprogrammed into the game, and only require you to fill out the sprite sheet in the *Textures* folder to work. There are 8 Animations, each consisting of 8 frames, broken up as the 8 rows of the sprite sheet. The animations are, in order, Player_Idle, Player_Jump, Player_Walk, Player_Attack, Player_Injury, Enemy_Walk, Enemy_Attack, Enemy_Injury. This is detailed in the *Spritesheet_Outline.png* file in the Textures folder. I would recommend placing this outline as the background layer of a .psd file, so you can place your assets directly over it before replacing the sprite sheet.

## Jump Height
  Think the player is jumping too high? too low? You can change that!
  1. Open the *Platformer_Float* scene in the *Scenes* folder.
  2. In the Hierarchy, click the arrow next to the object named *Layer* to see its children.
  3. In the Hierarchy, click the arrow next to the object named *4 - player* to see its children.
  4. In the Hierarchy, click on the object named *hero*
  5. In the Inspector, scroll down to the Component titled *Simple Platform Controller*, and select the box next to the words *Jump Force*
  6. Increasing this number will make the player jump higher. Decreasing this number will make the player jump lower. Alter this number as you see fit until you are satisfied with how your player jumps!
  7. Note: If you want the player to fall faster, you can find the *Rigidbody 2D* Component on the same object, and increase the *Gravity Scale*. The higher the *Gravity Scale*, the faster the player will fall.

## Movement Speed
  Think the player is moving too fast? too slow? You can change that!
  1. Follow steps 1-4 in the __Jump Height__ section
  5. In the Inspector, scroll down to the Script Component titled *Simple Platform Controller*, and select the box next to the words *Jump Force*
  6. Increasing this number will make the player jump higher. Decreasing this number will make the player jump lower. Alter this number as you see fit until you are satisfied with how your player jumps!
  7. Note: If you want the player to fall faster, you can find the *Rigidbody 2D* Component on the same object, and increase the *Gravity Scale*. The higher the *Gravity Scale*, the faster the player will fall.

## Automatic Platform Spawning
  Platforms will spawn automatically by default. Want to turn this off? You can do that!
  1. Open the *Platformer_Float* scene in the *Scenes* folder.
  2. In the Hierarchy, click on the object named *SpawnManager*
  3. In the inspector, scroll down to the Script Component titled *Spawn Manager*, and click the checkbox next to *Should Spawn Platforms*
  4. Platforms will now stop spawning automatically. Want to turn this back on? Just turn the same checkbox back on!

## Platform Falling
  Platforms will fall automatically by default. Want to turn this off? You can do that!
  1. Open the *Platformer_Float* scene in the *Scenes* folder.
  2. In the Hierarchy, click the arrow next to the object named *Layer* to see its children.
  3. In the Hierarchy, click the arrow next to the object named *5 - Ground* to see its children.
  4. In the Hierarchy, click on the object named *Ground*
  5. In the Inspector, scroll down to the Script Component titled *Platform Fall*, and click the checkbox next to  *Should Fall*
  6. Note: If you want Platforms to default to not falling, scroll to the top of the inspector and click *Apply*
  7. Note: This setting can be changed on a platform by platform basis. You can have some platforms fall, and others not.

## Menu Button Placement
  Buttons are placed in the game using the Unity Canvas. Want to move the buttons in the game? You can do that!
  1. Open the scene whose buttons you want to move.
  2. In the inspector, click the arrow next to the object named *Canvas* to see its children.
  3. In the inspector, double-click the object named *Canvas* to focus on it.
  4. Select the button you want to move on the screen, and move it as you normally would any other object in Unity.
  5. Note: If you are trying to move the buttons displayed on death in the *Platformer_Float* scene, do the following after step 3
    * At the top of the inspector, check the checkbox to the left of the word *Canvas*
    * When done moving your button, be sure to uncheck this checkbox so the buttons are hidden until death.

## Player-centered Camera*
  Want a more classic Platformer, where the camera follows the player? You can do that!
  1. Follow steps 1-4 in the __Jump Height__ section
  2. In the Inspector, scroll down to the Component titled *Simple Platform Controller*, and check the checkbox next to the words *Camera Follow*
  3. The Camera will now follow the player. If you want to disable this feature, simply uncheck the same checkbox.
  4. *NOTE: This feature is currently in development. there are known issues with the parallax layers relating to this mode that are currently being worked on.

## Infinite Ground
  Want to spawn an infinite ground at the bottom of the screen? You can do that!
  1. Open the *Platformer_Float* scene in the *Scenes* folder.
  2. In the Hierarchy, click on the object named *DynamicGroundSpawnManager*
  3. In the inspector, scroll down to the Script Component titled *Spawn Manager*, and check the checkbox next to *Should Spawn Platforms*
  4. The ground will now dynamically spawn automatically. Want to turn this back off? Just uncheck the same checkbox!
