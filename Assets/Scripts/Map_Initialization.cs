using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map_Initialization : MonoBehaviour {

    List<Transform> towerSpots = new List<Transform>();
    List<Transform> gridEdge = new List<Transform>();

    float towerSpotX;
    float towerSpotZ;

    float spaceBetween = 0.0f;//0.075f;

    int mapRows = 11;
    int mapCols = 13;

    int rowCount = 0;
    int colCount = 0;

    float rowAddition = 0;

	void Start () {
        int totalSpots = mapRows * mapCols;
        int rowMin = mapRows / 2 * -1;
        int rowMax = mapRows / 2 + 1;
        int colMin = mapCols / 2 * -1;
        int colMax = mapCols / 2 + 1;
        rowCount = rowMin;
        colCount = colMin;
        MeshCollider childCollider = transform.GetChild(0).GetComponent<MeshCollider>();
        towerSpotX = childCollider.bounds.size.x;
        towerSpotZ = childCollider.bounds.size.z;

        foreach(Transform child in transform) {
            if(child.CompareTag("TowerSpot")) {
                towerSpots.Add(child);
            }
            else if(child.CompareTag("GridEdge")) {
                gridEdge.Add(child);
            }
        }

        Debug.Log(gridEdge.Count);

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
        Vector3 spotTrans = new Vector3(xTransSingle * row + GetRowBias(col), 0.0f, zTransSingle * col);

        return spotTrans;
    }

    private float GetRowBias(int col) {
        if(col % 2 == 0) {
            return 0.0f;
        }
        return 0.5f * towerSpotX + spaceBetween;
    }


}
