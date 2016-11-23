using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            //SceneManager.LoadScene("PauseMenu");
            // Show Pause Menu
            Player.SetActive(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
	}
}
