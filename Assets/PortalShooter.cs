using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShooter : MonoBehaviour {
    public GameObject enterportal;
    public GameObject exitportal;
 
    AudioSource portalAudio;
    public float portalshoottimer;
   
    public float timeBetweenAttack = 1f;
    
    public GameObject tempEnterPortal;
    public GameObject tempExitPortal;
    GameObject enemycapsule;
    
    // Use this for initialization
    private void Awake()
    {
        enemycapsule = GameObject.Find("EnemyCapsule");
    }
    void Start () {
        portalAudio = GetComponent<AudioSource>();
        
	}
	
       
       
    
    public void FireEnterPortal()
    {
        tempEnterPortal = Instantiate(enterportal, transform.position, transform.rotation) as GameObject;
        tempEnterPortal.transform.position = tempEnterPortal.transform.position;
        // portalAudio.Play();
    }
    public void FireExitPortal()
    {
        tempExitPortal = Instantiate(exitportal, transform.position, transform.rotation) as GameObject;
        tempExitPortal.transform.position = tempExitPortal.transform.position;
        //portalAudio.Play();
    }


    // Update is called once per frame
    public void Update()
    {
        portalshoottimer += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.E) && portalshoottimer >= timeBetweenAttack)
        {
            if (tempEnterPortal)
            {
                Destroy(tempEnterPortal);
            }
                FireEnterPortal();

                portalshoottimer = 0;

            
            }


            if (Input.GetKeyUp(KeyCode.R) && portalshoottimer >= timeBetweenAttack)
            {
                if (tempExitPortal)
                {
                Destroy(tempExitPortal);
                }
                FireExitPortal();

                portalshoottimer = 0;







            }
        }
    
   
      
   
}
