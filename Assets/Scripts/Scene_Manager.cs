using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class Scene_Manager : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        if(VRDevice.isPresent)
        {
            GameObject hud = GameObject.Find("BasicHUD1");
            Vector3 oldPosition = hud.transform.position;
            //Vector3 newPostion = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z + 0.9f);
            //hud.transform.position = newPostion;
            RectTransform hudRect = hud.GetComponent<RectTransform>();
            hudRect.localScale = new Vector3(0.0015f, 0.0015f, 1f);
            //Debug.Log("VR DETECTED");
        }
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
