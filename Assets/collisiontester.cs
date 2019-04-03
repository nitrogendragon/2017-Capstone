using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiontester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
            
        {
            Debug.Log("we hit");
        }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("we hit no more");
        }
    }
}
