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
    Color flashColor = new Color(1f, 0f, 0f, 1f);



    void Start () {
        playerHealth = transform.Find("Player Health").gameObject;
        playerHealthImage = playerHealth.GetComponent<Image>();
        baseHealth = transform.Find("Base Health").gameObject;
        baseHealthImage = baseHealth.GetComponent<Image>();
        ammoBar = transform.Find("Ammo Bar").gameObject;
        ammoBarImage = ammoBar.GetComponent<Image>();
        Debug.Log(ammoBarImage);
	}
	
	void Update () {
	}

    public void UpdatePlayerHealth(float healthAmount, float healthMax) {
        float healthPercent = healthAmount / healthMax; 
        playerHealthImage.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
    }

    public void UpdateBaseHealth(float healthAmount, float healthMax) {
        float healthPercent = healthAmount / healthMax; 
        baseHealthImage.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
    }

    public void UpdateAmmoBar(float ammoAmount, float ammoMax) {
        if(ammoBarImage == null) {
            return;
        }
        float ammoPercent = ammoAmount / ammoMax;
        ammoBarImage.fillAmount = Mathf.Clamp(ammoPercent, 0f, 1f);
    }

}
