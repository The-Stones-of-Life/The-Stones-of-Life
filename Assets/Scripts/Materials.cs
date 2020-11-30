using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materials : MonoBehaviour
{

	public bool isFoodMOpen = false;
	
	public GameObject foodMenu;
	
	private Inventory2 inv;
	
	public GameObject MaterialsMenu;
	
	public GameObject MagicCrystalI;
	public GameObject MudBrickI;
	public GameObject WoodenRodI;
	public GameObject IronIngotI;
	public GameObject PaperI;
	public GameObject PaperScrollI;
	public GameObject MagicDustI;
	public GameObject SpacecraftNoseI;
	public GameObject SpacecraftBaseI;
	public GameObject SpacecraftFinI;
	public GameObject SpacecraftEngineI;	
	public GameObject RCI;
	public GameObject CCI;
	public GameObject DiamondI;
	public GameObject GoldIngotI;
	
	public GameObject MagicCrystalAO;
	public GameObject MudBrickAO;
	public GameObject WoodenRodAO;
	public GameObject IronIngotAO;
	public GameObject PaperAO;
	public GameObject PaperScrollAO;
	public GameObject MagicDustAO;
	public GameObject SpacecraftBaseAO;
	public GameObject SpacecraftEngineAO;
	public GameObject SpacecraftFinAO;
	public GameObject SpacecraftNoseAO;
	public GameObject RCAO;
	public GameObject CCAO;
	public GameObject DiamondAO;
	public GameObject GoldIngotAO;
	
	public Text PaperA;
	public Text MagicCrystalA;
	public Text MudBrickA;
	public Text WoodenRodA;
	public Text IronIngotA;
	public Text PaperScrollA;
	public Text MagicDustA;
	public Text SpacecraftBaseA;
	public Text SpacecraftEngineA;
	public Text SpacecraftFinA;
	public Text SpacecraftNoseA;
	public Text RCA;
	public Text CCA;
	public Text DiamondA;
	public Text GoldIngotA;
	
	public bool isMOpen = false;
    
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }

    
    void Update()
    {
		if (isFoodMOpen == true && Input.GetKeyDown(KeyCode.Escape)) {
			isFoodMOpen = false;
			foodMenu.SetActive(false);
		}
		
		if (Input.GetKeyDown(KeyCode.M) && isMOpen == false && Player.uiLock == false) {
			isMOpen = true;
			MaterialsMenu.SetActive(true);
		}
		else {
			if (Input.GetKeyDown(KeyCode.Escape) && isMOpen == true) {
				isMOpen = false;
				MaterialsMenu.SetActive(false);
			}
		}
		
		
        if (inv.iron_ingot >= 1) {
			
			IronIngotAO.SetActive(true);
			IronIngotI.SetActive(true);
			IronIngotA.text = inv.iron_ingot.ToString();
		}
		else {
			IronIngotAO.SetActive(false);
			IronIngotI.SetActive(false);
		}
		if (inv.mud_brick >= 1) {
			MudBrickAO.SetActive(true);
			MudBrickA.text = inv.mud_brick.ToString();
			MudBrickI.SetActive(true);
		}
		else {
			MudBrickAO.SetActive(false);
			MudBrickI.SetActive(false);
		}
		if (inv.magic_crystal >= 1) {
			MagicCrystalAO.SetActive(true);
			MagicCrystalA.text = inv.magic_crystal.ToString();
			MagicCrystalI.SetActive(true);
		}
		else {
			MagicCrystalAO.SetActive(false);
			MagicCrystalI.SetActive(false);
		}
		if (inv.wooden_rod >= 1) {
			WoodenRodAO.SetActive(true);
			WoodenRodA.text = inv.wooden_rod.ToString();
			WoodenRodI.SetActive(true);
		}
		else {
			WoodenRodAO.SetActive(false);
			WoodenRodI.SetActive(false);
		}
		if (inv.paper >= 1) {
			PaperAO.SetActive(true);
			PaperA.text = inv.paper.ToString();
			PaperI.SetActive(true);
		}
		else {
			PaperAO.SetActive(false);
			PaperI.SetActive(false);
		}
		if (inv.paper_scroll >= 1) {
			PaperScrollAO.SetActive(true);
			PaperScrollA.text = inv.paper_scroll.ToString();
			PaperScrollI.SetActive(true);
		}
		else {
			PaperScrollAO.SetActive(false);
			PaperScrollI.SetActive(false);
		}
		if (inv.magic_dust >= 1) {
			MagicDustAO.SetActive(true);
			MagicDustA.text = inv.magic_dust.ToString();
			MagicDustI.SetActive(true);
		}
		else {
			MagicDustAO.SetActive(false);
			MagicDustI.SetActive(false);
		}
		if (inv.spacecraft_nose >= 1) {
			SpacecraftNoseAO.SetActive(true);
			SpacecraftNoseA.text = inv.spacecraft_nose.ToString();
			SpacecraftNoseI.SetActive(true);
		}
		else {
			SpacecraftNoseAO.SetActive(false);
			SpacecraftNoseI.SetActive(false);
		}
		if (inv.spacecraft_base >= 1) {
			SpacecraftBaseAO.SetActive(true);
			SpacecraftBaseA.text = inv.spacecraft_base.ToString();
			SpacecraftBaseI.SetActive(true);
		}
		else {
			SpacecraftBaseAO.SetActive(false);
			SpacecraftBaseI.SetActive(false);
		}
		if (inv.spacecraft_engine >= 1) {
			SpacecraftEngineAO.SetActive(true);
			SpacecraftEngineA.text = inv.spacecraft_engine.ToString();
			SpacecraftEngineI.SetActive(true);
		}
		else {
			SpacecraftEngineAO.SetActive(false);
			SpacecraftEngineI.SetActive(false);
		}
		if (inv.spacecraft_fin >= 1) {
			SpacecraftFinAO.SetActive(true);
			SpacecraftFinA.text = inv.spacecraft_fin.ToString();
			SpacecraftFinI.SetActive(true);
		}
		else {
			SpacecraftFinAO.SetActive(false);
			SpacecraftFinI.SetActive(false);
		}

		if (inv.raw_chicken >= 1) {
			RCAO.SetActive(true);
			RCA.text = inv.raw_chicken.ToString();
			RCI.SetActive(true);
		}
		else {
			RCAO.SetActive(false);
			RCI.SetActive(false);
		}
		if (inv.cooked_chicken >= 1) {
			CCAO.SetActive(true);
			CCA.text = inv.cooked_chicken.ToString();
			CCI.SetActive(true);
		}
		else {
			CCAO.SetActive(false);
			CCI.SetActive(false);
		}
		if (inv.diamond >= 1) {
			DiamondAO.SetActive(true);
			DiamondA.text = inv.diamond.ToString();
			DiamondI.SetActive(true);
		}
		else {
			DiamondAO.SetActive(false);
			DiamondI.SetActive(false);
		}
		if (inv.gold_ingot >= 1) {
			GoldIngotAO.SetActive(true);
			GoldIngotA.text = inv.gold_ingot.ToString();
			GoldIngotI.SetActive(true);
		}
		else {
			GoldIngotAO.SetActive(false);
			GoldIngotI.SetActive(false);
		}
    }

    public void foodMenuOpen() {

	if (isFoodMOpen == false) {
		isFoodMOpen = true;
		foodMenu.SetActive(true);
	}
    }

    public void eatRawChicken() {
	if (inv.raw_chicken >= 1) {
		inv.raw_chicken -= 1;
		Hunger.hunger += 10;
	}
    }
    public void eatCookedChicken() {
	if (inv.cooked_chicken >= 1) {
		inv.cooked_chicken -= 1;
		Hunger.hunger += 25;
	}
    }
}
