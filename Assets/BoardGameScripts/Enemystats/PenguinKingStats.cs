using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinKingStats : MonoBehaviour
{

    public Camera mcamera;
    public GameObject pkdamagetext;

    GameObject penguinking;
    GameObject pkbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider pkhealthSlider;

    public Canvas pkHealthCanvas;

    public float speed = 4;
    public float defense = 1;
    public float attack = 5;
    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;



    public bool isDead;


    void Awake()
    {
        penguinking = GameObject.Find("PenguinKing");
        pkbody = GameObject.Find("PenguinKingBody");
        currentHealth = startingHealth;


        pkhealthSlider.value = pkhealthSlider.maxValue;



    }

    void Update()
    {

      


    }


    public void Restore(float amount)
    {


        currentHealth += amount;
        
        pkhealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            pkhealthSlider.value = currentHealth;
        }

    }

    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(pkdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("pmHealthCanvas"));
        tempRect.transform.position = pkbody.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = pkdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("pkhit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;
    public void TakeDamage(float amount)
    {

        if (amount - defense >= 0)
        {
            currentHealth -= amount- defense;
            
            pkhealthSlider.value = currentHealth;

        }

        if (currentHealth <= 0 && !isDead)
        {

            isDead = true;
            Death();
        }
    }

    public void Death()
    {
        pkHealthCanvas.enabled = false;
        penguinking.SetActive(false);


    }


}
