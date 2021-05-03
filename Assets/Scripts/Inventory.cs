using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;
	
	public static int grassBlocks = 0;
	public static int dirtBlocks = 0;
	public static int stoneBlocks = 0;
	public static int logs = 0;
	public static int leaves = 0;
	public static int planks = 0;
	public static int sticks = 0;
	public static int workbench = 0;
	public static int ironOre = 0;
	public static int furnace = 0;
	public static int ironIngot = 0;
	public static int coal = 0;
	public static int ironWire = 0;
	public static int ironButton = 0;
	public static int electronicCase = 0;
	public static int basicScreen = 0;
	public static int retroConsol = 0;
	public static int anvil = 0;
	public static int ironSword = 0;
	public static int woodenBow = 0;
	public static int stoneArrow = 0;
	public static int plantFiberSacks = 0;
	public static int brownMushroom = 0;
	public static int lifeshroom = 0;
    public static int torch = 0;
    public static int flamingArrow = 0;
    public static int mysteriousTabletShardOne = 0;
    public static int mysteriousTabletShardTwo = 0;
    public static int mysteriousTabletShardThree = 0;
    public static int mysteriousTablet = 0;
    public static int sand = 0;
    public static int glassBottles = 0;
    public static int healthPotion = 0;
    public static int thePyrmidsSword = 0;
    public static int ironArrow = 0;
    public static int copperOre = 0;
    public static int copperIngot = 0;


    public Inventory(Action<Item> useItemAction) {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
    }

    public void AddItem(Item item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
		return;
    }

    public void RemoveItem(Item item) {
        if (item.IsStackable()) {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item) {
        useItemAction(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }

}
