using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map_Test_Controller : MonoBehaviour {

    List<Transform> towerSpots = new List<Transform>();
    List<Transform> gridEdge = new List<Transform>();

    float towerSpotX;
    float towerSpotZ;

    float spaceBetween = 0.0f;//0.075f;

    // Where the test field is compared to the origin
    float xBias = 0.0f;
    float yBias = 0.0f;
    float zBias = 65.0f;

    int mapRows = 9;
    int mapCols = 9;

    int rowCount = 0;
    int colCount = 0;

    float rowAddition = 0;

    public delegate void CanBuildTower();
    public delegate void CanNotBuildTower();

    //CanBuildTower canBuildCallback;
    //CanNotBuildTower canNotBuildCallback;

    NavMeshAgent agent;
    NavMeshPath path;

    void Start () {
        agent = GameObject.Find("PathTester").GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        InitializeGrid();
    }

    private void InitializeGrid() {
        int totalSpots = mapRows * mapCols;
        int rowMin = mapRows / 2 * -1;
        int rowMax = mapRows / 2 + 1;
        int colMin = mapCols / 2 * -1;
        int colMax = mapCols / 2 + 1;
        rowCount = rowMin;
        colCount = colMin;
        MeshCollider childCollider = transform.GetChild(0).GetChild(0).GetComponent<MeshCollider>();
        towerSpotX = childCollider.bounds.size.x;
        towerSpotZ = childCollider.bounds.size.z;

        foreach(Transform child in transform) {
            //Debug.Log(child.tag);
            if(child.CompareTag("TowerSpot")) {
                towerSpots.Add(child);
            }
            else if(child.CompareTag("GridEdge")) {
                gridEdge.Add(child);
            }
        }

        //Debug.Log(gridEdge.Count);

        int edgeIndex = 0;
        for(int i = 0; i < totalSpots; i++) {
            if(colCount == colMin) {
                Transform edge = gridEdge[edgeIndex++];
                edge.position = SpotTranslation(rowCount, colCount - 1);
            }
            else if(colCount == colMax - 1) {
                Transform edge = gridEdge[edgeIndex++];
                edge.position = SpotTranslation(rowCount, colCount + 1);
            }
            Transform spot = towerSpots[i];
            spot.position = SpotTranslation(rowCount++, colCount);
            if(rowCount == mapRows/2 + 1) {
                rowCount = mapRows/2 * -1;
                colCount++;
            }

            if(colCount == mapCols/2 + 1) {
                //break;
            }
        }
    }

    private Vector3 SpotTranslation(int row, int col) {
        //Debug.Log("row: " + row + " col: " + col);
        float xTransSingle = 1.0f * towerSpotX + spaceBetween;
        float zTransSingle = 0.75f * towerSpotZ + spaceBetween;
        Vector3 spotTrans = new Vector3(xTransSingle * row + GetRowBias(col) + xBias, 0.0f + yBias, zTransSingle * col + zBias);

        return spotTrans;
    }

    private float GetRowBias(int col) {
        if(col % 2 == 0) {
            return 0.0f;
        }
        return 0.5f * towerSpotX + spaceBetween;
    }


    public void testTowerSpot(string spotName, CanBuildTower canBuildCallback, CanNotBuildTower canNotBuildCallback) {
        Debug.Log(spotName);
        string indexString = spotName.Split('(', ')')[1];
        int index = 0;
        if(int.TryParse(indexString, out index)) {
            Debug.Log(towerSpots.Count);
            Debug.Log(index);
            Test_Node_Controller node = towerSpots[index].GetChild(0).GetComponent<Test_Node_Controller>();
            node.BuildTower();
            agent.CalculatePath(GameObject.FindGameObjectWithTag("FinishTest").transform.position, path);
//            while(agent.pathPending) {
//                Debug.Log("path pending");
//                Debug.Log(agent.pathPending);
//                Debug.Log(agent.path.status);
//            }
//            Debug.Log(agent.pathPending);
//            Debug.Log(agent.path.status);
//            if(agent.path.status == NavMeshPathStatus.PathComplete) {
//                canBuildCallback();
//            }
//            else {
//                node.RemoveTower();
//                canNotBuildCallback();
//            }
            StartCoroutine(CalcPathDelay(node, canBuildCallback, canNotBuildCallback));
        }
    }

    IEnumerator CalcPathDelay(Test_Node_Controller node, CanBuildTower canBuildCallback, CanNotBuildTower canNotBuildCallback) {
        Debug.Log(path.status);
        Debug.Log(agent.pathPending);
        yield return new WaitForSeconds(Time.deltaTime * 50);
        Debug.Log(agent.path.status);
        Debug.Log(agent.path.corners.Length);
        for(int i = 0; i < path.corners.Length; i++) {
            Debug.Log(path.corners[i]);
        }
        Debug.Log("Target: ");
        Debug.Log(GameObject.FindGameObjectWithTag("FinishTest").transform.position);
        if(agent.path.status == NavMeshPathStatus.PathComplete) {
            canBuildCallback();
        }
        else {
            node.RemoveTower();
            canNotBuildCallback();
        }
    }


}
