using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    GameObject playerHealth;
    GameObject baseHealth;
    GameObject ammoBar;

    Image playerHealthImage;
    Image baseHealthImage;
    Image ammoBarImage;


	void Start () {
        playerHealth = transform.Find("Player Health").gameObject;
        playerHealthImage = playerHealth.GetComponent<Image>();
        baseHealth = transform.Find("Base Health").gameObject;
        baseHealthImage = baseHealth.GetComponent<Image>();
        ammoBar = transform.Find("Ammo Bar").gameObject;
        ammoBarImage = ammoBar.GetComponent<Image>();
        Debug.Log(ammoBarImage);
        //ammoBarImage.fillAmount = Mathf.Clamp(0.5f, 0f, 1f);
	}
	
	void Update () {
        //UpdatePlayerHealth(100, 50);
	}

    public void UpdatePlayerHealth(float healthAmount, float healthMax) {
        float healthPercent = healthAmount / healthMax; 
        playerHealthImage.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
    }

    public void UpdateAmmoBar(float ammoAmount, float ammoMax) {
        if(ammoBarImage == null) {
            return;
        }
        float ammoPercent = ammoAmount / ammoMax;
        ammoBarImage.fillAmount = Mathf.Clamp(ammoPercent, 0f, 1f);
    }

}
