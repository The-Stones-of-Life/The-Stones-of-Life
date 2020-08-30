using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneWorkbenchOpen : MonoBehaviour
{
	
	public bool isAWOpen = false;
	public GameObject arcaneWorkbenchCrafting;
	
	void Update() {
			
		if (Input.GetKeyDown(KeyCode.Escape) && isAWOpen == true) {
			isAWOpen = false;
			arcaneWorkbenchCrafting.SetActive(false);
		}
		
	}
	
	
    void OnTriggerStay2D(Collider2D coll) {
		
		Debug.Log("coll");
		
		if (coll.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.O) && isAWOpen == false) {
				arcaneWorkbenchCrafting.SetActive(true);
				isAWOpen = true;
			}
		}
}
