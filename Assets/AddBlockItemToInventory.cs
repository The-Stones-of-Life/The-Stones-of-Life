using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlockItemToInventory : MonoBehaviour
{
	
	public int id;
	
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
			if (id == 0) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Grass, amount = 1 });
				Inventory.grassBlocks += 1;
				Destroy(this.gameObject);
			}
			if (id == 1) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Dirt, amount = 1 });
				Inventory.dirtBlocks += 1;
				Destroy(this.gameObject);
			}
			if (id == 2) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Stone, amount = 1 });
				Inventory.stoneBlocks += 1;
				Destroy(this.gameObject);
			}
			if (id == 3) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Log, amount = 1 });
				Inventory.logs += 1;
				Destroy(this.gameObject);
			}
			if (id == 4) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Leaves, amount = 1 });
				Inventory.leaves += 1;
				Destroy(this.gameObject);
			}
			if (id == 5) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Planks, amount = 1 });
				Inventory.planks += 1;
				Destroy(this.gameObject);
			}
			if (id == 6) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Sticks, amount = 1 });
				Inventory.sticks += 1;
				Destroy(this.gameObject);
			}
			if (id == 7) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
				Inventory.workbench += 1;
				Destroy(this.gameObject);
			}
			if (id == 8) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronOre, amount = 1 });
				Inventory.ironOre += 1;
				Destroy(this.gameObject);
			}
			if (id == 9) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Furnace, amount = 1 });
				Inventory.furnace += 1;
				Destroy(this.gameObject);
			}
			if (id == 10) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Coal, amount = 1 });
				Inventory.coal += 1;
				Destroy(this.gameObject);
			}
			if (id == 11) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Anvil, amount = 1 });
				Inventory.anvil += 1;
				Destroy(this.gameObject);
			}
			if (id == 12) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.BrownMushroom, amount = 1 });
				Inventory.brownMushroom += 1;
				Destroy(this.gameObject);
			}
			if (id == 13) {
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Lifeshroom, amount = 1 });
				Inventory.lifeshroom += 1;
				Destroy(this.gameObject);
			}
			if (id == 14)
			{
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.Sand, amount = 1 });
				Inventory.sand += 1;
				if (Random.Range(0, 2) == 0)
                {
					Player.inventory.AddItem(new Item { itemType = Item.ItemType.MysertiousTabletShardOne, amount = 1 });
					Inventory.mysteriousTabletShardOne += 1;
				} else if (Random.Range(0, 2) == 0)
				{
					Player.inventory.AddItem(new Item { itemType = Item.ItemType.MysertiousTabletShardTwo, amount = 1 });
					Inventory.mysteriousTabletShardTwo += 1;
				} else if (Random.Range(0, 2) == 0)
				{
					Player.inventory.AddItem(new Item { itemType = Item.ItemType.MysertiousTabletShardThree, amount = 1 });
					Inventory.mysteriousTabletShardThree += 1;
				}
				Destroy(this.gameObject);
			}
		}
    }
}
