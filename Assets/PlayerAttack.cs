using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public int damage = 20;// damage variable for attacking enemies
    public float timeBetweenAttack = 1f;// variable for time intervals between attacks  
    public float range = 100f;//range of attack probably
    float timer;// variable for running a timer
    
    public float distance;// variable for distance from player to other enemies and such
    
    EnemyHealth enemyHealth;// reference to enemy health
    PlayerHealth playerHealth;// reference to playerhealth
    GameObject enemycapsule;//reference to enemycapsule gameobject
    GameObject player;//reference to player gameobject
    //GameObject bullet;
    GameObject barrel;//reference to the barrel gameobject attached to the player
    public bool firebullet;// boolean for if the bullet has been fired
   

    void Awake()
    {
        
        barrel = GameObject.Find("Barrel");
        //bullet = GameObject.Find("Bullet");
        enemycapsule = GameObject.Find("EnemyCapsule");
        player = GameObject.Find("Player");
        enemyHealth = enemycapsule.GetComponent<EnemyHealth>();
        playerHealth = GetComponent<PlayerHealth>();
    }
   
	
	// Update is called once per frame
	 void Update ()
    {
        timer += Time.deltaTime;
        if (enemycapsule) 
        {
            
            distance = Vector3.Distance(player.transform.position, enemycapsule.transform.position);
           
        
      /**  if(firebullet == true)
            {
                bullet.transform.position = barrel.transform.position;//edit to make more precise;
                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, enemycapsule.transform.position, 1f);
            }**/
        }

      
    }

    



   

    

}
