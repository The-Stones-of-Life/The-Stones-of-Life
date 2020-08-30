using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory2 : MonoBehaviour
{
	
	public static bool changeworld = false;
	public static bool changedworld = false;
	
	public int selectedBlock = 0;
	
	public int grassBlocks = 0;
	public int dirtBlocks = 0;
	public int stoneBlocks = 0;
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
	
	public List<ModComponent> modC = new List<ModComponent>();
	
	public Text selectedBlockAmmountText;
	public Text selectedBlockText;
	
	void Start()
    {
		modC.Add(new ModComponent());;
		
		selectedBlockAmmountText = GameObject.Find("Block2").GetComponent<Text>();
		selectedBlockText = GameObject.Find("Block").GetComponent<Text>();
		
		for (int i = 0; i < ModLoader.modFeatures.Count; i++) {
				
			modE += 1;
			
			if (modE == 1) {
				
				if (ModLoader.modFeatures[i].ID == 0) {
					
					mod1N = ModLoader.modFeatures[i].Name;
					
				}
				
			}
			
			if (modE == 2) {
				
				if (ModLoader.modFeatures[i].ID == 1) {
					
					mod2N = ModLoader.modFeatures[i].Name;
					
				}
				
			}
		}
		
		Debug.Log(mod1N);
		Debug.Log(mod2N);
    }
		
    void Update()
    {		
		if (changeworld == true) {
			
			SaveInv();
			
		}
		
		if (changedworld == true) {
			
			LoadInv();
			
		}
		
        if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedBlock <= 26 && selectedBlock > 0) {
			
			selectedBlock -= 1;
			
		}
		
		if (Input.GetKeyDown(KeyCode.RightArrow) && selectedBlock >= 0 && selectedBlock < 26) {
			
			selectedBlock += 1;
			
		}
		
		
		if (selectedBlock == 0) {
			
			selectedBlockAmmountText.text = grassBlocks.ToString();
			selectedBlockText.text = "Grass";
			
		}
		
		if (selectedBlock == 1) {
			
			selectedBlockAmmountText.text = dirtBlocks.ToString();
			selectedBlockText.text = "Dirt";
			
		}
		
		if (selectedBlock == 2) {
			
			selectedBlockAmmountText.text = stoneBlocks.ToString();
			selectedBlockText.text = "Stone";
			
		}
		
		if (selectedBlock == 3) {
			
			selectedBlockAmmountText.text = leaves.ToString();
			selectedBlockText.text = "Leaves";
			
		}
		
		if (selectedBlock == 4) {
			
			selectedBlockAmmountText.text = logs.ToString();
			selectedBlockText.text = "Log";
			
		}
		
		if (selectedBlock == 5) {
			
			selectedBlockAmmountText.text = planks.ToString();
			selectedBlockText.text = "Planks";
			
		}
		
		if (selectedBlock == 6) {
			
			selectedBlockAmmountText.text = coal.ToString();
			selectedBlockText.text = "Coal";
			
		}
		
		if (selectedBlock == 7) {
			
			selectedBlockAmmountText.text = iron.ToString();
			selectedBlockText.text = "Iron";
			
		}
		if (selectedBlock == 8) {
			
			selectedBlockAmmountText.text = clay.ToString();
			selectedBlockText.text = "Clay";
			
		}
		if (selectedBlock == 9) {
			
			selectedBlockAmmountText.text = mud.ToString();
			selectedBlockText.text = "Mud";
			
		}
		if (selectedBlock == 10) {
			
			selectedBlockAmmountText.text = workbench.ToString();
			selectedBlockText.text = "Workbench";
			
		}
		if (selectedBlock == 11) {
			
			selectedBlockAmmountText.text = furnace.ToString();
			selectedBlockText.text = "Furnace";
			
		}
		if (selectedBlock == 12) {
			
			selectedBlockAmmountText.text = anvil.ToString();
			selectedBlockText.text = "Anvil";
			
		}
		if (selectedBlock == 13) {
			
			selectedBlockAmmountText.text = chair.ToString();
			selectedBlockText.text = "Chair";
			
		}
		if (selectedBlock == 14) {
			
			selectedBlockAmmountText.text = table.ToString();
			selectedBlockText.text = "Table";
			
		}
		if (selectedBlock == 15) {
			
			selectedBlockAmmountText.text = arcane_workbench.ToString();
			selectedBlockText.text = "Arcane Workbench";
			
		}
		if (selectedBlock == 16) {
			
			selectedBlockAmmountText.text = crude_oil_ore.ToString();
			selectedBlockText.text = "Crude Oil Ore";
			
		}	
		if (selectedBlock == 17) {
			
			selectedBlockAmmountText.text = mechanical_workbench.ToString();
			selectedBlockText.text = "Mechanical Workbench";
			
		}
		if (selectedBlock == 18) {
			
			selectedBlockAmmountText.text = moon_stone.ToString();
			selectedBlockText.text = "Moon Stone";
			
		}
		if (selectedBlock == 19) {
			
			selectedBlockAmmountText.text = spaceCraft.ToString();
			selectedBlockText.text = "Space Craft";
			
		}
		
		if (selectedBlock == 20) {
			
			selectedBlockAmmountText.text = crude_oil_liquidizer.ToString();
			selectedBlockText.text = "Crude Oil Liquidizer";
			
		}
		
		if (selectedBlock == 21) {
			
			selectedBlockAmmountText.text = launchpad.ToString();
			selectedBlockText.text = "Launchpad";
			
		}

		if (selectedBlock == 22) {
			
			selectedBlockAmmountText.text = campfire.ToString();
			selectedBlockText.text = "Campfire";
			
		}
		if (selectedBlock == 23) {
			
			selectedBlockAmmountText.text = bricks.ToString();
			selectedBlockText.text = "Bricks";
			
		}	
		if (selectedBlock == 24) {
			
			selectedBlockAmmountText.text = stone_bricks.ToString();
			selectedBlockText.text = "Stone Bricks";
			
		}
		if (selectedBlock == 25) {
			
			selectedBlockAmmountText.text = gold.ToString();
			selectedBlockText.text = "Gold";
			
		}
		if (selectedBlock == 26) {
			
			selectedBlockAmmountText.text = diamond_ore.ToString();
			selectedBlockText.text = "Diamond Ore";
			
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
		stoneBlocks = data.stoneBlocks;
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
