using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignBullet : MonoBehaviour {
    GameObject enemycapsule;
	// Use this for initialization
	void Awake () {
        enemycapsule = GameObject.Find("EnemyCapsule");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = enemycapsule.transform.position - transform.position;

        v.x = v.z = 0.0f;

        transform.LookAt(enemycapsule.transform.position - v);

        transform.Rotate(0, 180, 0);
    }
}
