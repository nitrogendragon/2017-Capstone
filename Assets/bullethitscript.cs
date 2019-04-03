using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethitscript : MonoBehaviour
{
    GameObject enemycapsule;//references enemtycapsule
    EnemyHealth enemyhealth; // reference to enemyhealth script
    bool collided;// true false variable
    public int bulletstrength =10;// speed variable for bullet
    
    private void Awake()
    {
   
        enemycapsule = GameObject.Find("EnemyCapsule");// finds the game object with EnemyCapsule name
        enemyhealth = enemycapsule.GetComponent<EnemyHealth>();// gets the enemyhealth component form the enemy capsule. allows this script to access publics from enemyhealth script
    }
    void OnCollisionEnter(Collision collision)// built in function for detecting when collisions occur, uses collision variable for other scripts to reference
    {
        if (collision.transform.tag == "EnemyEngaged")// checks if the object collided with has the tag EnemyEngaged
        {
            //Debug.Log(collision.transform.name);
            collided = true;//sets the boolean collided to true
            
            MegaBullet();// runs MegaBullet function
        }
    }
    void MegaBullet()//function for dealing damage to enemy
    {
        Destroy(gameObject);//gets rid of the bullet. used due to issues with getting it to actually fire
        bulletstrength = 10;// ensures that bulletstrength is actually what I wanted. consider removing later due to probably not being needed anymore
        enemyhealth.TakeDamage(bulletstrength);// reduces enemyhelath by the value of bullet strength by running enemyhealth scripts TakeDamage function
    }
    
}