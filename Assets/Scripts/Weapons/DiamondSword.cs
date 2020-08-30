using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSword : MonoBehaviour
{
    public static int damage = 15;
	public static int durability = 2000;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}
	void Update(){
		
		if (durability <= 1) {
			inv.diamond_sword -= 1;
			isHolding = false;
		}
	}
}
