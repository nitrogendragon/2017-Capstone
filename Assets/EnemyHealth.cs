using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth = 100;
    public Slider healthSlider;
    public Camera maincamera;
    public Canvas EnemyHealthCanvas;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;


    GameObject player;
    GameObject enemycapsule;
    // Animator anim;
    public AudioSource playerdeathAudio;
    public bool isDead;
    bool damaged;
    bool isSinking;

    void Awake()
    {

        player = GameObject.Find("Player");
        currentHealth = startingHealth;
        enemycapsule = GameObject.Find("EnemyCapsule");

        healthSlider.value = healthSlider.maxValue;



    }

    void Update()
    {
        Vector3 v = player.transform.position - transform.position;

        v.x = v.z = 0.0f;

        transform.LookAt(player.transform.position - v);

        transform.Rotate(0, 180, 0);

        if (isSinking)
        {
            enemycapsule.transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

    }


   


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        // playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {


            Death();
        }
    }

    public void Death()
    {
        EnemyHealthCanvas.enabled = false;
        isDead = true;
        enemycapsule.GetComponent<BoxCollider>().isTrigger = true;
        StartSinking();
    }
    public void StartSinking()
    {

        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(enemycapsule, 2f);

    }

}
