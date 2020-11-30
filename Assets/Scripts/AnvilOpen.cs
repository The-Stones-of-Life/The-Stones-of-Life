using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilOpen : MonoBehaviour
{
	public GameObject anvilCrafting;
	
	public bool isAOpen = false;
	
	void Update() {

		if (Input.GetKeyDown(KeyCode.Escape) && isAOpen == true) {
			isAOpen = false;
			anvilCrafting.SetActive(false);
		}	
		
	}
	
	void OnTriggerStay2D(Collider2D coll) {	
	
		if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O) && isAOpen == false) {
			anvilCrafting.SetActive(true);
			isAOpen = true;
		}
		
	}
}
