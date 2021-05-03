using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
	public GameObject plankRecipe;
	public GameObject dirtRecipe;
	public GameObject workbenchRecipe;
	public GameObject torchRecipe;
	public GameObject flamingTorchRecipe;
	public GameObject mysteriousTabletRecipe;


	public GameObject handCrafting;
	
	public bool isOpen = false;
	
    void Start()
    {
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

        if (Inventory.logs >= 1) {
			
			plankRecipe.SetActive(true);
			
		}
		else {
			plankRecipe.SetActive(false);
		}
		
		if (Inventory.planks >= 6) {
			
			workbenchRecipe.SetActive(true);
			
		}
		else {
			workbenchRecipe.SetActive(false);
		}

		if (Inventory.sticks >= 6  && Inventory.coal >= 1)
		{

			torchRecipe.SetActive(true);

		}
		else
		{
			torchRecipe.SetActive(false);
		}

		if (Inventory.stoneArrow >= 4 && Inventory.torch >= 1)
		{

			flamingTorchRecipe.SetActive(true);

		}
		else
		{
			flamingTorchRecipe.SetActive(false);
		}

		if (Inventory.mysteriousTabletShardOne >= 1 && Inventory.mysteriousTabletShardTwo >= 1 && Inventory.mysteriousTabletShardThree >= 1)
		{

			mysteriousTabletRecipe.SetActive(true);

		}
		else
		{
			mysteriousTabletRecipe.SetActive(false);
		}
	}
	
	public void CraftPlanks() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Log, amount = 1 });
		Inventory.logs -= 1;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Planks, amount = 6 });
		Inventory.planks += 6;
		
	}
	
	public void CraftWorkbench() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Planks, amount = 6 });
		Inventory.planks -= 6;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
		Inventory.workbench += 1;
		
	}

	public void CraftTorches()
	{

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sticks, amount = 6 });
		Inventory.sticks -= 6;

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Coal, amount = 1 });
		Inventory.coal -= 1;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Torch, amount = 6 });
		Inventory.torch += 6;

	}

	public void CraftFlamingArrows()
	{

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.StoneArrow, amount = 4 });
		Inventory.stoneArrow -= 4;

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Torch, amount = 1 });
		Inventory.torch -= 1;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.FlamingArrows, amount = 4 });
		Inventory.flamingArrow += 4;

	}

	public void CraftMysteriousTablet()
	{

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.MysertiousTabletShardOne, amount = 1 });
		Inventory.mysteriousTabletShardOne -= 1;

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.MysertiousTabletShardTwo, amount = 1 });
		Inventory.mysteriousTabletShardTwo -= 1;

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.MysertiousTabletShardThree, amount = 1 });
		Inventory.mysteriousTabletShardThree -= 1;


		Player.inventory.AddItem(new Item { itemType = Item.ItemType.MysertiousTablet, amount = 1 });
		Inventory.mysteriousTablet += 1;

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
