using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinMasterStats : MonoBehaviour
{
    public Camera mcamera;
    public GameObject pmdamagetext;

    GameObject penguinmaster;
    GameObject pmbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider pmhealthSlider;

    public Canvas pmHealthCanvas;

    public float speed = 25;
    public float defense = 4;
    public float attack = 12;
    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;



    public bool isDead;


    void Awake()
    {
        penguinmaster = GameObject.Find("PenguinMaster");
        pmbody = GameObject.Find("PenguinMasterBody");
        currentHealth = startingHealth;


        pmhealthSlider.value = pmhealthSlider.maxValue;



    }

    void Update()
    {

      


    }


    public void Restore(float amount)
    {


        currentHealth += amount;
        
        pmhealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            pmhealthSlider.value = currentHealth;
        }

    }

    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(pmdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("pmHealthCanvas"));
        tempRect.transform.position = pmbody.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = pmdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("pmhit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;
    public void TakeDamage(float amount)
    {

        if (amount - defense >= 0)
        {
            currentHealth -= amount-defense;
            takendamage = amount - defense;
            pmhealthSlider.value = currentHealth;
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
        pmHealthCanvas.enabled = false;
        penguinmaster.SetActive(false);


    }


}

