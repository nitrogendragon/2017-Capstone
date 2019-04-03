using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth = 100;
    public Slider healthSlider;
    public Image DamageImage;
    
    
   
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    Player player;
   // Animator anim;
    public AudioSource playerdeathAudio;
    public bool isDead;
    bool damaged;
    
   
    void Awake()
    {


        
        currentHealth = startingHealth;
        player = GetComponent<Player>();
        DamageImage.enabled = false;
        healthSlider.value = healthSlider.maxValue;



    }

    void Update()
    {
        
        
       
    }

    void Restart()
    {

    }

    public void Button_Click()
    {
        Debug.Log("hello, World!");
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

       // playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
           
            
            Death();
        }
    }

    public void Death()
    {
       
        isDead = true;

        //   anim.SetTrigger("Die");
        if (isDead == true)
        {
            
           
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            //audio.Play(44100);
            DamageImage.enabled = true;
            

            
            
        }
     //   player.enabled = false;
    }
}
