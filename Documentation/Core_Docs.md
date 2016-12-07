# CEN 4914: *3D FPS TD VR Game*
---

## Table of Contents
1. [Project Overview](#project-overview)
2. [Player](#player)
   1. [Player Object](#player-object)
   2. [Player Controller](#player-controller)
   3. [Weapon Controller](#weapon-controller)
3. [Weapons](#weapons)
   1. [Base Weapon Controller](#base-weapon-controller)
4. [Player HUD](#player-hud)
5. [Virtual Reality](#vr)
6. [Game Modes](#game-modes)
7. [Towers](#towers)
---

---
<a name="project-overview"></a>
## Project Overview
* Basic concept
* Requirements
* Specifications
* These are just notes of what to put in later

### *Documentation*
* Written in GitHub Markdown


---

---
<a name="player"></a>
# Player

---
<a name="player-object"></a>
## Player Object

The player object contains the main first-person camera which has a child camera (Gun Camera) set to only view the currently equipped weapon by way of a culling mask which only views the 'Gun' layer.

The gun model is a child of the Gun Camera.

The Player object has the following script components:
* Player_Controller.cs
* Player_Weapon_Controller.cs
* Player_Inventory_Controller.cs


---
<a name="player-controller"></a>
## Player Controller

The Player Controller manages the movement of the Player object and the main camera.

The Main Camera game object has the Ray_Controller script which manages the raycast creation and direction for both the player's weapon and the tower construction.

### _Controls_:

|Key|Action|
|---|------|
|<kbd>w</kbd> <kbd>s</kbd> <kbd>a</kbd> <kbd>d</kbd>|Move forward, backward, left, right|
|<kbd>Mouse</kbd>|Look|
|<kbd>shift</kbd>|Run|
|<kbd>space</kbd>|Jump|
|<kbd>Mouse Left</kbd>|Shoot|
|<kbd>Mouse Right</kbd>|Build/Upgrade Tower|
|<kbd>q</kbd>|Change Tower|
|<kbd>Tab</kbd>|Pause Game|



---
<a name="weapon-controller"></a>
## Weapon Controller

The Player Weapon Controller manages the player's weapon inventory and the controls to interact with the weapon. The script takes an array of weapon objects each expected to have a Base_Weapon_Controller script which manages the specific stats of the weapon and manages the actual firing of the weapon.




---

---
<a name="weapons"></a>
# Weapons

---
<a name="base-weapon-controller"></a>
## Base Weapon Controller

This controller implements the `Fire()` function which can handle either a projectile-based weapon or a Raycast shot. If an object is hit, it calls the enemy's `ReceiveDamage()` function implemented on the enemy's 'EnemyHealth' component. The weapon effects are also handled in this function.

All the stats of a weapon are public variables in this script so the 'Base Weapon' can essentially be used as an abstracted weapon which can be used to make prefabs of specific weapons once the stats are set.

This script also handles the weapons ammo amount and it's recharging.




---

---
<a name="player-hud"></a>
# Player HUD

The HUD has three UI image bars to display the current ammo amount, player health, and base health. The `fillAmount` is adjusted (given a value between 0 and 1) to represent the values.
This is done in the `HUDController.cs` script which is attached to the `Basic HUD 1` gameobject in the scene. The HUDController is accessed by doing a global search for the hardcoded name 'Basic HUD 1' on to which you can call the following functions:
* UpdatePlayerHealth(float healthAmount, float healthMax)
* UpdateBaseHealth(float healthAmount, float healthMax)
* UpdateAmmoBar(float ammoAmount, float ammoMax)

In each function a ratio is determined between the two inputs and the appropriate bar has its fill amount adjusted.





---

---
<a name="vr"></a>
# Virtual Reality

To configure the HUD and menus to work in VR, all UI elements are in world space rather than screen space. In addition, the Scene_Manager script has a block of code run on start that detects whether a VR device is connected and makes additional changes as necessary. One such change is adjusting the position of the HUD so that it appears within the reasonable field of view as tested on the Oculus Rift DK2.

When playing the game via a VR device, rather than aiming to select menu options, the numeric keys are configured to select the specified options.





---

---
<a name="game-modes"></a>
# Game Modes

Four game modes are included in the final version of the game. The wave controller can be configured to either present the 'win' scenario once the final enemy is destroyed in the 20th wave, or it can continue to produce increasingly difficult waves until the player is defeated in what is referred to as 'Infinite Mode'. Paired with both of the wave modes, the scene can be configured in the wave controller to change the visual style from a well-lit map to a dark scene where a majority of the light is added to the scene via glowing enemies.

While not user-configurable in the final version of the project, there is also a `difficulty` variable in the wave controller that acts as a multiplier on the stats of enemies, making them more or less challenging.





---

---
<a name="towers"></a>
# Towers

Each tower type is split into three separate prefabs, each at a different level. The game updates the prefab as the tower is upgraded which comes with beneficial increases in stats.

## Shock Tower
The shock tower is a single-target tower that inflicts damage to the enemies in range of its collider. Upgrading the tower loads a prefab with a slightly different look and higher values for variables such as damage. The tower shoots a line render at the enemy every time it attacks a target. The changeable values for this tower are: Damage, Shooting speed, and radius (attack range).
### Stats
* Damage: High
* Attack speed: Average
* Range: Average
* Effect: None
* Cost: Average

## Slow Tower
The slow tower is a single-target tower that slows enemies it hits and leaves the enemy with a slow that regenerates slowly back to normal speed. Upgrading the tower loads a prefab with a slightly different look and higher values for variables such as speed reduction. The tower continually shoots a line render at the enemy in range and looks like a laser beam causing a slow effect. The changeable values for this tower are: speed reduction, speed regen reduction, and radius (attack range).
### Stats
* Damage: None
* Attack speed: High
* Range: Average
* Effect: Strong slow
* Cost: Low

## Bash Tower
The bash tower is a multi-target tower that hits all enemies in the attack range. On hit, it inflicts damage and a short slow as if the enemies were hit by an earthquake. Upgrading the tower loads a prefab with a slightly different look and higher values for variables such as damage. The tower lights up the ground where its range of attack is on damaging at least one enemy. The changeable values for this tower are: damage, attack speed, speed reduction, and speed regen reduction.

### Stats
* Damage: Low
* Attack speed: Low
* Range: Average
* Effect: Weak slow
* Cost: High
