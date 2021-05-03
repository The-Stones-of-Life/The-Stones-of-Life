using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public static Player Instance { get; private set; }

	public int damage = 1;
	public int selectedWeaponId = 0;
	public GameObject ironSword;
	
	public static bool sa1Active = false;
	public static bool sa2Active = false;
	
	public bool doAbilityStuff = false;
	
    private const float SPEED = 50f;

	public static bool justAttackedEntity = false;

	public GameObject arrow;
	public GameObject flamingArrow;
	public GameObject ironArrow;

	public static int selectedBlockId = 0;
	
	public Animation swordAnim;

	public bool isSwinging;
	
    [SerializeField] private UI_Inventory uiInventory;

    private Player_Base playerBase;
    private State state;
    public static Inventory inventory;
	public GameObject retroScreen;
	public InputField romFile;
	public GameObject romFileO;
	public static bool uiLock = false;
	public bool holdingBow = false;

	public GameObject lordPyrmid;

	public GameObject deathScreen;

    private enum State {
        Normal,
    }

    private void Awake() {
        Instance = this;
        playerBase = gameObject.GetComponent<Player_Base>();
		uiInventory = GameObject.Find("Canvas").GetComponent<UI_Inventory>();
        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);

		inventory.AddItem(new Item { itemType = Item.ItemType.IronIngot, amount = 80 });
		Inventory.ironIngot += 80;
		
		inventory.AddItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
		Inventory.workbench += 1;
		
		inventory.AddItem(new Item { itemType = Item.ItemType.Sticks, amount = 20 });
		Inventory.sticks += 20;

		inventory.AddItem(new Item { itemType = Item.ItemType.Torch, amount = 20 });
		Inventory.torch += 20;

		inventory.AddItem(new Item { itemType = Item.ItemType.IronArrow, amount = 200 });
		Inventory.ironArrow += 200;

		inventory.AddItem(new Item { itemType = Item.ItemType.MysertiousTablet, amount = 1 });
		Inventory.mysteriousTablet += 1;

		inventory.AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 50 });
		Inventory.healthPotion += 50;
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
		
		if (sa1Active && selectedWeaponId == 1) {
			
			if (!doAbilityStuff) {
				damage += 5;
				doAbilityStuff = true;
			}
			
			if (justAttackedEntity) {
				damage -= 5;
				sa1Active = false;
			}
		}
		
		if (justAttackedEntity) {
			justAttackedEntity = false;
		}

		if (Input.GetMouseButtonDown(1) && Inventory.stoneArrow >= 1 && holdingBow)
        {

			Ray mousePos = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

			if (mousePos.origin.x >= getPosX())
			{
				GameObject newArrow = Instantiate(arrow, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				newArrow.GetComponent<Arrow>().goLeft = true;
			} else
            {
				GameObject newArrow  = Instantiate(arrow, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				newArrow.GetComponent<Arrow>().goLeft = false;
				newArrow.GetComponent<Arrow>().rotateOnce = false;
			}
			Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.StoneArrow, amount = 1 });
			Inventory.stoneArrow -= 1;
		} else if (Input.GetMouseButtonDown(1) && Inventory.flamingArrow >= 1 && holdingBow)
		{

			Ray mousePos = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

			if (mousePos.origin.x >= getPosX())
			{
				GameObject newArrow = Instantiate(flamingArrow, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				newArrow.GetComponent<FlamingArrow>().goLeft = true;
			}
			else
			{
				GameObject newArrow = Instantiate(flamingArrow, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				newArrow.GetComponent<FlamingArrow>().goLeft = false;
				newArrow.GetComponent<FlamingArrow>().rotateOnce = false;
			}
			Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.FlamingArrows, amount = 1 });
			Inventory.flamingArrow -= 1;
		} else if (Input.GetMouseButtonDown(1) && Inventory.ironArrow >= 1 && holdingBow)
		{

			Ray mousePos = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

			if (mousePos.origin.x >= getPosX())
			{
				GameObject newArrow = Instantiate(ironArrow, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				newArrow.GetComponent<Arrow>().goLeft = true;
			}
			else
			{
				GameObject newArrow = Instantiate(ironArrow, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				newArrow.GetComponent<Arrow>().goLeft = false;
				newArrow.GetComponent<Arrow>().rotateOnce = false;
			}
			Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronArrow, amount = 1 });
			Inventory.ironArrow -= 1;
		}

		if (Health.health <= 0)
        {
			deathScreen.SetActive(true);
        }
	}

    private void UseItem(Item item) {
        switch (item.itemType) {
		case Item.ItemType.Grass:
			selectedBlockId = 1;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Dirt:
			selectedBlockId = 2;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Stone:
			selectedBlockId = 3;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Log:
			selectedBlockId = 4;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Leaves:
			selectedBlockId = 5;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Planks:
			selectedBlockId = 6;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Workbench:
			selectedBlockId = 7;
			selectedWeaponId = 0;
			damage = 1;
			Debug.Log(selectedBlockId);
			Debug.Log(Inventory.workbench);
			holdingBow = false;
			break;
		case Item.ItemType.IronOre:
			selectedBlockId = 8;
			damage = 1;
			selectedWeaponId = 0;
			holdingBow = false;
			break;
		case Item.ItemType.Furnace:
			selectedBlockId = 9;
			damage = 1;
			selectedWeaponId = 0;
			holdingBow = false;
			break;
		case Item.ItemType.Coal:
			damage = 1;
			selectedBlockId = 10;
			selectedWeaponId = 0;
			holdingBow = false;
			break;
		case Item.ItemType.RetroConsol:
			uiLock = true;
			damage = 1;
			selectedWeaponId = 0;
			romFileO.SetActive(true);
			holdingBow = false;
			break;
		case Item.ItemType.Anvil:
			selectedBlockId = 11;
			selectedWeaponId = 0;
			damage = 1;
			holdingBow = false;
			break;
		case Item.ItemType.IronSword:
			damage = 10;
			selectedWeaponId = 1;
			holdingBow = false;
			break;
		case Item.ItemType.Torch:
			selectedBlockId = 12;
			damage = 0;
			selectedWeaponId = 0;
			holdingBow = false;
			break;
		case Item.ItemType.WoodenBow:
			selectedBlockId = -1;
			damage = 0;
			selectedWeaponId = 0;
			holdingBow = true;
			break;
		case Item.ItemType.Sand:
			selectedBlockId = 13;
			damage = 1;
			selectedWeaponId = 0;
			holdingBow = false;
			break;
		case Item.ItemType.MysertiousTablet:
			GameObject lpb = Instantiate(lordPyrmid, new Vector2(getPosX() + 5, getPosY() + 5), Quaternion.identity);
			inventory.RemoveItem(new Item { itemType = Item.ItemType.MysertiousTablet, amount = 1 });
			Inventory.mysteriousTablet -= 1;
			break;
		case Item.ItemType.HealthPotion:
			selectedBlockId = -1;
			damage = 1;
			selectedWeaponId = 0;
			holdingBow = false;
			Health.health += 25;
			inventory.RemoveItem(new Item { itemType = Item.ItemType.MysertiousTablet, amount = 1 });
			break;
		case Item.ItemType.ThePyrmidsSword:
			damage = 25;
			selectedWeaponId = 2;
			holdingBow = false;
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

	public void Respawn()
    {
		Health.killPlayer();
		this.transform.position = new Vector3(11, 125, 0);
		deathScreen.SetActive(false);
	}
}
