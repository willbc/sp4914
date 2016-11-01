using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower_Controller : MonoBehaviour
{
    TrackingSystem m_tracker;
    ShootingSystem m_shooter;
    RangeChecker m_range;

    // Use this for initialization
    void Start() {
        m_tracker = GetComponent<TrackingSystem>();
        m_shooter = GetComponent<ShootingSystem>();
        m_range = GetComponent<RangeChecker>();
    }

    // Update is called once per frame
    void Update() {
        TargetNearest();
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
}