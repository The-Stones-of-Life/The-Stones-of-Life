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

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }

    void Update()
    {
        if (inv.logs >= 1) {
			
			plankRecipe.SetActive(true);
			
		}
		else {
			plankRecipe.SetActive(false);
		}
		
		if (inv.iron_ingot >= 10 && inv.wooden_rod >= 1) {
			
			ironSwordRecipe.SetActive(true);
			
		}
		else {
			ironSwordRecipe.SetActive(false);
		}
		
		if (inv.iron_ingot >= 7 && inv.wooden_rod >= 1) {
			
			ironPickaxeRecipe.SetActive(true);
			
		}
		else {
			ironPickaxeRecipe.SetActive(false);
		}
		
		if (inv.iron_ingot >= 5 && inv.wooden_rod >= 1) {
			
			ironAxeRecipe.SetActive(true);
			
		}
		else {
			ironAxeRecipe.SetActive(false);
		}
		
		if (inv.iron_ingot >= 5) {
			
			anvilRecipe.SetActive(true);
			
		}
		else {
			anvilRecipe.SetActive(false);
		}
		
		if (inv.planks >= 5) {
			
			chairRecipe.SetActive(true);
			
		}
		else {
			chairRecipe.SetActive(false);
		}
		
		if (inv.planks >= 7) {
			
			tableRecipe.SetActive(true);
			
		}
		else {
			tableRecipe.SetActive(false);
		}
		if (inv.iron >= 2) {
			
			ironIngotRecipe.SetActive(true);
			
		}
		else {
			ironIngotRecipe.SetActive(false);
		}
		
		if (inv.mud >= 3) {
			
			mudBrickRecipe.SetActive(true);
			
		}
		else {
			mudBrickRecipe.SetActive(false);
		}
		if (inv.stoneBlocks >= 20 && inv.coal >= 3) {
			
			furnaceRecipe.SetActive(true);
			
		}
		else {
			furnaceRecipe.SetActive(false);
		}
		if (inv.logs >= 2) {
			
			paperRecipe.SetActive(true);
			
		}
		else {
			paperRecipe.SetActive(false);
		}
		if (inv.planks >= 5 && inv.magic_crystal >= 2) {
			
			arcaneWorkbenchRecipe.SetActive(true);
			
		}
		else {
			arcaneWorkbenchRecipe.SetActive(false);
		}
		if (inv.magic_crystal >= 1 && inv.wooden_rod >= 1) {
			
			magicStaffRecipe.SetActive(true);
			
		}
		else {
			magicStaffRecipe.SetActive(false);
		}
		if (inv.magic_crystal >= 1 && inv.paper >= 10) {
			
			spellBookRecipe.SetActive(true);
			
		}
		else {
			spellBookRecipe.SetActive(false);
		}
		if (inv.paper >= 1) {
			
			paperScrollRecipe.SetActive(true);
			
		}
		else {
			paperScrollRecipe.SetActive(false);
		}
		if (inv.magic_crystal >= 1) {
			
			magicDustRecipe.SetActive(true);
			
		}
		else {
			magicDustRecipe.SetActive(false);
		}
		if (inv.dirtBlocks >= 1) {
			
			testSpellRecipe.SetActive(true);
			
		}
		else {
			testSpellRecipe.SetActive(false);
		}
		
		if (inv.iron_ingot >= 12) {
			
			ironHelmetRecipe.SetActive(true);
			
		}
		else {
			ironHelmetRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 24) {
			
			ironChestplateRecipe.SetActive(true);
			
		}
		else {
			ironChestplateRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 17) {
			
			ironLeggingsRecipe.SetActive(true);
			
		}
		else {
			ironLeggingsRecipe.SetActive(false);
		}
		if (inv.paper_scroll >= 1 && inv.magic_dust >= 15) {
			
			fireSpellRecipe.SetActive(true);
			
		}
		else {
			fireSpellRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 5) {
			
			mechanicalWorkbenchRecipe.SetActive(true);
			
		}
		else {
			mechanicalWorkbenchRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 35) {
			
			spacecraftBaseRecipe.SetActive(true);
			
		}
		else {
			spacecraftBaseRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 35) {
			
			spacecraftEngineRecipe.SetActive(true);
			
		}
		else {
			spacecraftEngineRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 5) {
			
			spacecraftFinRecipe.SetActive(true);
			
		}
		else {
			spacecraftFinRecipe.SetActive(false);
		}
		if (inv.iron_ingot >= 10) {
			
			spacecraftNoseRecipe.SetActive(true);
			
		}
		else {
			spacecraftNoseRecipe.SetActive(false);
		}
		if (inv.spacecraft_fin >= 2 && inv.spacecraft_base >= 1 && inv.spacecraft_engine >= 1 && inv.spacecraft_nose >= 1) {
			
			spacecraftRecipe.SetActive(true);
			
		}
		else {
			spacecraftRecipe.SetActive(false);
		}
		if (inv.planks >= 2 && inv.coal >= 5) {
			
			campfireRecipe.SetActive(true);
			
		}
		else {
			campfireRecipe.SetActive(false);
		}
		if (inv.raw_chicken >= 1) {
			
			cookedChickenRecipe.SetActive(true);
			
		}
		else {
			cookedChickenRecipe.SetActive(false);
		}
		if (inv.mud_brick >= 10) {
			
			brickBlockRecipe.SetActive(true);
			
		}
		else {
			brickBlockRecipe.SetActive(false);
		}
		if (inv.stoneBlocks >= 10 && inv.wooden_rod >= 1) {
			
			stoneBrickRecipe.SetActive(true);
			
		}
		else {
			stoneBrickRecipe.SetActive(false);
		}
		
		if (inv.stoneBlocks >= 10 && inv.wooden_rod >= 1) {
			
			stoneSwordRecipe.SetActive(true);
			
		}
		else {
			stoneSwordRecipe.SetActive(false);
		}
		if (inv.stoneBlocks >= 7 && inv.wooden_rod >= 1) {
			
			stonePickaxeRecipe.SetActive(true);
			
		}
		else {
			stonePickaxeRecipe.SetActive(false);
		}
		if (inv.stoneBlocks >= 5 && inv.wooden_rod >= 1) {
			
			stoneAxeRecipe.SetActive(true);
			
		}
		else {
			stoneAxeRecipe.SetActive(false);
		}
		
		if (inv.gold_ingot >= 10 && inv.wooden_rod >= 1) {
			
			goldSwordRecipe.SetActive(true);
			
		}
		else {
			goldSwordRecipe.SetActive(false);
		}
		if (inv.gold_ingot >= 7 && inv.wooden_rod >= 1) {
			
			goldSwordRecipe.SetActive(true);
			
		}
		else {
			goldSwordRecipe.SetActive(false);
		}
		if (inv.gold_ingot >= 5 && inv.wooden_rod >= 1) {
			
			goldAxeRecipe.SetActive(true);
			
		}
		else {
			goldAxeRecipe.SetActive(false);
		}
		
		if (inv.diamond_ore >= 10 && inv.wooden_rod >= 1) {
			
			diamondSwordRecipe.SetActive(true);
			
		}
		else {
			diamondSwordRecipe.SetActive(false);
		}
		if (inv.diamond_ore >= 7 && inv.wooden_rod >= 1) {
			
			diamondPickaxeRecipe.SetActive(true);
			
		}
		else {
			diamondPickaxeRecipe.SetActive(false);
		}
		if (inv.diamond_ore >= 5 && inv.wooden_rod >= 1) {
			
			diamondAxeRecipe.SetActive(true);
			
		}
		else {
			diamondAxeRecipe.SetActive(false);
		}
		
		if (inv.gold >= 2) {
			
			goldIngotRecipe.SetActive(true);
			
		}
		else {
			goldIngotRecipe.SetActive(false);
		}
    }
	
	public void CraftPlanks() {
		
		inv.logs -= 1;
		inv.planks += 5;
		
	}
	public void CraftIronSword() {
		
		inv.iron_ingot -= 10;
		inv.wooden_rod -= 1;
		inv.iron_sword += 1;
		
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
		
		inv.iron_ingot -= 5;
		inv.anvil += 1;
		
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
		
		inv.iron -= 2;
		inv.iron_ingot += 1;
		
	}
	public void CraftMudBrick() {
		
		inv.mud -= 3;
		inv.mud_brick += 1;
		
	}
	public void CraftFurnace() {
		
		inv.stoneBlocks -= 20;
		inv.coal -= 3;
		inv.furnace += 1;
		
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
		
		inv.stoneBlocks -= 10;
		inv.stone_bricks += 2;
		
	}
	
	public void CraftStoneSword() {
		
		inv.stoneBlocks -= 10;
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
}
