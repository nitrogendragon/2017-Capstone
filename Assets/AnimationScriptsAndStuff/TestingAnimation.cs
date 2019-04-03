using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animation>().Play("NewAnimation");
        //GetComponent<Animation>().Play("New Animation2");
    }
}
