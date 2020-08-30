using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalWorknenchOpen : MonoBehaviour
{
    public GameObject mwMenu;
	
	public bool isMWOpen = false;
	
	void Update() {

		if (Input.GetKeyDown(KeyCode.Escape) && isMWOpen == true) {
			isMWOpen = false;
			mwMenu.SetActive(false);
		}	
		
	}
	
	void OnTriggerStay2D(Collider2D coll) {	
	
		if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O) && isMWOpen == false) {
			mwMenu.SetActive(true);
			isMWOpen = true;
		}	
	}
}
