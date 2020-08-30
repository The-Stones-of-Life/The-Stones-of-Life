using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceOpen : MonoBehaviour
{
   public GameObject furnaceCrafting;
	
	public bool isFOpen = false;
	
	void Update() {

		if (Input.GetKeyDown(KeyCode.Escape) && isFOpen == true) {
			isFOpen = false;
			furnaceCrafting.SetActive(false);
		}	
		
	}
	
	void OnTriggerStay2D(Collider2D coll) {	
	
		if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O) && isFOpen == false) {
			furnaceCrafting.SetActive(true);
			isFOpen = true;
		}	
	}
}
