﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingSystem : MonoBehaviour
{
    public int damage;
    public float shootingSpeed;
    public float shotSoundSpeed;
    private float shotTimer;
    private float shotSoundTimer;
    GameObject m_target;
    EnemyHealth enemyTarget;
    EnemyMovement enemyTargetMovement;
    TrackingSystem tracker;
    List<GameObject> m_targets;
    bool multiTargetOn;
    AudioSource shotSound;

    public float speedReduction = 1.0f;
    public float speedRegenReduction = 1.0f;

    public Light attackLight;
    bool enemyInRange = false;

    void Start() {
        tracker = transform.GetComponent<TrackingSystem>();
        shotSound = GetComponent<AudioSource>();
        multiTargetOn = false;
        if(attackLight != null) {
            attackLight.enabled = false;
        }

        if(shootingSpeed != 0) {
            shotSoundSpeed = shootingSpeed;
        }
    }

    // Update is called once per frame
    void Update() {
        shotTimer -= Time.deltaTime;
        shotSoundTimer -= Time.deltaTime;
        if (!multiTargetOn) {
            if (shotTimer <= 0 && m_target != null && enemyTarget != null) {
                if (shotSound != null && shotSoundTimer <= 0) {
                    shotSound.Play();
                    shotSoundTimer = shotSoundSpeed;
                    Debug.Log("SHOT SOUND");
                }
                enemyTarget.ReceiveDamage(damage);
                enemyTargetMovement.ReduceSpeed(speedReduction, speedRegenReduction);
                if (shootingSpeed == 0) {
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
        else {
            if (shotTimer <= 0 && m_targets != null) {
                for (int i = 0; i < m_targets.Count; i++) {
                    if (m_targets[i] != null) {
                       enemyInRange = true;
                       break;
                    }
                }
                if (enemyInRange) {
                    for (int i = 0; i < m_targets.Count; i++) {
                        if (m_targets[i] != null) {
                            m_target = m_targets[i];
                            enemyTarget = m_target.GetComponent<EnemyHealth>();
                            enemyTargetMovement = m_target.GetComponent<EnemyMovement>();
                            enemyTarget.ReceiveDamage(damage);
                            enemyTargetMovement.ReduceSpeed(speedReduction, speedRegenReduction);
                        }
                    }
                    shotTimer = shootingSpeed;
                    attackLight.enabled = true;
                    if (shotSound != null && shotSoundTimer <= 0) {
                        shotSound.Play();
                        shotSoundTimer = shotSoundSpeed;
                        Debug.Log("SHOT SOUND");
                    }
                }
            }
            else if (shotTimer<= 0.6 && attackLight.enabled) {
                attackLight.enabled = false;
            }
            enemyInRange = false;
        }
    }

    public void SetTarget(GameObject target) {
        if(target != null) {
            m_target = target;
            enemyTarget = m_target.GetComponent<EnemyHealth>();
            enemyTargetMovement = m_target.GetComponent<EnemyMovement>();
        }
    }

    public void SetMultipleTargets(List<GameObject> target) {
        m_targets = target;
        multiTargetOn = true;
    }


}