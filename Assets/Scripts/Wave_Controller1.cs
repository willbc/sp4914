using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave_Controller1 : MonoBehaviour {

    Vector3 spawnPosition;
    public GameObject enemyToSpawn;
    public GameObject enemyToSpawn2;
    public GameObject enemyToSpawn3;
    public float spawnDelay;
    public float waveDelay;
    public int waveSize; //Use this as a difficulty setting
    public Text waveText;

    int currentWaveSpawnCount = 0;
    float currentDelayMax;
    float currentDelay = 0.0f;

    //Data for waves
    public int currentWaveNumber;
    public int difficulty;



    void Start () {
        spawnPosition = GameObject.Find("EnemyBase1").transform.position;
        Debug.Log(spawnPosition);
        currentDelayMax = waveDelay;
        currentWaveNumber = 1;
        waveText.text = "Wave: " + currentWaveNumber;
    }
	
    void Update() {
        if(currentDelay >= currentDelayMax) {
            currentDelay = 0.0f;
            if(currentWaveSpawnCount < waveSize) {
                if (currentWaveNumber < 4) {
                    InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 500.0f * difficulty, spawnPosition);
                    currentWaveSpawnCount++;
                }else if (currentWaveNumber < 6) {
                    InstantiateEnemy(enemyToSpawn2, 1.0f, 0.1f, 1000.0f * difficulty, spawnPosition + new Vector3(0, 0, 2f));
                    currentWaveSpawnCount += 3;
                }
                else if (currentWaveNumber < 8){
                    InstantiateEnemy(enemyToSpawn3, 0.5f, 0.1f, 1500.0f * difficulty, spawnPosition + new Vector3(0, 0, 4f));
                    currentWaveSpawnCount += 5;
                }
                else if (currentWaveNumber < 11){
                    InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 500.0f * difficulty, spawnPosition);
                    InstantiateEnemy(enemyToSpawn2, 1.0f, 0.1f, 1000.0f * difficulty, spawnPosition + new Vector3(0, 0, 2f));
                    currentWaveSpawnCount += 4;
                }else if (currentWaveNumber < 15)
                {
                    InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 500.0f * difficulty, spawnPosition);
                    InstantiateEnemy(enemyToSpawn2, 1.0f, 0.1f, 1000.0f * difficulty, spawnPosition + new Vector3(0, 0, 2f));
                    InstantiateEnemy(enemyToSpawn3, 0.5f, 0.1f, 1500.0f * difficulty, spawnPosition + new Vector3(0, 0, 4f));
                    currentWaveSpawnCount += 9;
                }
                else {
                    InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 500.0f * difficulty, spawnPosition);
                    InstantiateEnemy(enemyToSpawn2, 1.0f, 0.1f, 1000.0f * difficulty, spawnPosition + new Vector3(0, 0, 2f));
                    InstantiateEnemy(enemyToSpawn3, 0.5f, 0.1f, 1500.0f * difficulty, spawnPosition + new Vector3(0, 0, 4f));
                    InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 500.0f * difficulty, spawnPosition + new Vector3(0, 0, 6f));
                    currentWaveSpawnCount += 8;
                }
            }
            else {
                currentWaveSpawnCount = 0;
                currentDelayMax = waveDelay;
                currentWaveNumber++; //Set to next wave
                waveSize = waveSize + (currentWaveNumber * difficulty);
                waveText.text = "WAVE " + currentWaveNumber;
            }
        }
        else {
            currentDelay += Time.deltaTime;
        }
    }

    void InstantiateEnemy(GameObject prefab, float speed, float speedRegenRate, float health, Vector3 spawnPositionIns)
    {
        //NOTE: Speed not currently working
        GameObject enemyObject = (GameObject)Instantiate(prefab, spawnPositionIns, new Quaternion());
        EnemyMovement em = enemyObject.GetComponent<EnemyMovement>();
        EnemyHealth eh = enemyObject.GetComponent<EnemyHealth>();
        em.speed = speed;
        em.speedRegenRate = speedRegenRate;
        eh.maxHealth = health;
        em.SetSpeed();
    }


}
