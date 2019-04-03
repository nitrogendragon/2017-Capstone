using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Penguingodstats : MonoBehaviour

{
    public Camera mcamera;
    public GameObject pgdamagetext;

    GameObject penguingod;
    GameObject pgbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public float defense = 10;
    public float speed = 30;
    public float attack = 20;
    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;


    public Slider pghealthSlider;

    public Canvas pgHealthCanvas;





    public bool isDead;
    


    void Awake()
    {
        penguingod = GameObject.Find("PenguinGod");
        pgbody = GameObject.Find("PenguinGodBody");
        currentHealth = startingHealth;


        pghealthSlider.value = pghealthSlider.maxValue;



    }

    void Update()
    {

       
        

    }
    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(pgdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("pgHealthCanvas"));
        tempRect.transform.position = pgbody.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = pgdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("pghit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;

    public void Restore(float amount)
    {


        currentHealth += amount;
        
        pghealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            pghealthSlider.value = currentHealth;
        }

    }


    public void TakeDamage(float amount)
    {

        if (amount - defense >= 0)
        {
            currentHealth -= amount-defense;
            takendamage = amount - defense;
            pghealthSlider.value = currentHealth;
            InitDamageText(takendamage.ToString());
        }
        

        if (currentHealth <= 0 && !isDead)
        {

            isDead = true;
            Death();
        }
    }

    public void Death()
    {
        pgHealthCanvas.enabled = false;
        penguingod.SetActive(false);


    }


}
