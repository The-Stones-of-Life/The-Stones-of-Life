using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
	public GameObject plankRecipe;
	public GameObject dirtRecipe;
	public GameObject workbenchRecipe;
	
	public GameObject handCrafting;
	
	public bool isOpen = false;
	
    void Start()
    {
    }
	
	void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.C)) {
			
			if (isOpen == false && Player.uiLock == false) {
				
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

        if (Inventory.logs >= 1) {
			
			plankRecipe.SetActive(true);
			
		}
		else {
			plankRecipe.SetActive(false);
		}
		
		if (Inventory.planks >= 12) {
			
			workbenchRecipe.SetActive(true);
			
		}
		else {
			workbenchRecipe.SetActive(false);
		}
    }
	
	public void CraftPlanks() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Log, amount = 1 });
		Inventory.logs -= 1;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Planks, amount = 6 });
		Inventory.planks += 6;
		
	}
	
	public void CraftWorkbench() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Planks, amount = 12 });
		Inventory.planks -= 12;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
		Inventory.workbench += 1;
		
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
