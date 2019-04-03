using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewithmouseclick : MonoBehaviour {
	public GameObject target;
	public float xchange = 5;
	public float zchange = 0;
	void Update ()
	{
		
		//if (Input.GetMouseButtonDown (0)) {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			xchange += 1;
			target.transform.position = new Vector3 (xchange, 0, zchange);

		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			xchange += -1;
			target.transform.position = new Vector3 (xchange, 0, zchange);

		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			zchange += -1;
			target.transform.position = new Vector3 (xchange, 0, zchange);

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			zchange += 1;
			target.transform.position = new Vector3 (xchange, 0, zchange);

		}
	}
}
			