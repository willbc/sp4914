using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public float speed = 2.0f;
    public float speedRegenRate = 0.1f;

    Material mat;
    Color baseColor;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Finish").transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        mat = transform.GetComponent<MeshRenderer>().material;
        baseColor = mat.color;
    }


    void Update()
    {
        // If the enemy and the player have health left...
        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        //}
        // Otherwise...
        //else
        //{
            // ... disable the nav mesh agent.
            //nav.enabled = false;
        //}

        ReplenishSpeed();
    }

    public void ReduceSpeed(float speedReduction, float speedRegenReduction) {
        if(speedReduction != 1) {
            Debug.Log("speed reduction" + speedReduction);
            Debug.Log("speed" + speed);
            Debug.Log("new speed" + speed * speedReduction);
            nav.speed = speed * speedReduction;

            mat.color = Color.magenta;
        }
    }

    void ReplenishSpeed() {
        if(nav.speed < speed) {
            nav.speed += speedRegenRate * Time.deltaTime;
            mat.color = Color.Lerp(mat.color, baseColor, Time.deltaTime * speedRegenRate);
        }
        else {
            mat.color = baseColor;
        }
    }

    public void SetSpeed() {
        nav.speed = speed;
    }
}