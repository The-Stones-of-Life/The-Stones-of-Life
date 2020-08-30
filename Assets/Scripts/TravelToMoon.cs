using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelToMoon : MonoBehaviour
{
  
   private Inventory2 inv;
   
    void Update()
    {
        inv = GameObject.Find("Player").GetComponent<Inventory2>();
    }
	
	void OnTriggerStay2D(Collider2D coll) {	
	
		if (Spacecraft.fuel >= 150) {
			if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O)) {
				Spacecraft.fuel -= 150;
				inv.SaveInv();
				SceneManager.LoadScene(2);
			}
		}			
	}
}
