using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingSystem : MonoBehaviour
{
    public int damage;
    GameObject m_target;

    // Update is called once per frame
    void Update()
    {
        if (m_target != null)
        {
            EnemyHealth enemy = m_target.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                enemy.ReceiveDamage(damage);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }
}