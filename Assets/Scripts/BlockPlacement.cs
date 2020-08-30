using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacement : MonoBehaviour
{
	   
	private Inventory2 inv;
	
	public int slotId;
	
	public GameObject id0;
	public GameObject id1;
	public GameObject id2;
	public GameObject id3;
	public GameObject id4;
	public GameObject id5;
	public GameObject id6;
	public GameObject id7;
	public GameObject id8;
	public GameObject id9;
	public GameObject id10;
	public GameObject id11;
	public GameObject id12;
	public GameObject id13;
	public GameObject id14;
	public GameObject id15;
	public GameObject id16;
	public GameObject id17;
	public GameObject id18;
	public GameObject id19;
	public GameObject id20;
	public GameObject id21;
	public GameObject id22;
	public GameObject id23;
	public GameObject id24;
	public GameObject id25;
	public GameObject id26;

	void Start() {
		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		
		id10 = GameObject.Find("Workbench");
		id11 = GameObject.Find("Furnace");
		id12 = GameObject.Find("Anvil");
		id15 = GameObject.Find("Arcane_Workbench");
		id17 = GameObject.Find("MechanicalWorkbench");
		id22 = GameObject.Find("Campfire");
	}
	
    void Update()
    {
		if (Input.GetMouseButtonDown(1)) {
			
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			
			Vector3 placePos = new Vector3 (Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f);
			if (inv.selectedBlock == 0)
			{
				if (inv.grassBlocks >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {
						
						inv.grassBlocks -= 1;
						Instantiate(id0, placePos, Quaternion.identity);
						
					}
				}
			}	
			
			if (inv.selectedBlock == 1)
			{
				if (inv.dirtBlocks >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {
						
						inv.dirtBlocks -= 1;
						Instantiate(id1, placePos, Quaternion.identity);
						
					}
				}
			}	
			
			if (inv.selectedBlock == 2)
			{
				if (inv.stoneBlocks >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {
						
						inv.stoneBlocks -= 1;
						Instantiate(id2, placePos, Quaternion.identity);
						
					}
				}
			}	
			
			if (inv.selectedBlock == 3)
			{
				if (inv.leaves >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.leaves -= 1;
						Instantiate(id3, placePos, Quaternion.identity);
						
					}
				}
			}	
			
			if (inv.selectedBlock == 4)
			{
				if (inv.logs >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.logs -= 1;
						Instantiate(id4, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 5)
			{
				if (inv.planks >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.planks -= 1;
						Instantiate(id5, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 6)
			{
				if (inv.coal >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.coal -= 1;
						Instantiate(id6, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 7)
			{
				if (inv.iron >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.iron -= 1;
						Instantiate(id7, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 8)
			{
				if (inv.clay >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.clay -= 1;
						Instantiate(id8, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 9)
			{
				if (inv.mud >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.mud -= 1;
						Instantiate(id9, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 10)
			{
				if (inv.workbench >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.workbench -= 1;
						Instantiate(id10, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 11)
			{
				if (inv.furnace >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.furnace -= 1;
						Instantiate(id11, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 12)
			{
				if (inv.anvil >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.anvil -= 1;
						Instantiate(id12, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 13)
			{
				if (inv.chair >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.chair -= 1;
						Instantiate(id13, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 14)
			{
				if (inv.table >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.table -= 1;
						Instantiate(id14, placePos, Quaternion.identity);
						
					}
				}
			}
			
			if (inv.selectedBlock == 15)
			{
				if (inv.arcane_workbench >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.arcane_workbench -= 1;
						Instantiate(id15, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 16)
			{
				if (inv.crude_oil_ore >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.crude_oil_ore -= 1;
						Instantiate(id16, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 17)
			{
				if (inv.mechanical_workbench >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.mechanical_workbench -= 1;
						Instantiate(id17, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 18)
			{
				if (inv.moon_stone >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.moon_stone -= 1;
						Instantiate(id18, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 19)
			{
				if (inv.spaceCraft >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.spaceCraft -= 1;
						Instantiate(id19, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 20)
			{
				if (inv.crude_oil_liquidizer >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.crude_oil_liquidizer -= 1;
						Instantiate(id20, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 21)
			{
				if (inv.launchpad >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.launchpad -= 1;
						Instantiate(id21, placePos, Quaternion.identity);
						
					}
				}
			}

			if (inv.selectedBlock == 22)
			{
				if (inv.campfire >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.campfire -= 1;
						Instantiate(id22, placePos, Quaternion.identity);
						
					}
				}
			}
		
			if (inv.selectedBlock == 23)
			{
				if (inv.bricks >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.bricks -= 1;
						Instantiate(id23, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 24)
			{
				if (inv.stone_bricks >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.stone_bricks -= 1;
						Instantiate(id24, placePos, Quaternion.identity);
						
					}
				}
			}	
			if (inv.selectedBlock == 25)
			{
				if (inv.gold >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.gold -= 1;
						Instantiate(id25, placePos, Quaternion.identity);
						
					}
				}
			}
			if (inv.selectedBlock == 26)
			{
				if (inv.diamond_ore >= 1)
				{
					if (Physics2D.OverlapCircleAll (placePos, 0.25f).Length == 0) {

						inv.diamond_ore -= 1;
						Instantiate(id26, placePos, Quaternion.identity);
						
					}
				}
			}	
		}
    }
}
