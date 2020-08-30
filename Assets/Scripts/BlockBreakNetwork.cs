using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class BlockBreakNetwork : NetworkBehaviour
{
	public NetworkIdentity drop;
	
	public int blockId;
	public int health;
	public bool isWood;
	public bool isStone;
	public bool isDirt;


	public AudioSource dirt;
	public AudioSource stone;
	public AudioSource wood;

	private Inventory2 inv;
	
	public Transform trans;

	void Start() {
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}
	
    void OnMouseDown() {
		
		if (isDirt == true) {
			
			dirt.Play(0);
			
		}
		
		if (isStone == true) {
			
			stone.Play(0);
			
		}
		
		if (isWood == true) {
			
			wood.Play(0);
			
		}
		
		
		if (health <= 1)
		{
			NetworkServer.Destroy(this.gameObject);
			
			GameObject itemDrop = Instantiate(drop.gameObject, new Vector2(trans.position.x, trans.position.y), Quaternion.identity);
			NetworkServer.Spawn(itemDrop);
			SceneManager.MoveGameObjectToScene(itemDrop, gameObject.scene);
		}
		
		if (IronPickaxe.isHolding == true && isStone == true) {
			
			IronPickaxe.durability -= 10;
			health -= IronPickaxe.damage;
			
		}
		else {
			health -= 1;
		}
		
		if (IronAxe.isHolding == true && isWood == true) {
			health -= IronAxe.damage;
			IronAxe.durability -= 10;
		}
		else {
			health -= 1;
		}
		
		if (IronPickaxe.isHolding && isWood == true) {
			IronPickaxe.durability -= 20;
		}
		
		if (IronAxe.isHolding && isStone == true) {
			IronAxe.durability -= 20;
		}
	}
}
