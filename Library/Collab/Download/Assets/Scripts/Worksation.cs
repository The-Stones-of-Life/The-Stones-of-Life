using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worksation : MonoBehaviour
{
    private Inventory2 inv;
	
	public GameObject plankRecipe;
	public GameObject ironSwordRecipe;
	public GameObject ironPickaxeRecipe;
	public GameObject ironAxeRecipe;
	public GameObject anvilRecipe;
	public GameObject chairRecipe;
	public GameObject tableRecipe;
	public GameObject ironIngotRecipe;
	public GameObject mudBrickRecipe;
	public GameObject furnaceRecipe;
	public GameObject paperRecipe;
	public GameObject arcaneWorkbenchRecipe;
	public GameObject magicStaffRecipe;
	public GameObject spellBookRecipe;
	public GameObject paperScrollRecipe;
	public GameObject magicDustRecipe;
	public GameObject testSpellRecipe;
	public GameObject ironHelmetRecipe;
	public GameObject ironChestplateRecipe;
	public GameObject ironLeggingsRecipe;
	public GameObject fireSpellRecipe;
	public GameObject mechanicalWorkbenchRecipe;
	public GameObject spacecraftFinRecipe;
	public GameObject spacecraftBaseRecipe;
	public GameObject spacecraftEngineRecipe;
	public GameObject spacecraftNoseRecipe;
	public GameObject spacecraftRecipe;
	public GameObject campfireRecipe;
	public GameObject cookedChickenRecipe;
	public GameObject brickBlockRecipe;
	public GameObject stoneBrickRecipe;
	public GameObject stoneSwordRecipe;
	public GameObject stoneAxeRecipe;
	public GameObject stonePickaxeRecipe;	
	public GameObject goldSwordRecipe;
	public GameObject goldAxeRecipe;
	public GameObject goldPickaxeRecipe;	
	public GameObject diamondSwordRecipe;
	public GameObject diamondAxeRecipe;
	public GameObject diamondPickaxeRecipe;
	public GameObject goldIngotRecipe;
	public GameObject ironWireRecipe;
	public GameObject electronicCaseRecipe;
	public GameObject ironButtonRecipe;
	public GameObject basicScreenRecipe;
	public GameObject retroConsolRecipe;
	public GameObject stoneArrowRecipe;
	public GameObject woodenBowRecipe;
	public GameObject glassBottleRecipe;
	public GameObject healthPotionRecipe;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }

    void Update()
	{
		if (Inventory.stoneBlocks >= 10 && Inventory.planks >= 5 && Inventory.coal >= 2) {
			
			furnaceRecipe.SetActive(true);
			
		}
		else {
			furnaceRecipe.SetActive(false);
		}
		
		if (Inventory.ironOre >= 4) {
			
			ironIngotRecipe.SetActive(true);
			
		}
		else {
			ironIngotRecipe.SetActive(false);
		}
		
		if (Inventory.ironIngot >= 1) {
			
			ironWireRecipe.SetActive(true);
			
		}
		else {
			ironWireRecipe.SetActive(false);
		}
		
		if (Inventory.ironIngot >= 2) {
			
			ironButtonRecipe.SetActive(true);
			
		}
		else {
			ironButtonRecipe.SetActive(false);
		}
		
		if (Inventory.ironIngot >= 15) {
			
			electronicCaseRecipe.SetActive(true);
			
		}
		else {
			electronicCaseRecipe.SetActive(false);
		}
		
		if (Inventory.ironIngot >= 10) {
			
			basicScreenRecipe.SetActive(true);
			
		}
		else {
			basicScreenRecipe.SetActive(false);
		}
		
		if (Inventory.ironWire >= 10 && Inventory.ironButton >= 8 && Inventory.electronicCase >= 1 && Inventory.basicScreen >= 1) {
			retroConsolRecipe.SetActive(true);
		}
		else {
			retroConsolRecipe.SetActive(false);
		}
		
		if (Inventory.ironIngot >= 5) {
			
			anvilRecipe.SetActive(true);
			
		}
		else {
			anvilRecipe.SetActive(false);
		}
		
		if (Inventory.ironIngot >= 12 && Inventory.sticks >= 2) {
			
			ironSwordRecipe.SetActive(true);
			
		}
		else {
			ironSwordRecipe.SetActive(false);
		}
		
		if (Inventory.sticks >= 5) {
			
			woodenBowRecipe.SetActive(true);
			
		}
		else {
			woodenBowRecipe.SetActive(false);
		}
		
		if (Inventory.sticks >= 1 && Inventory.stoneBlocks >= 2) {
			
			stoneArrowRecipe.SetActive(true);
			
		}
		else {
			stoneArrowRecipe.SetActive(false);
		}

		if (Inventory.sand >= 2)
        {
			glassBottleRecipe.SetActive(true);
        }
		else
        {
			glassBottleRecipe.SetActive(false);
        }

		if (Inventory.glassBottles >= 4 && Inventory.lifeshroom >= 1)
		{
			healthPotionRecipe.SetActive(true);
		}
		else
		{
			healthPotionRecipe.SetActive(false);
		}
	}
	
	public void CraftPlanks() {
		
		inv.logs -= 1;
		inv.planks += 5;
		
	}
	public void CraftWoodenBow() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sticks, amount = 5 });
		Inventory.sticks -= 5;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.WoodenBow, amount = 1 });		
		Inventory.woodenBow += 1;
		
	}
	public void CraftStoneArrow() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sticks, amount = 1 });
		Inventory.ironIngot -= 1;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 2 });
		Inventory.stoneBlocks -= 2;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.StoneArrow, amount = 4 });		
		Inventory.stoneArrow += 4;
		
	}
	public void CraftIronSword() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 12 });
		Inventory.ironIngot -= 12;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sticks, amount = 2 });
		Inventory.sticks -= 2;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronSword, amount = 1 });		
		Inventory.ironSword += 1;
	}
	public void CraftIronAxe() {
		
		inv.iron_ingot -= 5;
		inv.wooden_rod -= 1;
		inv.iron_axe += 1;
		
	}
	public void CraftIronPickaxe() {
		
		inv.iron_ingot -= 7;
		inv.wooden_rod -= 1;
		inv.iron_pickaxe += 1;
		
	}
	public void CraftAnvil() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 5 });
		Inventory.ironIngot -= 5;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Anvil, amount = 1 });		
		Inventory.anvil += 1;
		
	}
	
	public void CraftChair() {
		
		inv.planks -= 5;
		inv.chair += 1;
		
	}
	public void CraftTable() {
		
		inv.planks -= 7;
		inv.table += 1;
		
	}
	
	public void CraftIronIngot() {

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronIngot, amount = 1 });
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronOre, amount = 4 });
		Inventory.ironOre -= 4;
		Inventory.ironIngot += 1;
		
	}
	public void CraftMudBrick() {
		
		inv.mud -= 3;
		inv.mud_brick += 1;
		
	}
	public void CraftFurnace() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 10 });
		Inventory.stoneBlocks -= 10;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Planks, amount = 5 });
		Inventory.planks -= 5;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Coal, amount = 2 });
		Inventory.coal -= 2;
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Furnace, amount = 1 });
		Inventory.furnace += 1;
		
	}
	public void CraftPaper() {
		
		inv.logs -= 2;
		inv.paper += 10 ;
		
	}
	public void CraftArcaneWorkbench() {
		
		inv.planks -= 5;
		inv.magic_crystal -= 2 ;
		inv.arcane_workbench += 1;
		
	}
	public void CraftMagicWand() {
		
		inv.wooden_rod -= 1;
		inv.magic_crystal -= 1 ;
		inv.magic_staff += 1;
		
	}
	public void CraftSpellBook() {
		
		inv.paper -= 10;
		inv.magic_crystal -= 1 ;
		inv.spell_book += 1;
		
	}
	public void CraftPaperScroll() {
		
		inv.paper -= 1;
		inv.paper_scroll += 1;
		
	}
	public void CraftMagicDust() {
		
		inv.magic_crystal -= 1;
		inv.magic_dust += 20;
		
	}
	public void CraftTestSpell() {
		
		inv.dirtBlocks -= 1;
		inv.test_spell_scroll += 1;
		
	}
	public void CraftIronHelmet() {
		
		inv.iron_ingot -= 12;
		inv.iron_helmet += 1;
		
	}
	public void CraftIronChestplate() {
		
		inv.iron_ingot -= 24;
		inv.iron_chestplate += 1;
		
	}
	public void CraftIronLeggings() {
		
		inv.iron_ingot -= 17;
		inv.iron_leggings += 1;
		
	}
	public void CraftFireSpell() {
		
		inv.paper_scroll -= 1;
		inv.magic_dust -= 15;
		inv.fire_spell_scroll += 1;
		
	}
	public void CraftMechanicalWorkbench() {
		
		inv.iron_ingot -= 5;
		inv.mechanical_workbench += 1;
		
	}
	
	public void CraftSpacecraftFin() {
		
		inv.iron_ingot -= 5;
		inv.spacecraft_fin += 1;
		
	}
	public void CraftSpacecraftBase() {
		
		inv.iron_ingot -= 35;
		inv.spacecraft_base += 1;
		
	}
	public void CraftSpacecraftEngine() {
		
		inv.iron_ingot -= 35;
		inv.spacecraft_engine += 1;
		
	}
	public void CraftSpacecraftNose() {
		
		inv.iron_ingot -= 10;
		inv.spacecraft_nose += 1;
		
	}
	public void CraftSpacecraft() {
		
		inv.spacecraft_fin -= 2;
		inv.spacecraft_base -= 1;
		inv.spacecraft_nose -= 1;
		inv.spacecraft_engine -= 1;
		inv.spaceCraft += 1;
		
	}
	public void CraftCampfire() {
		
		inv.planks -= 2;
		inv.coal -= 5;
		inv.campfire += 1;
		
	}
	public void CraftCookedChicken() {
		
		inv.raw_chicken -= 1;
		inv.cooked_chicken += 1;
		
	}
	public void CraftBrickBlock() {
		
		inv.mud_brick -= 10;
		inv.bricks += 2;
		
	}
	public void CraftStoneBricks() {
		
		inv.stone -= 10;
		inv.stone_bricks += 2;
		
	}
	
	public void CraftStoneSword() {
		
		inv.stone -= 10;
		inv.wooden_rod -= 1;
		inv.stone_sword += 1;
		
	}
	public void CraftStoneAxe() {
		
		inv.stoneBlocks -= 5;
		inv.wooden_rod -= 1;
		inv.stone_axe += 1;
		
	}
	public void CraftStonePickaxe() {
		
		inv.stoneBlocks -= 7;
		inv.wooden_rod -= 1;
		inv.stone_pickaxe += 1;
		
	}
	public void CraftGoldword() {
		
		inv.gold_ingot -= 10;
		inv.wooden_rod -= 1;
		inv.gold_sword += 1;
		
	}
	public void CraftGoldAxe() {
		
		inv.gold_ingot -= 5;
		inv.wooden_rod -= 1;
		inv.gold_axe += 1;
		
	}
	public void CraftGoldPickaxe() {
		
		inv.gold_ingot -= 7;
		inv.wooden_rod -= 1;
		inv.gold_pickaxe += 1;
		
	}
	public void CraftDiamondSword() {
		
		inv.diamond_ore -= 10;
		inv.wooden_rod -= 1;
		inv.diamond_sword += 1;
		
	}
	public void CraftDiamondAxe() {
		
		inv.diamond_ore -= 5;
		inv.wooden_rod -= 1;
		inv.diamond_axe += 1;
		
	}
	public void CraftDiamondPickaxe() {
		
		inv.diamond_ore -= 7;
		inv.wooden_rod -= 1;
		inv.diamond_pickaxe += 1;
		
	}
	public void CraftGoldIngot() {
		
		inv.gold -= 2;
		inv.gold_ingot += 1;
		
	}
	public void CraftIronWire() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 1 });		
		Inventory.ironIngot -= 1;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronWire, amount = 1 });
		Inventory.ironWire += 1;
		
	}
	public void CraftIronButton() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 2 });		
		Inventory.ironIngot -= 2;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronButton, amount = 1 });
		Inventory.ironButton += 1;
		
	}
	public void CraftElecttronicCase() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 15 });		
		Inventory.ironIngot -= 15;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.ElectronicCase, amount = 1 });
		Inventory.electronicCase += 1;
		
	}
	public void CraftBasicScreen() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 10 });		
		Inventory.ironIngot -= 10;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.BasicScreen, amount = 1 });
		Inventory.basicScreen += 1;
		
	}
	public void CraftRetroConsol() {
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronWire, amount = 10 });		
		Inventory.ironWire -= 10;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronButton, amount = 9 });		
		Inventory.ironButton -= 8;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.ElectronicCase, amount = 1 });		
		Inventory.electronicCase -= 1;
		
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.BasicScreen, amount = 1 });		
		Inventory.basicScreen -= 1;
		
		Player.inventory.AddItem(new Item { itemType = Item.ItemType.RetroConsol, amount = 1 });
		Inventory.retroConsol += 1;
		
	}
}
