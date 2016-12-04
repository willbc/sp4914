using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth;
    float health;
    public float healthTextTimeout = 4.0f;
    float healthTextTimer = 0;
    public Text enemyHealthText;
    GameObject healthBar;
    private Image healthBarImage;

    Player_Inventory_Controller playerInventory;
    int moneyValue = 25;

    int attack = 10;

    void Start()
    {
        health = maxHealth;
        healthBar = transform.Find("EnemyCanvas/HealthBG/Health").gameObject;
        Debug.Log(healthBar);
        healthBarImage = healthBar.GetComponent<Image>();
        Debug.Log(healthBarImage);
        UpdateEnemyHealthBar();
        playerInventory = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player_Inventory_Controller>();
    }

    public void ReceiveDamage(float damage)
    {
        //Debug.Log("Enemy received damage: " + damage);
        health -= damage;
        UpdateEnemyHealthBar();
        //UpdateEnemyHealthText();
        //healthTextTimer = healthTextTimeout;

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateEnemyHealthText()
    {
        enemyHealthText.text = "Enemy Health: " + Mathf.Clamp(Mathf.RoundToInt(health), 0.0f, health);
    }

    void UpdateEnemyHealthBar()
    {
        //Debug.Log("update health bar");
        healthBarImage.fillAmount = health / maxHealth;
    }

    void ClearEnemyHealthText()
    {
        enemyHealthText.text = "";
    }

    void Die()
    {
        Debug.Log("Enemy dead");
        //ClearEnemyHealthText();
        playerInventory.EarnMoney(moneyValue);
        Destroy(gameObject);
    }

    public void Explode()
    {
        Debug.Log("Enemy exploded");    
        Destroy(gameObject);
    }

    void Update()
    {
        //        if(healthTextTimer >= 0) {
        //            healthTextTimer -= Time.deltaTime;
        //        }
        //
        //        if(healthTextTimer <= 0 && healthTextTimer != -5) {
        //            ClearEnemyHealthText();
        //            healthTextTimer = -5;
        //        }
    }
    public int Attack()
    {
        return attack;
    }
}
