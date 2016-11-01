using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tower_Placement_Controller : MonoBehaviour {

    RaycastHit hit;
    Vector3 hitpoint;

    void start(){
    }

    // Update is called once per frame
    void Update () {
        
        //sends out raycast
        hitpoint = transform.TransformDirection(Vector3.forward);

        //if it hits a tower spot, get the data at that spot
        if(Physics.Raycast(transform.position, hitpoint, out hit)){
            if (hit.distance < 2){
                hit.transform.SendMessage("ObjectHitLessThanTwo");
            }
            hit.transform.SendMessage("ObjectHit");
        }
    }
}
