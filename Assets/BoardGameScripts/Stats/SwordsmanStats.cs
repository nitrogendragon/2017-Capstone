using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordsmanStats : MonoBehaviour
{
    public Camera mcamera;
    public GameObject sdamagetext;

    GameObject swordsman;
    GameObject swordsmanbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider smhealthSlider;

    public Canvas smHealthCanvas;

    public float speed = 20;
    public float defense = 3;
    public float attack = 14;
    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;



    public bool isDead;


    void Awake()
    {
        swordsman = GameObject.Find("Swordsman");
        swordsmanbody = GameObject.Find("SwordsmanBody");
        currentHealth = startingHealth;


        smhealthSlider.value = smhealthSlider.maxValue;



    }

    void Update()
    {

       


    }


    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(sdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("SwordsmanDamageCanvas"));
        tempRect.transform.position = swordsmanbody.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = sdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("swordsmanhit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;
    public void TakeDamage(float amount)
    {

        if (amount - defense > 0)
        {
            currentHealth -= amount-defense;
            takendamage = amount - defense;
            smhealthSlider.value = currentHealth;
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
 
        smhealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            smhealthSlider.value = currentHealth;
        }

    }
    public void Death()
    {
        smHealthCanvas.enabled = false;
        swordsman.SetActive(false);


    }


}
