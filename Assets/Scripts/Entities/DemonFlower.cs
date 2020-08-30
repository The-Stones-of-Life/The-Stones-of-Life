using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFlower : MonoBehaviour
{

	public int health = 45;

    void Update()
    {
        if (health <= 1)
		{
			Destroy(this.gameObject);
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
		
		if (StoneSword.isHolding == true) {
			
			health -= StoneSword.damage;
			StoneSword.durability -= 100;			
		}
		else {
		  health -= 1;
		}
		
		if (GoldSword.isHolding == true) {
			
			health -= GoldSword.damage;
			GoldSword.durability -= 100;			
		}
		else {
		  health -= 1;
		}
		
		if (DiamondSword.isHolding == true) {
			
			health -= DiamondSword.damage;
			DiamondSword.durability -= 100;			
		}
		else {
		  health -= 1;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Health.health -= 25 - PlayerDefence.defense;
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "FireSpell") {
			
			health -= 30;
			
		}
	}
}
