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

    Color moneyColor = new Color(196 / 255f, 179 / 255f, 50 / 255f, 255 / 255f);
    Color notEnoughMoneyColor = new Color(255 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);

    void Start () {
        money = startMoney;
        moneyText.color = moneyColor;
        UpdateMoneyText();
	}

    public void EarnMoney(int amount) {
        money += amount;
        UpdateMoneyText();
    }

    public bool SpendMoney(int amount) {
        if(amount > money) {
            FlashRed();
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

    public int GetMoney()
    {
        return money;
    }

    public void FlashRed()
    {
        StartCoroutine(Delay(0f, notEnoughMoneyColor));
        StartCoroutine(Delay(0.5f, moneyColor));
    }

    IEnumerator Delay(float waitTime, Color turnColor)
    {
        yield return new WaitForSeconds(waitTime);
        moneyText.color = turnColor;
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
