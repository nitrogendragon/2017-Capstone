using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeWarriorStats : MonoBehaviour
{
    public Camera mcamera;
    public GameObject cwdamagetext;

    GameObject cubewarrior;
    GameObject cubewarriorbody;
    public float startingHealth = 100;
    public float currentHealth = 100;
    public Slider cwhealthSlider;

    public Canvas cwHealthCanvas;


    public float speed = 13;
    public float defense = 6;
    public float attack = 9;

    public int level = 1;
    public int maxlevel = 70;
    public int experience = 0;
    public int experienceleft = 10;

    public bool isDead;


    void Awake()
    {
        cubewarrior = GameObject.Find("CubeWarrior");
        cubewarriorbody = GameObject.Find("CubeWarriorBody");
        currentHealth = startingHealth;


        cwhealthSlider.value = cwhealthSlider.maxValue;



    }

    void Update()
    {

    


    }


    public void Restore(float amount)
    {


        currentHealth += amount;
       
        cwhealthSlider.value = currentHealth;
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
            cwhealthSlider.value = currentHealth;
        }

    }

    void InitDamageText(string damagetaken)
    {
        GameObject temp = Instantiate(cwdamagetext) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("cwHealthCanvas"));
        tempRect.transform.position = cubewarriorbody.transform.position + Vector3.up * 15;
        tempRect.transform.localScale = cwdamagetext.transform.localScale;
        tempRect.transform.rotation = mcamera.transform.rotation;
        temp.GetComponent<Text>().text = damagetaken;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("cwhit");
        Destroy(temp.gameObject, 1);
    }

    float takendamage;
    public void TakeDamage(float amount)
    {

        if (amount - defense > 0)
        {
            currentHealth -= amount-defense;
            
            cwhealthSlider.value = currentHealth;
            takendamage = amount - defense;

           
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
        cwHealthCanvas.enabled = false;
        cubewarrior.SetActive(false);


    }


}
