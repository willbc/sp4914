﻿using UnityEngine;
using System.Collections;

public class Tower_Node_Controller : MonoBehaviour {

    Ray playerRay;
    Ray_Controller rayController;
    public GameObject[] towers;
    public int towerToBuild;
    public GameObject towerFrame;

    Map_Controller mapController;
    Player_Inventory_Controller playerInventory;

    public bool isHitByRay;

    public bool towerBuilt = false;

    public float range = 1000.0f;

    RaycastHit hit;

    public Renderer rend;
    Color towerSpotStandbyColor = new Color(68 / 255f, 230 / 255f, 255 / 255f, 147 / 255f);
    Color towerSpotHighlightColor = new Color(0f, 255 / 255f, 0f, 147 / 255f);


	void Start () {
        isHitByRay = false;
        rayController = GameObject.Find("Main Camera").GetComponent<Ray_Controller>();
        rend = GetComponent<Renderer>();
        SetToStandbyColor();

        GameObject pathTesterObject = GameObject.Find("PathTester");
        mapController = GameObject.Find("MapGrid").GetComponent<Map_Controller>();
        playerInventory = GameObject.Find("Player").GetComponent<Player_Inventory_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Physics.Raycast (rayController.mainRay, out hit, range)) {
            if(hit.collider.tag == "TowerSpot" && hit.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID()) {
                isHitByRay = true;
            }
            else {
                isHitByRay = false;
            }
        }
        else if(isHitByRay) {
            isHitByRay = false;
        }

        if(isHitByRay) {
            SetToActiveColor();
            if (!towerBuilt && Input.GetMouseButtonDown(1)) {
                BuildTower();
            }
            else if(Input.GetMouseButtonDown(1)) {
                // Tower management options, upgrade, destroy, etc.
            }
        }
        else {
            SetToStandbyColor();
        }
	}

    void SetToActiveColor() {
        rend.material.color = towerSpotHighlightColor;
    }

    void SetToStandbyColor() {
        rend.material.color = towerSpotStandbyColor;
    }

    bool TestTowerSpace() {
        return false;
    }

    public void BuildTower() {
        string indexString = transform.parent.transform.name.Split('(', ')')[1];
        int index = 0;
        bool canBuildTower = false;
        if(int.TryParse(indexString, out index)) {
            canBuildTower = mapController.TestTowerSpot(index);
            if(canBuildTower) {
                BuildTowerConfirmed();
            }
            else {
                BuildTowerDenied();
            }
        }
    }

    public void BuildTowerDenied() {
        Debug.Log("Could not build tower");
    }

    public void BuildTowerConfirmed() {
        towerFrame.transform.position = transform.position;
        towerToBuild = playerInventory.getTowerIndex();
        GameObject tower = (GameObject)Instantiate(towers[towerToBuild], transform.position, transform.rotation);
        tower.transform.SetParent(transform);
        towerBuilt = true;
        /*towerFrame.transform.position = transform.position;//new Vector3(transform.position.x, transform.position.y, 0f);
        NavMeshPath path = new NavMeshPath();
        pathTester.CalculatePath(GameObject.FindGameObjectWithTag("Finish").transform.position, path);
        Debug.Log("before yield");
        yield return new WaitForSeconds(Time.deltaTime * 4);
        Debug.Log("after yeild");
        Debug.Log("test path: " + pathTester.hasPath);
        Debug.Log(path.status);
        Debug.Log(path.corners);
        testTowerSpace = (path.status == NavMeshPathStatus.PathComplete);
        if(testTowerSpace) {
            GameObject tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
            tower.transform.SetParent(transform);
            towerBuilt = true;
        }
        else {
            towerFrame.transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
        }*/
    }
}
