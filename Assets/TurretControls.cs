using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControls : MonoBehaviour {

    // GameObject portalbarrel;
    // Update is called once per frame
    private void Awake()
    {
        //portalbarrel = GameObject.Find("PortalBarrel");
    }
    void Update () {
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 30);
        }
    
        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(Vector3.right* Time.deltaTime* 30);
        }
	
    if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.up* Time.deltaTime* 30);
        }
	
        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(Vector3.left* Time.deltaTime* 30);
        }
	}
}
