using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float healthPoints = 50.0f;
    public float healthTextTimeout = 4.0f;
    float healthTextTimer = 0;
    public Text enemyHealthText;

    public void ReceiveDamage(float damage) {
        //Debug.Log("Enemy received damage: " + damage);
        healthPoints -= damage;
        UpdateEnemyHealthText();
        healthTextTimer = healthTextTimeout;

        if(healthPoints <= 0) {
            Die();
        }
    }

    void UpdateEnemyHealthText() {
        enemyHealthText.text = "Enemy Health: " + Mathf.Clamp(Mathf.RoundToInt(healthPoints), 0.0f, healthPoints);
    }

    void ClearEnemyHealthText() {
        enemyHealthText.text = "";
    }

    void Die() {
        Debug.Log("Enemy dead");
        ClearEnemyHealthText();
        Destroy(gameObject);
    }

    void Update() {
        if(healthTextTimer >= 0) {
            healthTextTimer -= Time.deltaTime;
        }

        if(healthTextTimer <= 0 && healthTextTimer != -5) {
            ClearEnemyHealthText();
            healthTextTimer = -5;
        }
    }
}
