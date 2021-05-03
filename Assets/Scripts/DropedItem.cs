using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DropedItem : MonoBehaviour
{
	public int dropId;
	
	private Inventory2 inv;
	
	public GameObject grass;
	public GameObject dirt;
	public GameObject stone;
	public GameObject log;
	public GameObject leaves;
	public GameObject planks;
	public GameObject sticks;
	public GameObject workbench;
	public GameObject ironOre;
	public GameObject furnace;	
	public GameObject coal;
	public GameObject anvil;
	public GameObject brownMushroom;
	public GameObject lifehshroom;
	public GameObject sand;

	public GameObject dropedItem;

	void Start() {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
			
		}
    }
	
	public void DropItem(int id, int x, int y) {
		if (id == 1) {
			dropedItem = Instantiate(grass, new Vector2(x, y), Quaternion .identity);
		}
		if (id == 2) {
			dropedItem = Instantiate(dirt, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 3) {
			dropedItem = Instantiate(stone, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 4) {
			dropedItem = Instantiate(log, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 5) {
			dropedItem = Instantiate(leaves, new Vector2(x, y), Quaternion.identity);
			if (Random.Range(0, 5) == 0) {
				dropedItem = Instantiate(sticks, new Vector2(x, y + 1), Quaternion.identity);
			}
		}
		if (id == 6) {
			dropedItem = Instantiate(planks, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 7) {
			Instantiate(workbench, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 8) {
			dropedItem = Instantiate(ironOre, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 9) {
			dropedItem = Instantiate(furnace, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 10) {
			dropedItem = Instantiate(coal, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 11) {
			dropedItem = Instantiate(anvil, new Vector2(x, y), Quaternion.identity);
		}
		if (id == 12)
		{
			dropedItem = Instantiate(sand, new Vector2(x, y), Quaternion.identity);
		}

		if (dropedItem != null)
        {
			NetworkServer.Spawn(dropedItem);
		}
	}
	
	public void DropBackgroundItem(int id, int x, int y) {
		if (id == 3) {
			dropedItem = Instantiate(brownMushroom, new Vector2(x, y), Quaternion .identity);
		}
		if (id == 4) {
			dropedItem = Instantiate(lifehshroom, new Vector2(x, y), Quaternion.identity);
		}
	}
}
