using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinPriestStats : MonoBehaviour
{
    public Camera mcamera;
    public GameObject ppdamagetext;

    GameObject penguinpriest;
    GameObject ppbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider pphealthSlider;
  
    public Canvas ppHealthCanvas;
    public float speed = 10;
    public float defense = 2;
    public float attack = 6;
    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;


    public bool isDead;
 

    void Awake()
    {
        penguinpriest = GameObject.Find("PenguinPriest");
        ppbody = GameObject.Find("PenguinPriestBody");
        currentHealth = startingHealth;


        pphealthSlider.value = pphealthSlider.maxValue;



    }

    void Update()
    {

        
     

    }


    public void Restore(float amount)
    {


        currentHealth += amount;
        
        pphealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            pphealthSlider.value = currentHealth;
        }

    }
    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(ppdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("ppHealthCanvas"));
        tempRect.transform.position = ppbody.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = ppdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("pphit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;

    public void TakeDamage(float amount)
    {

        if (amount - defense >= 0)
        { 
        currentHealth -= amount - defense;
            takendamage = amount - defense;
            pphealthSlider.value = currentHealth;
            InitDamageText(takendamage.ToString());
        }
        
        // playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {

            isDead = true;
            Death();
        }
    }

    public void Death()
    {
        ppHealthCanvas.enabled = false;
        penguinpriest.SetActive(false);
        
        
    }


}

