using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacecraft : MonoBehaviour
{
	
	public static bool isFueling = false;
	public static int fuel = 0;
	
	void OnTriggerStay2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Player") {
			
			if (Input.GetKeyDown(KeyCode.F)) {
				
				if (COL.filled_oil >= 10) {
					
					fuel += 10;
					
				}
				
			}
			
		}
    }
}
