using UnityEngine;
using System.Collections;

public class Test_Node_Controller : MonoBehaviour {

    public GameObject towerFrame;

    NavMeshAgent pathTester;
    NavMeshPath path;

    Map_Test_Controller mapTest;

    public bool towerBuilt = false;



    void Start () {
        path = new NavMeshPath();
        GameObject pathTesterObject = GameObject.Find("PathTester");
        pathTester = pathTesterObject.GetComponent<NavMeshAgent>();
        mapTest = GameObject.Find("MapTestGrid").GetComponent<Map_Test_Controller>();
    }

    public bool TestTowerSpace() {
        return (path.status == NavMeshPathStatus.PathComplete);
    }

    public void CalcPath() {
        pathTester.CalculatePath(GameObject.FindGameObjectWithTag("FinishTest").transform.position, path);
    }

    public void BuildTower() {
        towerFrame.transform.position = transform.position;//new Vector3(transform.position.x, transform.position.y, 0f);

    }
   
    public void RemoveTower() {
        towerFrame.transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
    }
}
