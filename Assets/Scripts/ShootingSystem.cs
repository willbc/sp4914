using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingSystem : MonoBehaviour
{
    public int damage;
    public float shootingSpeed;
    private float shotTimer;
    GameObject m_target;
    EnemyHealth enemyTarget;
    EnemyMovement enemyTargetMovement;
    TrackingSystem tracker;

    public float speedReduction = 0.0f;
    public float speedRegenReduction = 0.0f;

    void Start() {
        tracker = transform.GetComponent<TrackingSystem>();
    }

    // Update is called once per frame
    void Update() {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0 && m_target != null && enemyTarget != null) {
            enemyTarget.ReceiveDamage(damage);
            enemyTargetMovement.ReduceSpeed(speedReduction, speedRegenReduction);
            if(shootingSpeed == 0) {
                tracker.ShowLine(true);
            }
            else {
                tracker.ShowLine(false);
            }
            shotTimer = shootingSpeed;
        }
        else {
            tracker.HideLine();
        }
    }

    public void SetTarget(GameObject target) {
        if(target != null) {
            m_target = target;
            enemyTarget = m_target.GetComponent<EnemyHealth>();
            enemyTargetMovement = m_target.GetComponent<EnemyMovement>();
        }
    }
}