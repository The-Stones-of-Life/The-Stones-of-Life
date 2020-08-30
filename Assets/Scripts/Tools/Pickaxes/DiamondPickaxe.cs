using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickaxe : MonoBehaviour
{
   
	public static int damage = 25;
	public static int durability = 2000;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}

    // Update is called once per frame
    void Update()
    {
       if (durability <= 1) {
			inv.diamond_pickaxe -= 1;
			isHolding = false;
		} 
    }
}
