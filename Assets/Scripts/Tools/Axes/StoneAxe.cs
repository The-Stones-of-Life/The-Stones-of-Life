using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAxe : MonoBehaviour
{
	public static int damage = 2;
	public static int durability = 500;
	
	public static bool isHolding = false;
	
	private Inventory2 inv;
	
	void Start(){
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}

    // Update is called once per frame
    void Update()
    {
       if (durability <= 1) {
			inv.stone_axe -= 1;
			isHolding = false;
		} 
    }
}
