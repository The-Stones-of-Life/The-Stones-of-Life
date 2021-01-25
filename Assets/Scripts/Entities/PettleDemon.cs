using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettleDemon : AIBase
{
	
	public Rigidbody2D rb;
	
    void Start()
    {
		maxHealth = 7;
		player = GameObject.Find("Player").GetComponent<Player>();
		pHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        if (player.getPosX() <= this.getPosX()) {
			rb.AddForce(new Vector2(-1, 0));
		}
		
		if (player.getPosY() <= this.getPosY()) {
			rb.AddForce(new Vector2(0, -1));
		}
		
		if (player.getPosX() <= this.getPosX() && player.getPosY() <= this.getPosY()) {
			rb.AddForce(new Vector2(-1, -1));
		}
		 if (player.getPosX() >= this.getPosX()) {
			rb.AddForce(new Vector2(1, 0));
		}
		
		if (player.getPosY() >= this.getPosY()) {
			rb.AddForce(new Vector2(0, 1));
		}
		
		if (player.getPosX() >= this.getPosX() && player.getPosY() >= this.getPosY()) {
			rb.AddForce(new Vector2(1, 1));
		}
    }
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {

		}
	}
}
