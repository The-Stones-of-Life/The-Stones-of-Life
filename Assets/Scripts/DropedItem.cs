using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour
{
	public int dropId;
	
	private Inventory2 inv;
	
	public Hotbar hb;
	
	public InventoryUI invUi;
	
	public string drop;		
	
	void Start() {
		hb = GameObject.Find("Hotbar").GetComponent<Hotbar>();
		invUi = GameObject.Find("Hotbar").GetComponent<InventoryUI>();
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
			
			if (dropId == 0) {
				hb.AddItem(new Item {itemType= Item.ItemType.Grass, ammount = 1});
				Destroy(this.gameObject);
			}
			if (dropId == 1) {
				hb.AddItem(new Item {itemType= Item.ItemType.Dirt, ammount = 1});
				Destroy(this.gameObject);
			}
			if (dropId == 2) {
				hb.AddItem(new Item {itemType= Item.ItemType.Stone, ammount = 1});
				Destroy(this.gameObject);
			}
			if (dropId == 4) {
				hb.AddItem(new Item {itemType= Item.ItemType.Log, ammount = 1});
				Destroy(this.gameObject);
			}
			if (dropId == 3) {
				hb.AddItem(new Item {itemType= Item.ItemType.Leaves, ammount = 1});
				Destroy(this.gameObject);
			}
		}
    }
}
