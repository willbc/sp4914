using UnityEngine;
using System.Collections;

public class Map_Initialization : MonoBehaviour {

    GameObject[] towerSpots;

    float towerSpotX;
    float towerSpotZ;

    float spaceBetween = 0.075f;

    int mapRows = 11;
    int mapCols = 13;

    int rowCount = 0;
    int colCount = 0;

    float rowAddition = 0;

	void Start () {
        rowCount = mapRows/2 * -1;
        colCount = mapCols/2 * -1;
        MeshCollider childCollider = transform.GetChild(0).GetComponent<MeshCollider>();
        towerSpotX = childCollider.bounds.size.x;
        towerSpotZ = childCollider.bounds.size.z;

        foreach(Transform child in transform) {
            Debug.Log(child.position);
            child.position = SpotTranslation(rowCount++, colCount);
            Debug.Log(child.position);
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
        Debug.Log("row: " + row + " col: " + col);
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
