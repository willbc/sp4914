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
    TrackingSystem tracker;

    void Start() {
        tracker = transform.GetComponent<TrackingSystem>();
    }

    // Update is called once per frame
    void Update() {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0 && m_target != null && enemyTarget != null) {
            enemyTarget.ReceiveDamage(damage);
            tracker.ShowLine();
            shotTimer = shootingSpeed;
        }
    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
        enemyTarget = m_target.GetComponent<EnemyHealth>();
    }
}