using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotf : MonoBehaviour
{
    public int health = 500;
	public GameObject acornBullet;
	public Transform trans;
	
    void Update()
    {
        if (health <= 1)
		{
			Destroy(this.gameObject);
		}
		
		if (Random.Range(1, 35) == 1) {
			Instantiate(acornBullet, new Vector2(trans.position.x, trans.position.y), Quaternion.identity);
		}
    }
	
	void OnMouseDown() {
		
		if (IronSword.isHolding == true) {
			
			health -= IronSword.damage;
			IronSword.durability -= 100;			
		}
		else {
		  health -= 1;
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Health.health -= 7 - PlayerDefence.defense;
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "FireSpell") {
			
			health -= 3;
			
		}
	}
}
