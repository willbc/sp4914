# CEN 4914: *Project Untitled*
---

## Table of Contents
1. [Project Overview](#project-overview)
2. [Player](#player)
   1. [Player Object](#player-object)
   2. [Player Controller](#player-controller)
   3. [Weapon Controller](#weapon-controller)
3. [Weapons](#weapons)
   1. [Base Weapon Controller](#base-weapon-controller)

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


---
<a name="player-controller"></a>
## Player Controller

The Player Controller manages the movement of the Player object and the main camera.

### _Controls_:

|Key|Action|
|---|------|
|<kbd>w</kbd> <kbd>s</kbd> <kbd>a</kbd> <kbd>d</kbd>|Move forward, backward, left, right|
|<kbd>Mouse</kbd>|Look|
|<kbd>shift</kbd>|Run|
|<kbd>space</kbd>|Jump|
|<kbd>Mouse Left</kbd>|Shoot|
|<kbd>Mouse Right</kbd>|Aim|
|<kbd>e</kbd>|Change Weapon|



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
