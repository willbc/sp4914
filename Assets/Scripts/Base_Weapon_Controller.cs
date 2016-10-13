using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Base_Weapon_Controller : MonoBehaviour {

    public bool isProjectile;
    public GameObject projectile;

    Ray shotRay;
    RaycastHit hitInfo;
    Vector3 hitPoint;
    GameObject hitObject;

    public float damage;
    public float range;
    public float rechargeSpeed;
    public float maxCapacity;
    public float cooldownTime;
    float cooldownRemaining = 0.0f;

    float currentCapacity;
    public Text ammoText;

    HUDController hudController;

    AudioSource shotSound;
    LineRenderer shotLine;
    Light shotLight;
    int shootableMask;
    public float shotEffectsDisplayTime;
    float effectsTimer = 0.0f;


    public void Fire() {
        if(cooldownRemaining > 0 || currentCapacity < 1) {
            return;
        }

        cooldownRemaining = cooldownTime;
        if(shotSound != null) {
            shotSound.Play();   
        }
        currentCapacity -= 1;

        if(isProjectile) {

        }
        else { // Standard raycast shot
            effectsTimer = 0f;
            shotLight.enabled = true;

            shotLine.enabled = true;
            shotLine.SetPosition (0, transform.position);

            shotRay.origin = transform.position;
            shotRay.direction = transform.forward;


            if(Physics.Raycast (shotRay, out hitInfo, range, shootableMask)) {
                Vector3 hitPoint = hitInfo.point;
                GameObject hitObject = hitInfo.collider.gameObject;
                Debug.Log ("Hit object: " + hitObject.name);
                Debug.Log ("Hit point: " + hitPoint);

                EnemyHealth enemy = hitObject.GetComponent<EnemyHealth>();
                if(enemy != null) {
                    enemy.ReceiveDamage(damage);
                }
            }
        }
    }

    public void Reload() {
        // Probably won't have a reload function
    }

    void UpdateAmmoText() {
        ammoText.text = "Ammo: " + Mathf.Floor(currentCapacity);
        hudController.UpdateAmmoBar(currentCapacity, maxCapacity);
    }

    void Start() {
        currentCapacity = maxCapacity;
        shotSound = GetComponent<AudioSource>();
        shotLine = GetComponent <LineRenderer>();
        shotLight = GetComponent<Light>();
        shootableMask = LayerMask.GetMask ("Shootable");

        hudController = GameObject.Find("BasicHUD1").GetComponent<HUDController>();

//        Component[] components = hudController.GetComponents<Component>();
//        foreach (Component c in components){
//            Debug.Log("!! " + hudController.name + "\t["+c.name+"]" + 
//                "\t"+ c.GetType() +"\t"+c.GetType().BaseType);
//
//        }

        UpdateAmmoText();
        //hudController.UpdateAmmoBar(10f, 20f);
    }

    void Update() {
        cooldownRemaining -= Time.deltaTime;
        effectsTimer += Time.deltaTime;

        if(effectsTimer > shotEffectsDisplayTime) {
            if(shotLine != null) {
                shotLine.enabled = false;
                shotLight.enabled = false;
            }
        }

        if(currentCapacity < maxCapacity) {
            currentCapacity += rechargeSpeed * Time.deltaTime;
            Mathf.Clamp(currentCapacity, 0, maxCapacity);
            UpdateAmmoText();
        }

        //Debug.Log("Weapon ammo: " + currentCapacity);
    }
}
