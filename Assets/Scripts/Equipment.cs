using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
   
	private Inventory2 inv;
   
	public GameObject equipmentUI;
   
	public bool isEOpen = false;
	
	public GameObject IronSwordB;
	public GameObject IronAxeB;
	public GameObject IronPickaxeB;	
	public GameObject StoneSwordB;
	public GameObject StoneAxeB;
	public GameObject StonePickaxeB;
	public GameObject GoldSwordB;
	public GameObject GoldAxeB;
	public GameObject GoldPickaxeB;	
	public GameObject DiamondSwordB;
	public GameObject DiamondAxeB;
	public GameObject DiamondPickaxeB;
	public GameObject magicStaffB;
	public GameObject ironHelmetB;
	public GameObject ironChestplateB;
	public GameObject ironLeggingsB;
	
	public static bool hasMagicStaffT1 = false;
	
	public bool hasItemEquiped = false;
	public int heldID = 100000;
    		
	public GameObject ironSword;
	public GameObject ironAxe;
	public GameObject ironPickaxe;
	public GameObject magicStaff;
	public GameObject stoneSword;
	public GameObject stoneAxe;
	public GameObject stonePickaxe;	
	public GameObject goldSword;
	public GameObject goldAxe;
	public GameObject goldPickaxe;
	public GameObject diamondSword;
	public GameObject diamondAxe;
	public GameObject diamondPickaxe;
	
	public GameObject IronChestplate;
	public GameObject IronHelmet;
	public GameObject IronLeggings;
    
    void Start()
    {
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();  
    }
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEOpen == false && Player.uiLock == false) {
			
			equipmentUI.SetActive(true);
			isEOpen = true;
			
		}
		
		if (Input.GetKeyDown(KeyCode.Escape) && isEOpen == true) {
			
			equipmentUI.SetActive(false);
			isEOpen = false;
			
		}
		
		if (heldID == 0 && inv.iron_sword >= 1) {
			IronSword.isHolding = true;
			ironSword.SetActive(true);
		}
		else {
			IronSword.isHolding = false;
			ironSword.SetActive(false);
		}
		if (heldID == 1 && inv.iron_axe >= 1) {
			IronAxe.isHolding = true;
			ironAxe.SetActive(true);
		}
		else {
			IronAxe.isHolding = false;
			ironAxe.SetActive(false);
		}
		if (heldID == 2 && inv.iron_pickaxe >= 1) {
			IronPickaxe.isHolding = true;
			ironPickaxe.SetActive(true);
		}
		else {
			IronPickaxe.isHolding = false;
			ironPickaxe.SetActive(false);
		
		}
		if (heldID == 3 && inv.magic_staff >= 1) {
			hasMagicStaffT1 = true;
			magicStaff.SetActive(true);
		}
		else {
			hasMagicStaffT1 = false;
			magicStaff.SetActive(false);
		}
		if (heldID == 4 && inv.stone_sword >= 1) {
			StoneSword.isHolding = true;
			stoneSword.SetActive(true);
		}
		else {
			StoneSword.isHolding = false;
			stoneSword.SetActive(false);
		}
		if (heldID == 5 && inv.stone_axe >= 1) {
			StoneAxe.isHolding = true;
			stoneAxe.SetActive(true);
		}
		else {
			StoneAxe.isHolding = false;
			stoneAxe.SetActive(false);
		}
		if (heldID == 6 && inv.stone_pickaxe >= 1) {
			StonePickaxe.isHolding = true;
			stonePickaxe.SetActive(true);
		}
		else {
			StonePickaxe.isHolding = false;
			stonePickaxe.SetActive(false);
		}
		
		if (heldID == 7 && inv.gold_pickaxe >= 1) {
			GoldPickaxe.isHolding = true;
			goldPickaxe.SetActive(true);
		}
		else {
			GoldPickaxe.isHolding = false;
			goldPickaxe.SetActive(false);
		}
		if (heldID == 8 && inv.gold_axe >= 1) {
			GoldAxe.isHolding = true;
			goldAxe.SetActive(true);
		}
		else {
			GoldAxe.isHolding = false;
			goldAxe.SetActive(false);
		}
		if (heldID == 9 && inv.gold_sword >= 1) {
			GoldSword.isHolding = true;
			goldSword.SetActive(true);
		}
		else {
			GoldSword.isHolding = false;
			goldSword.SetActive(false);
		}
		
		if (heldID == 10 && inv.diamond_pickaxe >= 1) {
			DiamondPickaxe.isHolding = true;
			diamondPickaxe.SetActive(true);
		}
		else {
			DiamondPickaxe.isHolding = false;
			diamondPickaxe.SetActive(false);
		}
		if (heldID == 11 && inv.diamond_axe >= 1) {
			DiamondAxe.isHolding = true;
			diamondAxe.SetActive(true);
		}
		else {
			DiamondAxe.isHolding = false;
			diamondAxe.SetActive(false);
		}
		if (heldID == 12 && inv.diamond_sword >= 1) {
			DiamondSword.isHolding = true;
			diamondSword.SetActive(true);
		}
		else {
			DiamondSword.isHolding = false;
			diamondSword.SetActive(false);
		}
		if (inv.iron_sword >= 1) {
			IronSwordB.SetActive(true);
		}
		else {
			IronSwordB.SetActive(false);
		}	
		
		if (inv.iron_axe >= 1) {
			IronAxeB.SetActive(true);
		}
		else {
			IronAxeB.SetActive(false);
		}
		
		if (inv.iron_pickaxe >= 1) {
			IronPickaxeB.SetActive(true);
		}
		else {
			IronPickaxeB.SetActive(false);
		}
		if (inv.stone_sword >= 1) {
			StoneSwordB.SetActive(true);
		}
		else {
			StoneSwordB.SetActive(false);
		}	
		
		if (inv.stone_axe >= 1) {
			StoneAxeB.SetActive(true);
		}
		else {
			StoneAxeB.SetActive(false);
		}
		
		if (inv.stone_pickaxe >= 1) {
			StonePickaxeB.SetActive(true);
		}
		else {
			StonePickaxeB.SetActive(false);
		}
		if (inv.gold_sword >= 1) {
			GoldSwordB.SetActive(true);
		}
		else {
			GoldSwordB.SetActive(false);
		}	
		
		if (inv.gold_axe >= 1) {
			GoldAxeB.SetActive(true);
		}
		else {
			GoldAxeB.SetActive(false);
		}
		
		if (inv.gold_pickaxe >= 1) {
			GoldPickaxeB.SetActive(true);
		}
		else {
			GoldPickaxeB.SetActive(false);
		}
		if (inv.diamond_sword >= 1) {
			DiamondSwordB.SetActive(true);
		}
		else {
			DiamondSwordB.SetActive(false);
		}	
		
		if (inv.diamond_axe >= 1) {
			DiamondAxeB.SetActive(true);
		}
		else {
			DiamondAxeB.SetActive(false);
		}
		
		if (inv.diamond_pickaxe >= 1) {
			DiamondPickaxeB.SetActive(true);
		}
		else {
			DiamondPickaxeB.SetActive(false);
		}	
		if (inv.magic_staff	>= 1) {
			magicStaffB.SetActive(true);
		}
		else {
			magicStaffB.SetActive(false);
		}		
		
		if (inv.iron_helmet >= 1) {
			ironHelmetB.SetActive(true);
		}
		else {
			ironHelmetB.SetActive(false);
		}
		
		if (inv.iron_chestplate >= 1) {
			ironChestplateB.SetActive(true);
		}
		else {
			ironChestplateB.SetActive(false);
		}
		if (inv.iron_leggings >= 1) {
			ironLeggingsB.SetActive(true);
		}
		else {
			ironLeggingsB.SetActive(false);
		}
    }
	
	public void UnequipItem() {
		
			heldID = 10000;
			hasItemEquiped = false;
	}
	
	public void EquipIronSword() {
		
			if (inv.iron_sword >= 1) {
				heldID = 0;
				hasItemEquiped = true;
			}
	}

	public void EquipIronAxe() {
		
			if (inv.iron_axe >= 1) {
				heldID = 1;
				hasItemEquiped = true;
			}
	}
	
	public void EquipIronPickaxe() {
		
			if (inv.iron_pickaxe >= 1) {
				heldID = 2;
				hasItemEquiped = true;
			}
	}
		
	public void EquipMagicStaff() {
		
			if (inv.magic_staff >= 1) {
				heldID = 3;
				hasItemEquiped = true;
			}
	}
	
	public void EquipStoneSword() {
		
			if (inv.stone_sword >= 1) {
				heldID = 4;
				hasItemEquiped = true;
			}
	}
	
	public void EquipStoneAxe() {
		
			if (inv.stone_axe >= 1) {
				heldID = 5;
				hasItemEquiped = true;
			}
	}
	
	public void EquipStonePickaxe() {
		
			if (inv.stone_pickaxe >= 1) {
				heldID = 6;
				hasItemEquiped = true;
			}
	}
	
	public void EquipGoldPickaxe() {
		
			if (inv.gold_pickaxe >= 1) {
				heldID = 7;
				hasItemEquiped = true;
			}
	}
	
	public void EquipGoldAxe() {
		
			if (inv.gold_axe >= 1) {
				heldID = 8;
				hasItemEquiped = true;
			}
	}
	
	public void EquipGoldSword() {
		
			if (inv.gold_sword >= 1) {
				heldID = 9;
				hasItemEquiped = true;
			}
	}
	
	public void EquipDiamondPickaxe() {
		
			if (inv.diamond_pickaxe >= 1) {
				heldID = 10;
				hasItemEquiped = true;
			}
	}
	
	public void EquipDiamondAxe() {
		
			if (inv.diamond_axe >= 1) {
				heldID = 11;
				hasItemEquiped = true;
				
			}
	}
	
	public void EquipDiamondSword() {
		
			if (inv.diamond_sword >= 1) {
				heldID = 12;
				hasItemEquiped = true;
			}
	}
	
	public void EquipIronHelmet() {
		
		if (inv.iron_helmet >= 1) {
			
			PlayerDefence.defense += 7;
			inv.iron_helmet -= 1;
			IronHelmet.SetActive(true);
			PlayerMovement.runSpeed -= 2;
			
		}
		
	}
	
	public void EquipIronChestplate() {
		
		if (inv.iron_chestplate >= 1) {
			
			PlayerDefence.defense += 18;
			inv.iron_chestplate -= 1;
			IronChestplate.SetActive(true);
			PlayerMovement.runSpeed -= 10;
			
		}
		
	}
	
	public void EquipIronLeggings() {
		
		if (inv.iron_leggings >= 1) {
			
			PlayerDefence.defense += 12;
			inv.iron_leggings -= 1;
			IronLeggings.SetActive(true);
			PlayerMovement.runSpeed -= 8;
			
		}
		
	}
}