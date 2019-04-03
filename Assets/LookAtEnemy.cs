using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour {
    GameObject sphereonplayer;
    GameObject enemycapsule;
    GameObject player;
    GameObject barrel;
    GameObject rayportalgun;
    GameObject rayportalholder;
    PlayerAttack playerattack;
    RayPortalShooter rayportalshooter;
	// Use this for initialization
	
	void Awake()
    {
        rayportalholder = GameObject.Find("RayPortalHolder");
        sphereonplayer = GameObject.Find("TankTop");
        enemycapsule = GameObject.Find("EnemyCapsule");
        barrel = GameObject.Find("Barrel");
        player = GameObject.Find("Player");
        rayportalgun = GameObject.Find("RayPortalGun");
        rayportalshooter = rayportalgun.GetComponent<RayPortalShooter>();
        playerattack = player.GetComponent<PlayerAttack>();

    }
	// Update is called once per frame
	void Update () {
        if (playerattack.distance <= 100 && enemycapsule)
        {
           
            Vector3 v = enemycapsule.transform.position - transform.position;

            v.x = v.z = 0.0f;
            v.y = enemycapsule.transform.position.y + enemycapsule.GetComponent<Renderer>().bounds.size.y/2;
            //Debug.Log(v.y);
           
                transform.LookAt(enemycapsule.transform.position - v);
                
            


        }
        
    }
}
