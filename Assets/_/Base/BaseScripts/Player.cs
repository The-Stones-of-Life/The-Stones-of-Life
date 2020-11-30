/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;
using UnityEngine.UI;
/*
 * Player movement with Arrow keys
 * Attack with Space
 * */
public class Player : MonoBehaviour {
    
    public static Player Instance { get; private set; }

	public int damage = 1;
	public int selectedWeaponId = 0;
	public GameObject ironSword;
	
    private const float SPEED = 50f;
    
	public static int selectedBlockId = 0;
	
	public Animation swordAnim;
	
    [SerializeField] private UI_Inventory uiInventory;

    private Player_Base playerBase;
    private State state;
    public static Inventory inventory;
	public GameObject retroScreen;
	public InputField romFile;
	public GameObject romFileO;
	public static bool uiLock = false;

    private enum State {
        Normal,
    }

    private void Awake() {
        Instance = this;
        playerBase = gameObject.GetComponent<Player_Base>();

        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);
		
		inventory.AddItem(new Item { itemType = Item.ItemType.IronIngot, amount = 80 });
		Inventory.ironIngot += 80;
		
		inventory.AddItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
		Inventory.workbench += 1;
		
		inventory.AddItem(new Item { itemType = Item.ItemType.Sticks, amount = 20 });
		Inventory.sticks += 20;
	}

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            // Touching Item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
			return;
        }
		return;
    }
	
	void Update() {
		
		if (Input.GetMouseButtonDown(0)) {
			Swing();
		}
		
		romFile.onEndEdit.AddListener(delegate{HideRomInput();});
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			retroScreen.SetActive(false);
			romFileO.SetActive(false);
			uiLock = false;
		}
	}

    private void UseItem(Item item) {
        switch (item.itemType) {
        case Item.ItemType.HealthPotion:
            inventory.RemoveItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
            break;
        case Item.ItemType.ManaPotion:
            inventory.RemoveItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
            break;
		case Item.ItemType.Grass:
			selectedBlockId = 1;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.Dirt:
			selectedBlockId = 2;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.Stone:
			selectedBlockId = 3;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.Log:
			selectedBlockId = 4;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.Leaves:
			selectedBlockId = 5;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.Planks:
			selectedBlockId = 6;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.Workbench:
			selectedBlockId = 7;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.IronOre:
			selectedBlockId = 8;
			damage = 1;
			selectedWeaponId = 0;
			break;
		case Item.ItemType.Furnace:
			selectedBlockId = 9;
			damage = 1;
			selectedWeaponId = 0;
			break;
		case Item.ItemType.Coal:
			damage = 1;
			selectedBlockId = 10;
			selectedWeaponId = 0;
			break;
		case Item.ItemType.RetroConsol:
			uiLock = true;
			damage = 1;
			selectedWeaponId = 0;
			romFileO.SetActive(true);
			break;
		case Item.ItemType.Anvil:
			selectedBlockId = 11;
			selectedWeaponId = 0;
			damage = 1;
			break;
		case Item.ItemType.IronSword:
			damage = 10;
			selectedWeaponId = 1;
			break;
        }
	}
	
	public void Swing() {
	
	}
	
	public void HideRomInput() {
		
		romFileO.SetActive(false);
		retroScreen.SetActive(true);
		
	}
	
    public Vector3 GetPosition() {
        return transform.position;
    }
	
	public float getPosX() {
		return transform.position.x;
	}
	
	public float getPosY() {
		return transform.position.y;
	}
}
