﻿#pragma strict
import UnityEngine.SceneManagement;

var isPauseMenu = false;
var isQuit = false;
var startGame = false;
var menuScene = false;
var returnToGame = false;
var Player : GameObject;
var PauseMenu : GameObject;

var isStartSelectionMenu = false;
var startReg = false;
var startRegDark = false;
var startInf = false;
var startInfDark = false;


function OnMouseEnter() {
    //change text color
    // GetComponent.Renderer().material.color=Color.blue;
}

function OnMouseExit() {
    //change text color
    // GetComponent.Renderer().material.color=Color.white;
}

function OnMouseUp() {
    //is this quit
    if (isQuit == true) {
        //quit the game
        Application.Quit();
    }
    else if (startGame == true) {
        //start the game
        SceneManager.LoadScene("startGameMenu");
//        SceneManager.LoadScene("Main12-02");
//        Player.SetActive(true);
//        Time.timeScale = 1.0;
//        PauseMenu.SetActive(false);
    }
    else if (menuScene == true) {
        //start the game
        SceneManager.LoadScene("menuScene");
    }
    else if(returnToGame) {
        //SceneManager.LoadScene("Main12-02");
        Player.SetActive(true);
        Time.timeScale = 1.0;
        PauseMenu.SetActive(false);
    }
    else if(startReg) {
        SceneManager.LoadScene("Main_Final");
    }
    else if(startRegDark) {
        SceneManager.LoadScene("Main_Final_Dark");
    }
    else if(startInf) {
        SceneManager.LoadScene("Main_Final_Inf");
    }
    else if(startInfDark) {
        SceneManager.LoadScene("Main_Final_Inf_Dark");
    }
    else {
        //load level
        SceneManager.LoadScene("menuScene");
    }
}

function Update() {
    Debug.Log("update scene");
    //quit game if escape key is pressed
    if (Input.GetKey(KeyCode.Tab)) { 
        //SceneManager.LoadScene("PauseMenu");
        //Application.Quit();
    }

    if(isPauseMenu) {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            if(isPauseMenu) { // Return to game
                Player.SetActive(true);
                Time.timeScale = 1.0;
                PauseMenu.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) { // Return to menu
            Time.timeScale = 1.0;
            SceneManager.LoadScene("menuScene");
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)) { // Quit
            Application.Quit();
        }
    }
    else if(isStartSelectionMenu){
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            Time.timeScale = 1.0;
            SceneManager.LoadScene("Main_Final"); // Start reg
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Time.timeScale = 1.0;
            SceneManager.LoadScene("Main_Final_Dark"); // Start reg dark
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            Time.timeScale = 1.0;
            SceneManager.LoadScene("Main_Final_Inf"); // Start inf
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            Time.timeScale = 1.0;
            SceneManager.LoadScene("Main_Final_Inf_Dark"); // Start inf dark
        }

        if(Input.GetKeyDown(KeyCode.Alpha5)) { // Quit
            Application.Quit();
        }
    }
    else {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            Time.timeScale = 1.0;
            SceneManager.LoadScene("startGameMenu");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Application.Quit();
        }
    }

}
