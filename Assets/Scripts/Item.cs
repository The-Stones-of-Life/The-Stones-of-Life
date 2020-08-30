using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
		
		Grass,
		Dirt,
		Stone,
		Log,
		Leaves
		
	}
	
	public ItemType itemType;
	public int ammount;
	
	public Sprite GetSprite() {
		
		switch (itemType) {
			default:
			case ItemType.Grass: 	return ItemAssets.Instance.grassSprite;
			case ItemType.Dirt: 	return ItemAssets.Instance.dirtSprite;
			case ItemType.Stone: 	return ItemAssets.Instance.stoneSprite;
			case ItemType.Log: 	return ItemAssets.Instance.logSprite;
			case ItemType.Leaves: 	return ItemAssets.Instance.leavesSprite;
		}
		
	}
	
	public bool IsStackable() {
		
		switch (itemType) {
			
			default:
			case ItemType.Grass:
			case ItemType.Dirt:
			case ItemType.Stone:
			case ItemType.Log:
			case ItemType.Leaves:
				return true;
			
		}
		
	}
}
