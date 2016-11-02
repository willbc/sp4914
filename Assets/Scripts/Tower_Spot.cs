using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Tower_Spot : MonoBehaviour {

    public Renderer rend;
    bool towerPlaced;
    bool overTowerSpot;
    public GameObject towerspot;
    public GameObject tower;
    Color towerSpotStandbyColor = new Color(68, 230, 255, 147);
    Color towerSpotHighlightColor = new Color(0, 255, 0, 147);

    // Use this for initialization
    void Start () {
        towerPlaced = false;
        overTowerSpot = false;
        tower = null;
        rend = GetComponent<Renderer>();
        rend.material.color = towerSpotStandbyColor;
    }

    void HighlightColor(){
        rend.material.color = towerSpotStandbyColor;
    }

    void StandbyColor(){
        rend.material.color = towerSpotHighlightColor;
    }

    public void buildTower(KeyCode keyPressed){
        if(keyPressed == KeyCode.E){
            tower = Instantiate(Resources.Load("Assets/Prefabs/Tower1"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
        }
    }
    public void ObjectHitLessThanTwo(){
        overTowerSpot = true;
    }


    // Update is called once per frame
    void Update () {
        if (overTowerSpot){
            HighlightColor();
        }
        else{
            StandbyColor();
        }
	}
}
