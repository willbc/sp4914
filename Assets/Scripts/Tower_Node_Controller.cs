using UnityEngine;
using System.Collections;

public class Tower_Node_Controller : MonoBehaviour {

    public Ray playerRay;

    public bool isHitByRay;

    public float range = 1000.0f;

    RaycastHit hit;


	void Start () {
        isHitByRay = false;
        playerRay = GameObject.Find("Main Camera").GetComponent<Ray_Controller>().GetMainRay();
        Debug.Log(playerRay);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Physics.Raycast(playerRay, out hit));
        if(Physics.Raycast (playerRay, out hit)) {
            Debug.Log(hit);
            if(hit.collider.tag == "TowerSpot") {
                Debug.Log("hit");
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
            transform.localScale = new Vector3(transform.localScale.x, 3F, transform.localScale.y);
        }
        else {
            transform.localScale = new Vector3(transform.localScale.x, 1F, transform.localScale.y);
        }
	}
}
