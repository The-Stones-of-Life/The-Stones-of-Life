using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{

	public Inventory2 inv;
	
	public int health = 20;	
	public int speed = 3;

    void Start() {

	inv = GameObject.Find("Inventory").GetComponent<Inventory2>();

    }
	
    void Update()
    {		
       	if (health <= 1)
		{
			Destroy(this.gameObject);
			inv.raw_chicken += 2;
			
		}

		Vector3 pos = transform.position;
		pos.x = pos.x + speed * Time.deltaTime;
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
}
