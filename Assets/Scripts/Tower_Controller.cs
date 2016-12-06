using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower_Controller : MonoBehaviour
{
    TrackingSystem m_tracker;
    ShootingSystem m_shooter;
    RangeChecker m_range;
    public bool isShockTower = false;
    public bool isSlowTower = false;
    public bool isBashTower = false;

    public int TowerLevel;

    // Use this for initialization
    void Start() {
        m_tracker = GetComponent<TrackingSystem>();
        m_shooter = GetComponent<ShootingSystem>();
        m_range = GetComponent<RangeChecker>();
    }

    // Update is called once per frame
    void Update() {
        if (!isBashTower)
        {
            TargetNearest();
        }
        else {
            TargetAll();
        }
    }

    void TargetNearest() {
        List<GameObject> validTargets = m_range.GetValidTargets();

        GameObject curTarget = null;
        float closestDist = 0.0f;

        for (int i = 0; i < validTargets.Count; i++) {
            if(validTargets[i] != null) {
                NavMeshAgent targetAgent = validTargets[i].GetComponent<NavMeshAgent>();
                if(targetAgent != null) {
                    float distance = targetAgent.remainingDistance;

                    if (!curTarget || distance < closestDist) {
                        curTarget = validTargets[i];
                        closestDist = distance;
                    }
                }
            }
        }

        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);
    }

    void TargetAll()
    {
        List<GameObject> validTargets = m_range.GetValidTargets();
        //m_tracker.SetMultipleTargets(validTargets);
        m_shooter.SetMultipleTargets(validTargets);
    }

    public int GetTowerLevel()
    {
        return TowerLevel;
    }

    public int GetTowerType()
    {
        if (isShockTower)
        {
            return 0;
        }
        if (isSlowTower)
        {
            return 1;
        }
        if (isBashTower)
        {
            return 2;
        }
        return 3;
    }
}