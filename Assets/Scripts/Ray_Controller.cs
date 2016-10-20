using UnityEngine;
using System.Collections;

public class Ray_Controller : MonoBehaviour {

    public Ray mainRay;


	void Start () {
        mainRay.origin = transform.position;
        mainRay.direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        mainRay.origin = transform.position;
        mainRay.direction = transform.forward;
        //Debug.Log(mainRay.origin);
	}

    public Ray GetMainRay() {
        return mainRay;
    }
}
