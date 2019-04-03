using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechStats : MonoBehaviour
{
    public Camera mcamera;
    public GameObject mdamagetext;

    GameObject mech;
    
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider mechhealthSlider;

    public Canvas mechHealthCanvas;


    public float speed = 10;
    public float defense = 12;
    public float attack = 10;
    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;


    public bool isDead;


    void Awake()
    {
        mech = GameObject.Find("mech");
        
        currentHealth = startingHealth;


        mechhealthSlider.value = mechhealthSlider.maxValue;



    }

    void Update()
    {

       


    }


    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(mdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("mechHealthCanvas"));
        tempRect.transform.position = mech.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = mdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("mechhit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;
    public void TakeDamage(float amount)
    {

        if (amount - defense > 0)
        {
            currentHealth -= amount-defense;
            takendamage = amount - defense;
            mechhealthSlider.value = currentHealth;
            
            
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
       
        mechhealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            mechhealthSlider.value = currentHealth;
        }

    }
    public void Death()
    {
        mechHealthCanvas.enabled = false;
        mech.SetActive(false);


    }


}
