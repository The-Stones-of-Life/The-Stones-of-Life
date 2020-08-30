using System.Collections;
using System.Collections;
using Unity.RemoteConfig;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
	public GameObject drop;
	
	public int blockId;
	public int health;
	public bool isWood;
	public bool isStone;
	public bool isDirt;

	public struct userAttributes {	
	}

	public struct appAttributes {
	}

	public AudioSource dirt;
	public AudioSource stone;
	public AudioSource wood;

	private Inventory2 inv;
	
	public int CMHealth;
	
	public Transform trans;

	void Awake () {
        // Add a listener to apply settings when successfully retrieved:
        ConfigManager.FetchCompleted += ApplyRemoteSettings;
		
        // Fetch configuration setting from the remote service:
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

	void ApplyRemoteSettings(ConfigResponse configResponse) {
		
		CMHealth = ConfigManager.appConfig.GetInt("CMBlockHealth");
		
		health += CMHealth;	
	}
	
	void Start() {
		
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
	}
	
	void Update() {
		
		if (health <= 1)
		{
			Destroy(this.gameObject);
			
			Instantiate(drop, new Vector2(trans.position.x, trans.position.y), Quaternion.identity);
		}
		
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
		
		if (IronPickaxe.isHolding == true && isStone == true) {
			
			IronPickaxe.durability -= 10;
			health -= IronPickaxe.damage;
			
		}
		else {
			health -= 1;
		}
		if (DiamondPickaxe.isHolding == true && isStone == true) {
			
			DiamondPickaxe.durability -= 10;
			health -= DiamondPickaxe.damage;
			
		}
		else {
			health -= 1;
		}
		if (StonePickaxe.isHolding == true && isStone == true) {
			
			StonePickaxe.durability -= 10;
			health -= StonePickaxe.damage;
			
		}
		else {
			health -= 1;
		}
		if (GoldPickaxe.isHolding == true && isStone == true) {
			
			GoldPickaxe.durability -= 10;
			health -= GoldPickaxe.damage;
			
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
		
		if (StoneAxe.isHolding == true && isWood == true) {
			health -= StoneAxe.damage;
			StoneAxe.durability -= 10;
		}
		else {
			health -= 1;
		}
		if (GoldAxe.isHolding == true && isWood == true) {
			health -= GoldAxe.damage;
			GoldAxe.durability -= 10;
		}
		else {
			health -= 1;
		}
		if (DiamondAxe.isHolding == true && isWood == true) {
			health -= DiamondAxe.damage;
			DiamondAxe.durability -= 10;
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
		
		if (StonePickaxe.isHolding && isWood == true) {
			StonePickaxe.durability -= 20;
		}
		
		if (StoneAxe.isHolding && isStone == true) {
			StoneAxe.durability -= 20;
		}
		if (GoldPickaxe.isHolding && isWood == true) {
			GoldPickaxe.durability -= 20;
		}
		
		if (GoldAxe.isHolding && isStone == true) {
			GoldAxe.durability -= 20;
		}
		
		if (DiamondPickaxe.isHolding && isWood == true) {
			DiamondPickaxe.durability -= 20;
		}
		
		if (DiamondAxe.isHolding && isStone == true) {
			DiamondAxe.durability -= 20;
		}
	}
}
