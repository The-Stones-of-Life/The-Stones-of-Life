using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManEater : AIBase
{
    void Start()
    {
        maxHealth = 5;
		player = GameObject.Find("Player").GetComponent<Player>();
		pHealth = GameObject.Find("Player").GetComponent<Health>();
    }
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			PlayerMovement.lockMovement = true;
		}
	}
}
