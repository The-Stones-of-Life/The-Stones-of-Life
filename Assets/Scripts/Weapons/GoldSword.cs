using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSword : MonoBehaviour
{
    public static int damage = 10;
	public static int durability = 1500;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}
	void Update(){
		
		if (durability <= 1) {
			inv.gold_sword -= 1;
			isHolding = false;
		}
	}
}
