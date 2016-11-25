using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Inventory_Controller : MonoBehaviour {

    public int startMoney = 500;
    int money;
    public Text moneyText;
    int towerIndex = 0;

    public Sprite shockTowerBadge;
    public Sprite slowTowerBadge;
    public Sprite bashTowerBadge;
    public Image towerBadge;

    void Start () {
        money = startMoney;
        UpdateMoneyText();
	}

    public void EarnMoney(int amount) {
        money += amount;
        UpdateMoneyText();
    }

    public bool SpendMoney(int amount) {
        if(amount > money) {
            return false;
        }
        else {
            money -= amount;
            UpdateMoneyText();
            return true;
        }
    }

    public void UpdateMoneyText() {
        moneyText.text = "$: " + money;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            towerIndex = (towerIndex + 1) % 3;

            if(towerIndex == 0) {
                towerBadge.sprite = shockTowerBadge;
            }
            else if(towerIndex == 1) {
                towerBadge.sprite = slowTowerBadge;
            }
            else {
                towerBadge.sprite = bashTowerBadge;
            }
        }
    }

    public int getTowerIndex() {
        return towerIndex;
    }
}
