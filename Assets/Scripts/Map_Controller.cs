using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map_Controller : MonoBehaviour {

    List<Transform> towerSpots = new List<Transform>();
    List<Transform> gridEdge = new List<Transform>();

    float towerSpotX;
    float towerSpotZ;

    float spaceBetween = 0.0f;//0.075f;

    int mapRows = 9;
    int mapCols = 9;

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
        MeshCollider childCollider = transform.GetChild(0).GetChild(0).GetComponent<MeshCollider>();
        towerSpotX = childCollider.bounds.size.x;
        towerSpotZ = childCollider.bounds.size.z;
        //Debug.Log(towerSpotX);
        //Debug.Log(towerSpotZ);

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






        InitializeBaseGraph();
        Debug.Log(baseGraph[21, 30]);
        Debug.Log(baseGraph[21, 60]);
        TestTowerSpot(31);
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



    int[,] baseGraph = new int[83,83];
    int[,] currentGraph = new int[83,83];

    int[][] edges = {
        new int[] { 82, 9, 1 }, // 0
        new int[] { 0, 9, 10, 2 }, // 1
        new int[] { 1, 10, 11, 3 }, // 2
        new int[] { 2, 11, 12, 4 }, // 3
        new int[] { 3, 12, 13, 5 }, // 4
        new int[] { 4, 13, 14, 6 }, // 5
        new int[] { 5, 14, 15, 7 }, // 6
        new int[] { 6, 15, 16, 8 }, // 7
        new int[] { 7, 16, 17, 81 }, // 8
        new int[] { 82, 18, 19, 10, 0, 1 }, // 9
        new int[] { 9, 19, 20, 11, 1, 2 }, // 10
        new int[] { 10, 20, 21, 12, 2, 3 }, // 11
        new int[] { 11, 21, 22, 13, 3, 4 }, // 12
        new int[] { 12, 22, 23, 14, 4, 5 }, // 13
        new int[] { 13, 23, 24, 15, 5, 6 }, // 14
        new int[] { 14, 24, 25, 16, 6, 7 }, // 15
        new int[] { 15, 25, 26, 17, 7, 8 }, // 16
        new int[] { 16, 26, 81, 8 }, // 17
        new int[] { 82, 27, 19, 9 }, // 18
        new int[] { 18, 27, 28, 20, 9, 10 }, // 19
        new int[] { 19, 28, 29, 21, 10, 11 }, // 20
        new int[] { 20, 29, 30, 22, 11, 12 }, // 21
        new int[] { 21, 30, 31, 23, 12, 13 }, // 22
        new int[] { 22, 31, 32, 24, 13, 14 }, // 23
        new int[] { 23, 32, 33, 25, 14, 15 }, // 24
        new int[] { 24, 33, 34, 26, 15, 16 }, // 25
        new int[] { 25, 34, 35, 81, 16, 17 }, // 26
        new int[] { 82, 36, 37, 28, 18, 19 }, // 27
        new int[] { 27, 37, 38, 29, 19, 20 }, // 28
        new int[] { 28, 38, 39, 30, 20, 21 }, // 29
        new int[] { 29, 39, 40, 31, 21, 22 }, // 30
        new int[] { 30, 40, 41, 32, 22, 23 }, // 31
        new int[] { 31, 41, 42, 33, 23, 24 }, // 32
        new int[] { 32, 42, 43, 34, 24, 25 }, // 33
        new int[] { 33, 43, 44, 35, 25, 26 }, // 34
        new int[] { 34, 44, 81, 26 }, // 35
        new int[] { 82, 45, 37, 27 }, // 36
        new int[] { 36, 45, 46, 38, 27, 28 }, // 37
        new int[] { 37, 46, 47, 39, 28, 29 }, // 38
        new int[] { 38, 47, 48, 40, 29, 30 }, // 39
        new int[] { 39, 48, 49, 41, 30, 31 }, // 40
        new int[] { 40, 49, 50, 42, 31, 32 }, // 41
        new int[] { 41, 50, 51, 43, 32, 33 }, // 42
        new int[] { 42, 51, 52, 44, 33, 34 }, // 43
        new int[] { 43, 52, 53, 81, 34, 35 }, // 44
        new int[] { 82, 54, 55, 46, 36, 37 }, // 45
        new int[] { 45, 55, 56, 47, 37, 38 }, // 46
        new int[] { 46, 56, 57, 48, 38, 39 }, // 47
        new int[] { 47, 57, 58, 49, 39, 40 }, // 48
        new int[] { 48, 58, 59, 50, 40, 41 }, // 49
        new int[] { 49, 59, 60, 51, 41, 42 }, // 50
        new int[] { 50, 60, 61, 52, 42, 43 }, // 51
        new int[] { 51, 61, 62, 53, 43, 44 }, // 52
        new int[] { 52, 62, 81, 44 }, // 53
        new int[] { 82, 63, 55, 45 }, // 54
        new int[] { 54, 63, 64, 56, 45, 46 }, // 55
        new int[] { 55, 64, 65, 57, 46, 47 }, // 56
        new int[] { 56, 65, 66, 58, 47, 48 }, // 57
        new int[] { 57, 66, 67, 59, 48, 49 }, // 58
        new int[] { 58, 67, 68, 60, 49, 50 }, // 59
        new int[] { 59, 68, 69, 61, 50, 51 }, // 60
        new int[] { 60, 69, 70, 62, 51, 52 }, // 61
        new int[] { 61, 70, 71, 81, 52, 53 }, // 62
        new int[] { 82, 72, 73, 64, 54, 55 }, // 63
        new int[] { 63, 73, 74, 65, 55, 56 }, // 64
        new int[] { 64, 74, 75, 66, 56, 57 }, // 65
        new int[] { 65, 75, 76, 67, 57, 58 }, // 66
        new int[] { 66, 76, 77, 68, 58, 59 }, // 67
        new int[] { 67, 77, 78, 69, 59, 60 }, // 68
        new int[] { 68, 78, 79, 70, 60, 61 }, // 69
        new int[] { 69, 79, 80, 71, 61, 62 }, // 70
        new int[] { 70, 80, 81, 62 }, // 71
        new int[] { 82, 73, 63 }, // 72
        new int[] { 72, 74, 63, 64 }, // 73
        new int[] { 73, 75, 64, 65 }, // 74
        new int[] { 74, 76, 65, 66 }, // 75
        new int[] { 75, 77, 66, 67 }, // 76
        new int[] { 76, 78, 67, 68 }, // 77
        new int[] { 77, 79, 68, 69 }, // 78
        new int[] { 78, 80, 69, 70 }, // 79
        new int[] { 79, 81, 70, 71 }, // 80
        new int[] { 80, 71, 62, 53, 44, 35, 26, 17, 8 }, // 81
        new int[] { 72, 63, 54, 45, 36, 27, 18, 9, 0 } // 82
    };

    private List<int> queue = new List<int>();
    private int[] dist;

    private void InitializeBaseGraph() {
        for(int i = 0; i < 83; i++) {
            for(int j = 0; j < 83; j++) {
                bool edgeExists = false;
                for(int k = 0; k < edges[i].Length; k++) {
                    if(edges[i][k] == j) {
                        edgeExists = true;
                    }
                }
                baseGraph[i, j] = edgeExists ? 1 : 0;
                currentGraph[i, j] = edgeExists ? 1 : 0;
            }
        }
    }

    public void addTowerToCurrent(int spotNumber) {
        for(int i = 0; i < 83; i++) {
            currentGraph[i, spotNumber] = 0;
            currentGraph[spotNumber, i] = 0;
        }
    }

    public void removeTowerFromCurrent(int spotNumber) {
        for(int i = 0; i < edges[spotNumber].Length; i++) {
            currentGraph[spotNumber, edges[spotNumber][i]] = 1;
            currentGraph[edges[spotNumber][i], spotNumber] = 1;
        }
    }


    public bool TestTowerSpot(int spotNumber) {
        addTowerToCurrent(spotNumber);
        Dijkstras();
        if(dist[82] > 0) {
            Debug.Log("Path exists");
            return true;
        }
        else {
            Debug.Log("Path does not exist");
            removeTowerFromCurrent(spotNumber);
            return false;
        }
    }

    private int GetNextVertex() {
        int min = int.MaxValue;
        int Vertex = -1;

        foreach (int j in queue) {
            //Debug.Log(j + " dist: " + dist[j]);
            if (dist[j] <= min) {
                min = dist[j];
                Vertex = j;
            }
        }

        queue.Remove(Vertex);

        return Vertex;

    }

    public void Dijkstras() {
        int len = currentGraph.GetLength(0);
        queue = new List<int>();
        dist = new int[len];

        for (int i = 0; i < len; i++) {
            dist[i] = int.MaxValue;
            queue.Add(i);
        }

        dist[81] = 0;


        while (queue.Count > 0) {
            int u = GetNextVertex();

            for (int v = 0; v < len; v++) {

                if (currentGraph[u, v] > 0) {
                    if (dist[v] > dist[u] + currentGraph[u, v]) {
                        dist[v] = dist[u] + currentGraph[u, v];
                    }
                }
            }
        }
    }
        
}
