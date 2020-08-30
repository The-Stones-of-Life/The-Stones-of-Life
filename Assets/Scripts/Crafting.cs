using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
  
	private Inventory2 inv;

	public GameObject plankRecipe;
	public GameObject dirtRecipe;
	public GameObject workbenchRecipe;
	
	public GameObject handCrafting;
	
	public bool isOpen = false;
	
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }
	
	void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.C)) {
			
			if (isOpen == false) {
				
				handCrafting.SetActive(true);
				isOpen = true;
			
			}
			
		}
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isOpen == true) {
			
				handCrafting.SetActive(false);
				isOpen = false;
			}
		}

        if (inv.logs >= 1) {
			
			plankRecipe.SetActive(true);
			
		}
		else {
			plankRecipe.SetActive(false);
		}
		
		if (inv.leaves >= 1) {
			
			dirtRecipe.SetActive(true);
			
		}
		else {
			dirtRecipe.SetActive(false);
		}
	
		if (inv.planks >= 20) {
			
			workbenchRecipe.SetActive(true);
			
		}
		else {
			workbenchRecipe.SetActive(false);
		}
    }
	
	public void CraftPlanks() {
		
		inv.logs -= 1;
		inv.planks += 5;
		
	}
	
	public void CraftWorkbench() {
		
		inv.planks -= 20;
		inv.workbench += 1;
		
	}
	
	public void CraftDirt() {
		
		inv.leaves -= 1;
		inv.dirtBlocks += 5;
		
	}
	

	
	
	public void OpenCraftingMenu() {
		
		if (isOpen == false) {
				
			handCrafting.SetActive(true);
			isOpen = true;
			
		}
	}
	
	public void CloseMenu() {
		
		if (isOpen == true) {
			
			handCrafting.SetActive(false);
			isOpen = false;
		}
	}
}
