using UnityEngine;
using System.Collections;

public class Crosshairs : MonoBehaviour {

    Rect crosshairRect;
    public Texture crosshairTexture;


	// Use this for initialization
	void Start () {
        float crosshairSize = Screen.width * 0.05f;
        crosshairRect = new Rect(Screen.width / 2 - crosshairSize / 2, Screen.height / 2 - crosshairSize / 2, crosshairSize, crosshairSize);
	}
	
    void OnGUI() {
        //GUI.DrawTexture(crosshairRect, crosshairTexture);
    }
}
