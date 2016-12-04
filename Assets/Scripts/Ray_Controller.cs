using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ray_Controller : MonoBehaviour {

    public Ray mainRay;
    public Ray shotRay;
    RaycastHit hitInfo;
    Vector3 hitPoint;
    GameObject hitObject;

    public GameObject crosshair;
    Image crosshairImage;

    void Start () {
        mainRay.origin = transform.position;
        mainRay.direction = transform.forward;
        crosshairImage = crosshair.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        mainRay.origin = transform.position;
        mainRay.direction = transform.forward;
        //Debug.Log(mainRay.origin);

        Vector3 newPosition = new Vector3(transform.position.x, 5f, transform.position.z);
        //crosshair.transform.position = newPosition;
    }

    public Ray GetMainRay() {
        Debug.Log("return ray");
        Debug.Log(mainRay.origin);
        return mainRay;
    }

    public void Fire(float damage, float range, int shootableMask) {
        shotRay.origin = transform.position;
        shotRay.direction = transform.forward;


        if (Physics.Raycast(shotRay, out hitInfo, range, shootableMask)) {
            Vector3 hitPoint = hitInfo.point;
            GameObject hitObject = hitInfo.collider.gameObject;
            //Debug.Log ("Hit object: " + hitObject.name);
            //Debug.Log ("Hit point: " + hitPoint);
            //shotLine.enabled = true;
            //shotLine.SetPosition (0, transform.position);
            //shotLine.SetPosition(1, hitPoint);

            EnemyHealth enemy = hitObject.GetComponent<EnemyHealth>();
            if (enemy != null) {
                enemy.ReceiveDamage(damage);
            }
        }
    }
}
