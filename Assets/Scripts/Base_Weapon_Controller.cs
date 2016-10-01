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
        shotSound.Play();
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
        ammoText.text = "Ammo: " + Mathf.RoundToInt(currentCapacity);
    }

    void Start() {
        currentCapacity = maxCapacity;
        UpdateAmmoText();
        shotSound = GetComponent<AudioSource>();
        shotLine = GetComponent <LineRenderer> ();
        shotLight = GetComponent<Light> ();
        shootableMask = LayerMask.GetMask ("Shootable");
    }

    void Update() {
        cooldownRemaining -= Time.deltaTime;
        effectsTimer += Time.deltaTime;

        if(effectsTimer > shotEffectsDisplayTime) {
            shotLine.enabled = false;
            shotLight.enabled = false;
        }

        if(currentCapacity < maxCapacity) {
            currentCapacity += rechargeSpeed * Time.deltaTime;
            Mathf.Clamp(currentCapacity, 0, maxCapacity);
            UpdateAmmoText();
        }

        //Debug.Log("Weapon ammo: " + currentCapacity);
    }
}
