using UnityEngine;
using System.Collections;

public class Tower_Node_Controller : MonoBehaviour {

    Ray playerRay;
    Ray_Controller rayController;
    public GameObject[] towers;
    public GameObject[] towers2;
    public GameObject[] towers3;
    public int towerToBuild;
    public GameObject towerFrame;
    GameObject tower;

    Map_Controller mapController;
    Player_Inventory_Controller playerInventory;

    public bool isHitByRay;

    public bool towerBuilt = false;

    public float range = 1000.0f;

    RaycastHit hit;

    bool disableActiveColor;

    int[] towerCostLevel1 = { 100, 75, 125 };
    int[] towerCostLevel2 = { 300, 200, 400 };
    int[] towerCostLevel3 = { 1000, 500, 1500 };

    public Renderer rend;
    Color towerSpotStandbyColor = new Color(68 / 255f, 230 / 255f, 255 / 255f, 147 / 255f);
    Color towerSpotGreen  = new Color(0f, 1f, 0f, 147 / 255f);
    Color towerSpotRed = new Color(1f, 0f, 0f, 147 / 255f);


    void Start () {
        isHitByRay = false;
        rayController = GameObject.Find("Main Camera").GetComponent<Ray_Controller>();
        rend = GetComponent<Renderer>();
        SetToStandbyColor();

        GameObject pathTesterObject = GameObject.Find("PathTester");
        mapController = GameObject.Find("MapGrid").GetComponent<Map_Controller>();
        playerInventory = GameObject.Find("Player").GetComponent<Player_Inventory_Controller>();
        disableActiveColor = false;
    }
	
	// Update is called once per frame
	void Update () {
        towerToBuild = playerInventory.getTowerIndex();
        if (Physics.Raycast (rayController.mainRay, out hit, range)) {
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

        if (isHitByRay)
        {
            if (!disableActiveColor)
            {
                SetToActiveColor();
            }
            if (!towerBuilt && Input.GetMouseButtonDown(1))
            {
                BuildTower();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                UpgradeTower();
            }
        }
        else {
            SetToStandbyColor();
        }
    }

    void SetToActiveColor()
    {
        rend.material.color = towerSpotGreen;
    }

    void SetToCannotBuildColor()
    {
        rend.material.color = towerSpotRed;
    }

    void SetToStandbyColor()
    {
        rend.material.color = towerSpotStandbyColor;
    }

    bool TestTowerSpace()
    {
        return false;
    }

    public void BuildTower()
    {
        string indexString = transform.parent.transform.name.Split('(', ')')[1];
        int index = 0;
        bool canBuildTower = false;
        if (int.TryParse(indexString, out index))
        {
            canBuildTower = mapController.TestTowerSpot(index);
            if (canBuildTower && playerInventory.GetMoney() >= towerCostLevel1[towerToBuild])
            {
                BuildTowerConfirmed();
                playerInventory.SpendMoney(towerCostLevel1[towerToBuild]);
            }
            else if (canBuildTower)
            {
                playerInventory.FlashRed();
            }
            else {
                BuildTowerDenied();
            }
        }
    }

    public void BuildTowerDenied()
    {
        StartCoroutine(DelayRed(0.5f));
        Debug.Log("Could not build tower");
    }

    IEnumerator DelayRed(float waitTime)
    {
        disableActiveColor = true;
        SetToCannotBuildColor();
        yield return new WaitForSeconds(waitTime);
        disableActiveColor = false;
    }

    public void BuildTowerConfirmed()
    {
        towerFrame.transform.position = transform.position;
        tower = (GameObject)Instantiate(towers[towerToBuild], transform.position, transform.rotation);
        tower.transform.SetParent(transform);
        towerBuilt = true;
    }

    public void UpgradeTower()
    {
        Debug.Log("UPGRADE TOWER");
        if(GetComponentInChildren<Tower_Controller>().GetTowerLevel() == 1)
        {
            if (playerInventory.GetMoney() < towerCostLevel2[GetComponentInChildren<Tower_Controller>().GetTowerType()])
            {
                playerInventory.FlashRed();
            }
            else
            {
                Destroy(tower);
                tower = (GameObject)Instantiate(towers2[GetComponentInChildren<Tower_Controller>().GetTowerType()], transform.position, transform.rotation);
                tower.transform.SetParent(transform);
                playerInventory.SpendMoney(towerCostLevel2[GetComponentInChildren<Tower_Controller>().GetTowerType()]);
            }
        }
        else if (GetComponentInChildren<Tower_Controller>().GetTowerLevel() == 2)
        {
            if (playerInventory.GetMoney() < towerCostLevel3[GetComponentInChildren<Tower_Controller>().GetTowerType()])
            {
                playerInventory.FlashRed();
            }
            else
            {
                Destroy(tower);
                tower = (GameObject)Instantiate(towers3[GetComponentInChildren<Tower_Controller>().GetTowerType()], transform.position, transform.rotation);
                tower.transform.SetParent(transform);
                playerInventory.SpendMoney(towerCostLevel3[GetComponentInChildren<Tower_Controller>().GetTowerType()]);
            }
        }
        else {
            //do nothing
        }
    }
}