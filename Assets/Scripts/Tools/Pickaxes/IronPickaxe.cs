﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronPickaxe : MonoBehaviour
{
   
	public static int damage = 15;
	public static int durability = 1000;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}

    // Update is called once per frame
    void Update()
    {
       if (durability <= 1) {
			inv.iron_pickaxe -= 1;
			isHolding = false;
		} 
    }
}
