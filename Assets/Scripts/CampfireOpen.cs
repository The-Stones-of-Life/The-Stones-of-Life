using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireOpen : MonoBehaviour
{
   	public bool isCOpen = false;
	public GameObject campfireCrafting;
	
	void Update() {
			
		if (Input.GetKeyDown(KeyCode.Escape) && isCOpen == true) {
			isCOpen = false;
			campfireCrafting.SetActive(false);
		}
		
	}
	
	
    void OnTriggerStay2D(Collider2D coll) {
		
		Debug.Log("coll");
		
		if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O) && isCOpen == false) {
				campfireCrafting.SetActive(true);
				isCOpen = true;
			}
		}
}
