#pragma strict
import UnityEngine.SceneManagement;

var isQuit = false;
var startGame = false;
var menuScene = false;
var returnToGame = false;
var Player : GameObject;
var PauseMenu : GameObject;


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
    if (isQuit==true) {
        //quit the game
        Application.Quit();
    }
    else if (startGame == true) {
        //start the game
        SceneManager.LoadScene("Main12-01");
    }
    else if (menuScene == true) {
        //start the game
        SceneManager.LoadScene("menuScene");
    }
    else if(returnToGame) {
        //SceneManager.LoadScene("Main11-21");
        Player.SetActive(true);
        Time.timeScale = 1.0;
        PauseMenu.SetActive(false);
    }
    else {
        //load level
        SceneManager.LoadScene("menuScene");
    }
}

function Update() {
    //quit game if escape key is pressed
    if (Input.GetKey(KeyCode.Tab)) { 
        //SceneManager.LoadScene("PauseMenu");
        //Application.Quit();
    }
}
