using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TerrainEngine2D;

public class BlockPlacement : MonoBehaviour
{
	public enum Layers { Main }
	public enum MainLayer { Grass, Dirt, Stone }

	private LayerMask colliderMask;
	
	private int modifyRadius = 5;
	
	private int xGridPosition;
	 
	private int yGridPosition;
	
    void Update()
    {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        xGridPosition = Mathf.FloorToInt(mousePosition.x);
        yGridPosition = Mathf.FloorToInt(mousePosition.y);
		
		
		if (Input.GetMouseButtonDown(1)) {
									
			RaycastHit2D hit = Physics2D.BoxCast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), new Vector2(modifyRadius * 2 + 1 - 0.1f, modifyRadius * 2 + 1 - 0.1f), 0, Vector2.zero, 1, colliderMask);
						
			if (Player.selectedBlockId == 1 && Inventory.grassBlocks >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)1);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Grass, amount = 1 });
				Inventory.grassBlocks -= 1;
				return;
			}
			if (Player.selectedBlockId == 2 && Inventory.dirtBlocks >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)2);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Dirt, amount = 1 });
				Inventory.dirtBlocks -= 1;
				return;
			}
			if (Player.selectedBlockId == 3 && Inventory.stoneBlocks >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)3);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 1 });
				Inventory.stoneBlocks -= 1;
				return;
			}
			if (Player.selectedBlockId == 4 && Inventory.logs >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)4);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Log, amount = 1 });
				Inventory.logs -= 1;
				return;
			}
			if (Player.selectedBlockId == 5 && Inventory.leaves >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)5);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Leaves, amount = 1 });
				Inventory.leaves -= 1;
				return;
			}
			if (Player.selectedBlockId == 6 && Inventory.planks >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)6);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Planks, amount = 1 });
				Inventory.planks -= 1;
				return;
			}
			if (Player.selectedBlockId == 7 && Inventory.workbench >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)7);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
				Inventory.workbench -= 1;
				return;
			}
			if (Player.selectedBlockId == 8 && Inventory.ironOre >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)8);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronOre, amount = 1 });
				Inventory.ironOre -= 1;
				return;
			}
			if (Player.selectedBlockId == 9 && Inventory.furnace >= 1) {
				WorldModifier.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)9);
				Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Furnace, amount = 1 });
				Inventory.furnace -= 1;
				return;
			}
			return;
		}
    }
}
