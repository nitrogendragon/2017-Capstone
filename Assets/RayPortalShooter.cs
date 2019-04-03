using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPortalShooter : MonoBehaviour
{


    public float speed = 50;
    public GameObject bullet;
    GameObject enemycapsule;
    float shoottimer;
    float animatetimer;
    GameObject newbullet;
    bool animatebullet;

    RaycastHit hit;
    public float timeBetweenShots = 1f;
    // Update is called once per frame
    void Awake()
    {

        enemycapsule = GameObject.Find("EnemyCapsule");
    }
    void Fire()
    {
        newbullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;



    }
    void Update()
    {

        shoottimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.T) && shoottimer >= timeBetweenShots && Physics.Raycast(transform.position, transform.forward, out hit, 400.0f))
        {





            Fire();
            animatetimer += Time.deltaTime;
            animatebullet = true;
            shoottimer = 0;

        }

        if (animatebullet == true && newbullet)
        {
            newbullet.transform.position = Vector3.MoveTowards(newbullet.transform.position, hit.point, 3f);

            if (animatetimer == timeBetweenShots-.1f)
            {
                Destroy(newbullet);
                animatetimer = 0.0f;
            }
        }

    }
}
