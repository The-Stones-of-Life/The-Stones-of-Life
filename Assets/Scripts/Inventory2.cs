using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory2 : MonoBehaviour
{

	public static int grassBlocks = 0;
	
	public static int selectedBlock = 0;
	public static int dirtBlocks = 0;
	public static int stone = 0;
	public static int leaves = 0;
	public static int logs = 0;
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
	public static int arcane_workbench = 0;
	public int crude_oil_ore = 0;
	public int mechanical_workbench = 0;
	public int moon_stone = 0;
	public int spaceCraft = 0;
	public int crude_oil_liquidizer = 0;
	public int launchpad = 0;
	public int campfire = 0;
	public int bricks = 0;
	public int stone_block = 0;
	public int stone_bricks = 0;
	public int gold = 0;
	public int diamond_ore = 0;
	
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
	
	public int modE = 0;

	public int mod1 = 0;
	public int mod2 = 0;
	public int mod3 = 0;
	public int mod4 = 0;
	public int mod5 = 0;
	
	public string mod1N;
	public string mod2N;
	public string mod3N;
	public string mod4N;
	public string mod5N;
	
	public Text selectedBlockAmmountText;
	public Text selectedBlockText;
	
	void Start()
    {	
		Debug.Log(mod1N);
		Debug.Log(mod2N);
    }
		
    void Update()
    {		
		
		
        if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedBlock <= 26 && selectedBlock > 0) {
			
			selectedBlock -= 1;
			
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow) && selectedBlock >= 0 && selectedBlock < 0) {
			
			selectedBlock += 1;
			
		}
    }
	
	public void SaveInv() {
		
		SaveALoad.SaveInventory(this);
		
	}
	
	public void SaveInvAndExit() {
		
		SaveALoad.SaveInventory(this);
		Application.Quit();
		
	}
	
	public void LoadInv() {
		
		Inventory2Data data = SaveALoad.LoadInventory();
		
		selectedBlock = data.selectedBlock;
		grassBlocks = data.grassBlocks;
		dirtBlocks = data.dirtBlocks;
		stone = data.stone;
		leaves = data.leaves;
		logs = data.logs;
		planks = data.planks;
		coal = data.coal;
		iron = data.iron;
		clay = data.clay;
		mud = data.mud;
		workbench = data.workbench;
		furnace = data.furnace;
		anvil = data.anvil;
		chair = data.chair;
		table = data.table;
		arcane_workbench = data.arcane_workbench;
		crude_oil_ore = data.crude_oil_ore;
		mechanical_workbench = data.mechanical_workbench;
		moon_stone = data.moon_stone;
		spaceCraft = data.spaceCraft;
		crude_oil_liquidizer = data.crude_oil_liquidizer;
		launchpad = data.launchpad;
		campfire = data.campfire;
		bricks = data.bricks;
		stone_bricks = data.stone_bricks;
		gold = data.gold;
		diamond_ore = data.diamond_ore;
		
		spell_book = data.spell_book;
	   
		test_spell_scroll = data.test_spell_scroll;
		fire_spell_scroll = data.fire_spell_scroll;
	   
		iron_ingot = data.iron_ingot;
		mud_brick = data.mud_brick;
		wooden_rod = data.wooden_rod;
		magic_crystal = data.magic_crystal;
		paper = data.paper;
		paper_scroll = data.paper_scroll;
		magic_dust = data.magic_dust;
		spacecraft_nose = data.spacecraft_nose;
		spacecraft_fin = data.spacecraft_fin;
		spacecraft_engine = data.spacecraft_engine;
		spacecraft_base = data.spacecraft_base;
		raw_chicken = data.raw_chicken;
		cooked_chicken = data.cooked_chicken;
		diamond = data.diamond;
		gold_ingot = data.gold_ingot;
	   
		iron_sword = data.iron_sword;
		iron_pickaxe = data.iron_pickaxe;
		iron_axe = data.iron_axe;
		magic_staff = data.magic_staff;
		stone_sword = data.stone_sword;
		stone_axe = data.stone_axe;
		stone_pickaxe = data.stone_pickaxe;
		gold_sword = data.gold_sword;
		gold_axe = data.gold_axe;
		gold_pickaxe = data.gold_pickaxe;
		diamond_sword = data.diamond_sword;
		diamond_axe = data.diamond_axe;
		diamond_pickaxe = data.diamond_pickaxe;		
	   
		iron_helmet = data.iron_helmet;
		iron_chestplate = data.iron_chestplate;
		iron_leggings = data.iron_leggings;
		
	}
}
