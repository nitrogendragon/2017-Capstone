using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterportalcollider : MonoBehaviour {
    bool collided;
    int dupcounter;
    public GameObject exitportal;
    GameObject enemycapsule;
    GameObject portalholder;
    GameObject player;
    int warpdamage;
    PortalShooter portalshooter;
    // Use this for initialization
    
    private void Awake()
    {
        enemycapsule = GameObject.Find("EnemyCapsule");
        portalholder = GameObject.Find("PortalHolder");
        player = GameObject.Find("Player");
        warpdamage = 10;
        portalshooter = portalholder.GetComponent<PortalShooter>();
        

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "EnemyEngaged")
        {
            Debug.Log("hitenter");
            collided = true;

            EnemyWarp();
        }
        if(collision.transform.tag == "PlayerTrigger")
        {
            Debug.Log("hitplayer");
            collided = true;
            PlayerWarp();
        }
    }
    void PlayerWarp()
    {
        if (collided == true && portalshooter.tempExitPortal)
        {
            portalshooter.tempExitPortal.SetActive(false);
            player.transform.position = portalshooter.tempExitPortal.transform.position;
            Destroy(portalshooter.tempExitPortal);
            Destroy(gameObject);
        }
    }
    void EnemyWarp()
    {
        if (collided == true && portalshooter.tempExitPortal){
            portalshooter.tempExitPortal.SetActive(false);
            enemycapsule.transform.position =  portalshooter.tempExitPortal.transform.position;
            Destroy(portalshooter.tempExitPortal);
            Destroy(gameObject);
        }
    }
    

}
