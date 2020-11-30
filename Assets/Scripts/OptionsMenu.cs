using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
 
	public bool isOpen = false;
	
	public GameObject OM;
	public GameObject CM;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && isOpen == false && Player.uiLock == false) {
			
			OM.SetActive(true);
			isOpen = true;
			
		}
		
		if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true) {
			
			OM.SetActive(false);
			CM.SetActive(false);
			isOpen = false;
			
		}
    }
	
	public void OpenControlsMenu() {
		
		CM.SetActive(true);
		
	}
}
