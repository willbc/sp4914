using UnityEngine;
using System.Collections;

public class Wave_Controller : MonoBehaviour {

    Vector3 spawnPosition;
    public GameObject enemyToSpawn;
    public float spawnDelay;
    public float waveDelay;
    public int waveSize;

    int currentWaveSpawnCount = 0;
    float currentDelayMax;
    float currentDelay = 0.0f;


	void Start () {
        spawnPosition = GameObject.Find("EnemyBase1").transform.position;
        Debug.Log(spawnPosition);
        currentDelayMax = waveDelay;
	}
	
    void Update() {
        if(currentDelay >= currentDelayMax) {
            currentDelay = 0.0f;
            if(currentWaveSpawnCount < waveSize) {
                InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 50.0f);
                currentWaveSpawnCount++;
            }
            else {
                currentWaveSpawnCount = 0;
                currentDelayMax = waveDelay;
            }
        }
        else {
            currentDelay += Time.deltaTime;
        }
    }

    void InstantiateEnemy(GameObject prefab, float speed, float speedRegenRate, float health) {
        GameObject enemyObject = (GameObject)Instantiate(enemyToSpawn, spawnPosition, new Quaternion());
        EnemyMovement em = enemyObject.GetComponent<EnemyMovement>();
        EnemyHealth eh = enemyObject.GetComponent<EnemyHealth>();
        em.speed = speed;
        em.speedRegenRate = speedRegenRate;
        eh.maxHealth = health;
    }
}
