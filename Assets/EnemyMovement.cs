using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    GameObject player;
    GameObject enemycapsule;
    PlayerAttack playerattack;
    float speed;
	// Use this for initialization
	void Awake () {
        enemycapsule = GameObject.Find("EnemyCapsule");
        player = GameObject.Find("Player");
        playerattack = player.GetComponent<PlayerAttack>();
	}
	
	// Update is called once per frame
	void Update () {
        move_enemy();
    }
    private void move_enemy()
    {
        speed = .03f;
        if (playerattack.distance <= 40)//references the distance function in playerattackscript
        {
            // enemycapsule.transform.position = Vector3.Lerp(enemycapsule.transform.position, player.transform.position, Time.time);
            enemycapsule.transform.position = Vector3.MoveTowards(enemycapsule.transform.position, player.transform.position, .03f);
        }
    }
}
