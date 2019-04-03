using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    GameObject enemycapsule;
   // float bulletspeed = 3100;
    AudioSource bulletAudio;
    Rigidbody tempRigidBodyBullet;
    float shoottimer;
    bool animatebullet;
    float animatetimer;
    public float timeBetweenAttack = 1f;


    GameObject tempBullet;
	// Use this for initialization
    void Awake()
    {
        
        enemycapsule = GameObject.Find("EnemyCapsule");
    }
	void Start () {
        bulletAudio = GetComponent<AudioSource>();
	}
	void Fire()
    {
        tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
       // tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletspeed);

      //  Destroy(tempBullet, 1f);
        bulletAudio.Play();

       // bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, enemycapsule.transform.position, 1f)
    }
	// Update is called once per frame
	void Update () {

        shoottimer += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.F) && shoottimer >= timeBetweenAttack)
        {
            Fire();
            animatebullet = true;
            shoottimer = 0;
        }
        //if (Input.GetKeyUp(KeyCode.G))
       // {
       //     animatebullet = true;
       // }
        if(animatebullet == true && tempBullet)
        {
            animatetimer += Time.deltaTime;
            tempBullet.transform.position = Vector3.MoveTowards(tempBullet.transform.position, enemycapsule.transform.position, 3f);
            DestroyBullet();
        }
        

       
	}
    void DestroyBullet()
    {
        if (animatetimer >= .9f)
        {
                animatebullet = false;
                Destroy(tempBullet);
            Debug.Log("destroybullet worked");
            animatetimer = 0;

        }
    }
}
