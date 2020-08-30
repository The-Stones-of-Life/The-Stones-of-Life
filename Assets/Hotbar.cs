using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
	private List<Item> itemList;
	
	public event EventHandler OnItemListChanged;
	public InventoryUI invUi;
	
	void Start() {
		invUi = GameObject.Find("Hotbar").GetComponent<InventoryUI>();
	}
	
	public Hotbar() {
		itemList = new List<Item>();
	}
	
	public void AddItem(Item item) {
		if (item.IsStackable()) {
			bool itemAlreadyInInventory = false;
			foreach (Item invItem in itemList) {
				if (invItem.itemType == item.itemType) {
					invItem.ammount += item.ammount;
				}
			}
			if (!itemAlreadyInInventory) {
				itemList.Add(item);
			}
		} else {
			itemList.Add(item);
		}
		invUi.SetInventory(this);
	}
	
	public List<Item> GetItemList() {
		return itemList;
	}
}
