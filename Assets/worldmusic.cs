using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class worldmusic : MonoBehaviour
{

    public AudioMixerSnapshot outOfCombat;
    public AudioMixerSnapshot inCombat;
    public AudioMixerSnapshot restArea;
    public AudioMixerSnapshot enemyengaged;
    public AudioClip[] stings;
    public AudioSource stingSource;
    public float bpm = 120;
    public int stingindex = 0;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

   

    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 10; //very slow fade out consider changing
        PlaySting();
        Debug.Log(stingindex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            inCombat.TransitionTo(m_TransitionIn);//transition over length transition in
            
        }
        
        if (other.CompareTag("CombatZone2")) {
            restArea.TransitionTo(m_TransitionIn);
        }

        if (other.CompareTag("EnemyEngaged"))
        {
            enemyengaged.TransitionTo(m_TransitionIn);//transition over length transition in

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CombatZone"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);//transition over length transition out
        }
        if (other.CompareTag("CombatZone2"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);
        }
        if (other.CompareTag("EnemyEngaged"))
        {
            outOfCombat.TransitionTo(m_TransitionOut);
        }
    }
    void PlaySting()
    {
        //   int randClip = Random.Range(0, stings.Length);
        //   stingSource.clip = stings[randClip];
        stingSource.clip = stings[stingindex];
        stingSource.Play();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && stingindex == 1)
        {
            stingindex -= 1;
            Debug.Log(stingindex);
            PlaySting();
        }
        else if(Input.GetKeyUp(KeyCode.C) && stingindex == 0)
        {
            Debug.Log(stingindex);
            stingindex += 1;
            Debug.Log(stingindex);
            PlaySting();
        }
            if (!stingSource.isPlaying && stingindex == 1)
            {
                stingindex -= 1;
                PlaySting();
            }
            else if (!stingSource.isPlaying)
            {
                stingindex += 1;
                PlaySting();
            }
        
    }
}


