using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COL : MonoBehaviour
{
    private Inventory2 inv;
	
	public static int filled_oil = 0;
	
    void Start()
    {
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }
	
	void OnTriggerStay2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.F)) {
				
				inv.crude_oil_ore -= 1;
				filled_oil += 20;
				
			}
		}
    }
}
