using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttack : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

   // Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = GameObject.Find("Player");
        //player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
       // anim = GetComponent<Animator>();
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")

        {
            Debug.Log("we hit");
            playerInRange = true;
        }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("we hit no more");
            playerInRange = false;
        }
    }


    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
     /**   if(GameObject.Find("Player").transform.position.x - GameObject.Find("EnemyCapsule").transform.position.x >= -10 &&
            GameObject.Find("Player").transform.position.x - GameObject.Find("EnemyCapsule").transform.position.x <= 10
            )
        {
            Debug.Log("InRange");
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
        
         * 
         * **/
        Checkifatk();
    }
    void Checkifatk()
    {
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
            
        }
        if (playerHealth.currentHealth <= 0)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
