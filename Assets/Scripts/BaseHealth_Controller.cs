using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BaseHealth_Controller : MonoBehaviour
{

    HUDController HUD;
    int baseHealth;
    int baseMaxHealth;
    bool attacked = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            baseHealth--;
            other.GetComponent<EnemyHealth>().Explode();
            HUD.UpdateBaseHealth(baseHealth, baseMaxHealth);
            if (baseHealth <= 0)
            {
                Time.timeScale = 0.0f;
                SceneManager.LoadScene("GameOverLose");
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        baseMaxHealth = 20;
        baseHealth = baseMaxHealth;
        HUD = GameObject.Find("BasicHUD1").GetComponent<HUDController>();
        HUD.UpdateBaseHealth(baseHealth, baseMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

