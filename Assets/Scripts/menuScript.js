#pragma strict
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
    else if(startReg) {
        SceneManager.LoadScene("Main12-01");
    }
    else if(startRegDark) {
        SceneManager.LoadScene("Main12-01");
    }
    else if(startInf) {
        SceneManager.LoadScene("Main12-01");
    }
    else if(startInfDark) {
        SceneManager.LoadScene("Main12-01");
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
            SceneManager.LoadScene("menuScene");
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)) { // Quit
            Application.Quit();
        }
    }
    else if(isStartSelectionMenu){
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            SceneManager.LoadScene("Main12-01"); // Start reg
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            SceneManager.LoadScene("Main12-01"); // Start reg dark
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            SceneManager.LoadScene("Main12-01"); // Start inf
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            SceneManager.LoadScene("Main12-01"); // Start inf dark
        }

        if(Input.GetKeyDown(KeyCode.Alpha5)) { // Quit
            Application.Quit();
        }
    }
    else {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            SceneManager.LoadScene("startGameMenu");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Application.Quit();
        }
    }

}
