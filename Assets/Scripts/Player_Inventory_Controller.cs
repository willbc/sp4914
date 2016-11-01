using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Inventory_Controller : MonoBehaviour {

    public int startMoney = 500;
    int money;
    public Text moneyText;

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
}
