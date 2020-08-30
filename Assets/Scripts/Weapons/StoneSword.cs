using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSword : MonoBehaviour
{
    public static int damage = 3;
	public static int durability = 500;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}
	void Update(){
		
		if (durability <= 1) {
			inv.stone_sword -= 1;
			isHolding = false;
		}
	}
}
