#pragma strict
import UnityEngine.SceneManagement;

var isQuit = false;
var startGame = false;
var menuScene = false;


function OnMouseEnter(){
    //change text color
    // GetComponent.Renderer().material.color=Color.blue;
}

function OnMouseExit(){
    //change text color
    // GetComponent.Renderer().material.color=Color.white;
}

function OnMouseUp(){
    //is this quit
    if (isQuit==true) {
        //quit the game
        Application.Quit();
    }
    else if (startGame == true) {
        //start the game
        SceneManager.LoadScene("Main11-6");
    }
    else if (menuScene == true) {
        //start the game
        SceneManager.LoadScene("menuScene");
    }
    else {
        //load level
        SceneManager.LoadScene("menuScene");
    }
}

function Update(){
    //quit game if escape key is pressed
    if (Input.GetKey(KeyCode.Escape)) { Application.Quit();
    }
}
