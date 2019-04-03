using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitportalcollider : MonoBehaviour {

    
    bool collided;
    int dupcounter;
    public GameObject enterportal;
    GameObject enemycapsule;
    GameObject portalholder;
    GameObject player;
    PortalShooter portalshooter;
    
    EnemyHealth enemyhealth;
    int warpdamage;
    // Use this for initialization

    private void Awake()
    {
        player = GameObject.Find("Player");
        enemycapsule = GameObject.Find("EnemyCapsule");
        enemyhealth = enemycapsule.GetComponent<EnemyHealth>();
        portalholder = GameObject.Find("PortalHolder");
        portalshooter = portalholder.GetComponent<PortalShooter>();
        warpdamage = 10;
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "EnemyEngaged" ) 
        {
            Debug.Log("hitexit");
            collided = true;

            EnemyWarpDamage();
        }

        if (collision.transform.tag == "PlayerTrigger")
        {
            Debug.Log("hitexit");
            collided = true;

            PlayerWarp();
        }

    }
    void PlayerWarp()
    {
        if (collided == true && portalshooter.tempEnterPortal)
            portalshooter.tempEnterPortal.SetActive(false);
        player.transform.position = portalshooter.tempEnterPortal.transform.position;
        Destroy(portalshooter.tempEnterPortal);
        Destroy(gameObject);

    }
    void EnemyWarpDamage()
    {
        if (collided == true && portalshooter.tempEnterPortal)
            portalshooter.tempEnterPortal.SetActive(false);
        enemycapsule.transform.position = portalshooter.tempEnterPortal.transform.position;
        Destroy(portalshooter.tempEnterPortal);
        enemyhealth.TakeDamage(warpdamage);

        Destroy(gameObject);

    }
}

