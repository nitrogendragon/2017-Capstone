using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathSceneText : MonoBehaviour
{

    public Canvas DeathCanvas;
    PlayerHealth playerHealth;
    GameObject phealth;

    void Awake()
    {
        phealth = GameObject.Find("Player");

        playerHealth = phealth.GetComponent<PlayerHealth>();
        DeathCanvas.enabled = false;
    }
    public void DeathTextOn()

    {
        if (playerHealth.currentHealth <=0  || playerHealth.isDead == true)
        {

            DeathCanvas.enabled = true;
        }
   
    }
    public void Quit()
    {
        Application.LoadLevel(0);
    }
    public void Restart()
    {
        Application.LoadLevel(1);
    }
    void Update()
    {
        DeathTextOn();
    }
}

