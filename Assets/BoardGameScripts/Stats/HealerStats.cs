using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealerStats : MonoBehaviour
{


    public Camera mcamera;
    public GameObject hdamagetext;
    GameObject healer;
    GameObject healerbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider healerhealthSlider;

    public Canvas healerHealthCanvas;
    
    public float speed = 15;
    public float defense = 5;
    public float attack = 7;

    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;


    public bool isDead;


    void Awake()
    {
        healer = GameObject.Find("Healer");
        healerbody = GameObject.Find("HealerBody");
        currentHealth = startingHealth;
        
        
        healerhealthSlider.value = healerhealthSlider.maxValue;

        

    }

    void Update()
    {
       
       


    }


    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(hdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("DamageCanvas"));
        tempRect.transform.position = healer.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = hdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("healerhit");
        Destroy(temp.gameObject, 2);
    }
  
    float takendamage;
    public void TakeDamage(float amount)
    {

        if (amount - defense > 0)
        {
          
            currentHealth -= amount-defense;
            takendamage = amount - defense;
            
            healerhealthSlider.value = currentHealth;
            InitDamageText(takendamage.ToString());


        }

        if (currentHealth <= 0 && !isDead)
        {

            isDead = true;
            Death();
        }
    }

    public void Restore(float amount)
    {

        
            currentHealth += amount;
            Debug.Log("healer gained" + (amount) + " health");
            healerhealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            healerhealthSlider.value = currentHealth;
        }

    }

        
    

    public void Death()
    {
        healerHealthCanvas.enabled = false;
        healer.SetActive(false);


    }


}
