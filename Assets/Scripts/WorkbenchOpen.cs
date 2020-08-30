using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchOpen : MonoBehaviour
{
	
	public bool isWOpen = false;
	public GameObject workbenchCrafting;
	
	void Update() {
			
		if (Input.GetKeyDown(KeyCode.Escape) && isWOpen == true) {
			isWOpen = false;
			workbenchCrafting.SetActive(false);
		}
		
	}
	
	
    void OnTriggerStay2D(Collider2D coll) {
		
		Debug.Log("coll");
		
		if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O) && isWOpen == false) {
				workbenchCrafting.SetActive(true);
				isWOpen = true;
			}
		}
}
