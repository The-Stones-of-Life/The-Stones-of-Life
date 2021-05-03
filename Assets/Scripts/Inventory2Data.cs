using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory2Data
{
	
	public int selectedBlock = 0;
	
	public int grassBlocks = 0;
	public int dirtBlocks = 0;
	public int stone = 0;
	public int leaves = 0;
	public int logs = 0;
	public int planks = 0;
	public int coal = 0;
	public int iron = 0;
	public int clay = 0;
	public int mud = 0;
	public int workbench = 0;
	public int furnace = 0;
	public int anvil = 0;
	public int chair = 0;
	public int table = 0;
	public int arcane_workbench = 0;
	public int crude_oil_ore = 0;
	public int mechanical_workbench = 0;
	public int moon_stone = 0;
	public int spaceCraft = 0;	
	public int crude_oil_liquidizer = 0;
	public int launchpad = 0;
	public int campfire = 0;
	public int bricks = 0;
	public int stone_bricks = 0;
	public int gold = 0;
	public int diamond_ore;

	public int spell_book = 0;
	
	public int test_spell_scroll = 0;
	public int fire_spell_scroll = 0;
	
	public int iron_ingot = 0;
	public int mud_brick = 0;
	public int wooden_rod = 0;
	public int magic_crystal = 0;
	public int paper = 0;
	public int paper_scroll = 0;
	public int magic_dust = 0;
	public int spacecraft_fin = 0;
	public int spacecraft_engine = 0;
	public int spacecraft_base = 0;
	public int spacecraft_nose = 0;
	public int raw_chicken = 0;
	public int cooked_chicken = 0;
	public int diamond = 0;
	public int gold_ingot = 0;
	
	public int iron_sword = 0;
	public int iron_pickaxe = 0;
	public int iron_axe = 0;
	public int magic_staff = 0;
	public int stone_sword = 0;
	public int stone_axe = 0;
	public int stone_pickaxe = 0;
	public int gold_sword = 0;
	public int gold_axe = 0;
	public int gold_pickaxe = 0;
	public int diamond_sword = 0;
	public int diamond_axe = 0;
	public int diamond_pickaxe = 0;
	
	public int iron_helmet = 0;
	public int iron_chestplate = 0;
	public int iron_leggings = 0;
	
	
    public Inventory2Data(Inventory2 inv2)
    {
       selectedBlock = Inventory2.selectedBlock;
	   grassBlocks = Inventory2.grassBlocks;
	   dirtBlocks = Inventory2.dirtBlocks;
		stone = Inventory2.stone;
	   leaves = Inventory2.leaves;
	   logs = Inventory2.logs;
	   planks = inv2.planks;
	   coal = inv2.coal;
	   iron = inv2.iron;
	   clay = inv2.clay;
	   mud = inv2.mud;
	   workbench = inv2.workbench;
	   furnace = inv2.furnace;
	   anvil = inv2.anvil;
	   chair = inv2.chair;
	   table = inv2.table;
	   arcane_workbench = Inventory2.arcane_workbench;
	   crude_oil_ore = inv2.crude_oil_ore;
	   mechanical_workbench = inv2.mechanical_workbench;
	   moon_stone = inv2.moon_stone;
	   spaceCraft = inv2.spaceCraft;
	   crude_oil_liquidizer = inv2.crude_oil_liquidizer;
	   launchpad = inv2.launchpad;
	   campfire = inv2.campfire;
	   bricks = inv2.bricks;
	   stone_bricks = inv2.stone_bricks;
	   gold = inv2.gold;
	   diamond_ore = inv2.diamond_ore;
	   gold_ingot = inv2.gold_ingot;
	   
	   spell_book = inv2.spell_book;
	   
	   test_spell_scroll = inv2.test_spell_scroll;
	   fire_spell_scroll = inv2.fire_spell_scroll;
	   
	   iron_ingot = inv2.iron_ingot;
	   mud_brick = inv2.mud_brick;
	   wooden_rod = inv2.wooden_rod;
	   magic_crystal = inv2.magic_crystal;
	   paper = inv2.paper;
	   paper_scroll = inv2.paper_scroll;
	   magic_dust = inv2.magic_dust;
	   spacecraft_base = inv2.spacecraft_base;
	   spacecraft_fin = inv2.spacecraft_fin;
	   spacecraft_nose = inv2.spacecraft_nose;
	   spacecraft_engine = inv2.spacecraft_engine;
	   raw_chicken = inv2.raw_chicken;
	   cooked_chicken = inv2.cooked_chicken;
	   diamond = inv2.diamond;
	   
	   iron_sword = inv2.iron_sword;
	   iron_pickaxe = inv2.iron_pickaxe;
	   iron_axe = inv2.iron_axe;
	   magic_staff = inv2.magic_staff;
	   stone_sword = inv2.stone_sword;
		stone_axe = inv2.stone_axe;
		stone_pickaxe = inv2.stone_pickaxe;
		gold_sword = inv2.gold_sword;
		gold_axe = inv2.gold_axe;
		gold_pickaxe = inv2.gold_pickaxe;
		diamond_sword = inv2.diamond_sword;
		diamond_axe = inv2.diamond_axe;
		diamond_pickaxe = inv2.diamond_pickaxe;
	   
	   iron_helmet = inv2.iron_helmet;
	   iron_chestplate = inv2.iron_chestplate;
	   iron_leggings = inv2.iron_leggings;
    }
}
