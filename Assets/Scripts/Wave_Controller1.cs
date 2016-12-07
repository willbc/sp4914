using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave_Controller1 : MonoBehaviour
{

    Vector3 spawnPosition;
    public GameObject enemyToSpawn;
    public GameObject enemyToSpawn2;
    public GameObject enemyToSpawn3;
    public GameObject enemyToSpawn4;
    public GameObject enemyToSpawn5;
    public GameObject enemyToSpawn6;
    public float spawnDelay;
    public float waveDelay;
    public int waveSize; //Use this as a difficulty setting
    public Text waveText;

    int currentWaveSpawnCount = 0;
    float currentDelayMax;
    float currentDelay = 0.0f;

    //Data for waves
    public int currentWaveNumber;
    public int difficulty; //Set to 1, 2, or 3
    public bool infWaves = false;

    //Data for DARK/LIGHT mode
    public bool darkMode = false;
    public Light myLight1;
    public Light myLight2;
    public Material mat1;

    private float waveDifficulty = 1;




    void Start() {
        spawnPosition = GameObject.Find("EnemyBase1").transform.position;
        Debug.Log(spawnPosition);
        currentDelayMax = waveDelay;
        currentWaveNumber = 1;
        waveText.text = "Wave: " + currentWaveNumber;

        if(!darkMode) {
            enemyToSpawn = enemyToSpawn4;
            enemyToSpawn2 = enemyToSpawn5;
            enemyToSpawn3 = enemyToSpawn6;
            //RenderSettings.skybox = mat1;

        }
        else {
            //We are using dark mode

            myLight1.enabled = false;
            myLight2.enabled = false;
            RenderSettings.skybox = mat1;
        }


    }

    void Update() {
        if (currentDelay >= currentDelayMax) {
            waveDifficulty = waveDifficulty + ((float)currentWaveNumber / 500f);
            currentDelay = 0.0f;
            currentDelayMax = waveDelay;
            if (currentWaveSpawnCount < waveSize) {
                if (currentWaveNumber < 4) {
                    InstantiateEnemy(enemyToSpawn, 2.0f , 0.1f * waveDifficulty, 500.0f * difficulty * waveDifficulty, spawnPosition);
                    currentWaveSpawnCount++;
                }
                else if (currentWaveNumber < 6) {
                    InstantiateEnemy(enemyToSpawn2, 1.0f , 0.1f * waveDifficulty, 1000.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 2f));
                    currentWaveSpawnCount += 3;
                }
                else if (currentWaveNumber < 8) {
                    InstantiateEnemy(enemyToSpawn3, 0.5f , 0.1f * waveDifficulty, 1500.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 4f));
                    currentWaveSpawnCount += 5;
                }
                else if (currentWaveNumber < 11) {
                    InstantiateEnemy(enemyToSpawn, 2.0f , 0.1f * waveDifficulty, 500.0f * difficulty * waveDifficulty, spawnPosition);
                    InstantiateEnemy(enemyToSpawn2, 1.0f , 0.1f * waveDifficulty, 1000.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 2f));
                    currentWaveSpawnCount += 4;
                }
                else if (currentWaveNumber < 15) {
                    InstantiateEnemy(enemyToSpawn, 2.0f , 0.1f * waveDifficulty, 500.0f * difficulty * waveDifficulty, spawnPosition);
                    //InstantiateEnemy(enemyToSpawn2, 1.0f, 0.1f, 1000.0f * difficulty, spawnPosition + new Vector3(0, 0, 2f));
                    InstantiateEnemy(enemyToSpawn3, 0.5f , 0.1f * waveDifficulty, 1500.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 4f));
                    currentWaveSpawnCount += 9;
                }
                else if (currentWaveNumber < 21) {
                    InstantiateEnemy(enemyToSpawn, 2.0f , 0.1f * waveDifficulty, 500.0f * difficulty * waveDifficulty, spawnPosition);
                    InstantiateEnemy(enemyToSpawn2, 1.0f , 0.1f * waveDifficulty, 1000.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 2f));
                    InstantiateEnemy(enemyToSpawn3, 0.5f , 0.1f * waveDifficulty, 1500.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 4f));
                   // InstantiateEnemy(enemyToSpawn, 2.0f, 0.1f, 500.0f * difficulty, spawnPosition + new Vector3(0, 0, 6f));
                    currentWaveSpawnCount += 8;
                }
                else { 
                    if (infWaves) {
                        InstantiateEnemy(enemyToSpawn, 2.0f , 0.1f * waveDifficulty, 500.0f * difficulty * waveDifficulty, spawnPosition);
                        InstantiateEnemy(enemyToSpawn2, 1.0f , 0.1f * waveDifficulty, 1000.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 2f));
                        InstantiateEnemy(enemyToSpawn3, 0.5f , 0.1f * waveDifficulty, 1500.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 4f));
                        InstantiateEnemy(enemyToSpawn, 2.0f , 0.1f * waveDifficulty, 500.0f * difficulty * waveDifficulty, spawnPosition + new Vector3(0, 0, 6f));
                        currentWaveSpawnCount += 8;
                    }
                    else {
                        
                    }
                    
                }
            }
            else {
                currentWaveSpawnCount = 0;
                currentDelayMax = spawnDelay;
                currentWaveNumber++; //Set to next wave
                waveSize = waveSize + (currentWaveNumber * difficulty);
                if ((currentWaveNumber > 20) && (!infWaves)) {
                    waveText.text = "Wave: 20";
                }
                else {
                    waveText.text = "Wave: " + currentWaveNumber;
                }
                
            }
        }
        else {
            currentDelay += Time.deltaTime;
        }

        if(!infWaves && currentWaveNumber >= 20) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            if(enemies.Length == 0) {
                SceneManager.LoadScene("GameOverWin");
            }
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

    }


}
