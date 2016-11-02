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
                Instantiate(enemyToSpawn, spawnPosition, new Quaternion());
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
}
