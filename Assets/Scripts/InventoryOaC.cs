using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOaC : MonoBehaviour
{
    public GameObject inv;
	
	public bool isOpen = false;
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isOpen == false)
		{
			inv.SetActive(true);
		}  
		
		if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
		{
			inv.SetActive(false);
		}
		
	
    }
}
