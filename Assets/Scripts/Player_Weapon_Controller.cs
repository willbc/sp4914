using UnityEngine;
using System.Collections;

public class Player_Weapon_Controller : MonoBehaviour {


    public GameObject[] weaponInventory;
    public int equippedWeaponIndex = 0;

    private GameObject equippedWeapon;
    private Base_Weapon_Controller weaponController;

	void Start () {
        equippedWeapon = weaponInventory[equippedWeaponIndex];
        weaponController = equippedWeapon.GetComponent<Base_Weapon_Controller>();
	}
	
	void Update () {
        if (Input.GetButton("Fire1") && equippedWeapon != null) {
            weaponController.Fire();
        }
            

        if (Input.GetKeyDown(KeyCode.R)) {
            weaponController.Reload();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            ChangeWeapons();
        }
	}

    void ChangeWeapons() {
        equippedWeaponIndex = (equippedWeaponIndex + 1) % weaponInventory.Length;
        equippedWeapon = weaponInventory[equippedWeaponIndex];
        weaponController = equippedWeapon.GetComponent<Base_Weapon_Controller>();
    }
}
