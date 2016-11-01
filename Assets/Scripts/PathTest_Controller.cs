using UnityEngine;
using System.Collections;

public class PathTest_Controller : MonoBehaviour {

    Transform target;
    NavMeshAgent nav;
    NavMeshPath path;


    void Awake()
    {
        path = new NavMeshPath();
        target = GameObject.FindGameObjectWithTag("FinishTest").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position);
    }

    void Update() {
        nav.SetDestination(target.position);
        nav.CalculatePath(target.position, new NavMeshPath());
        Debug.Log(nav.path.status);
    }
}
