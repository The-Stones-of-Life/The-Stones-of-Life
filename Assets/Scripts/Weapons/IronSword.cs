using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSword : MonoBehaviour
{
    public static int damage = 5;
	public static int durability = 1000;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}
	void Update(){
		
		if (durability <= 1) {
			inv.iron_sword -= 1;
			isHolding = false;
		}
	}
}
