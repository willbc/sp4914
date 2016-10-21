using UnityEngine;
using System.Collections;

public class Tower_Node_Controller : MonoBehaviour {

    Ray playerRay;
    Ray_Controller rayController;
    public GameObject towerToBuild;
    public GameObject towerFrame;

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
            if (!towerBuilt && Input.GetMouseButtonDown(1)) {
                GameObject tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
                tower.transform.SetParent(transform);

                towerFrame.transform.position = transform.position;//new Vector3(transform.position.x, transform.position.y, 0f);

                Debug.Log(towerFrame.transform.position);
                towerBuilt = true;
            }
            SetToActiveColor();
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
}
