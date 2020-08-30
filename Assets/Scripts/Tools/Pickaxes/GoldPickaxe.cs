using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickaxe : MonoBehaviour
{
   
	public static int damage = 20;
	public static int durability = 1500;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}

    // Update is called once per frame
    void Update()
    {
       if (durability <= 1) {
			inv.gold_pickaxe -= 1;
			isHolding = false;
		} 
    }
}
