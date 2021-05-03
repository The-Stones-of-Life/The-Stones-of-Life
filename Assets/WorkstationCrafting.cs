using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationCrafting : MonoBehaviour
{
	public GameObject furnaceRecipe;
	public GameObject anvilRecipe;
	public GameObject ironSwordRecipe;
	public GameObject ironIngotRecipe;
	public GameObject ironTeirHelmet;
	public GameObject ironTeirChestplate;
	public GameObject ironTeirLeggings;
	public GameObject ironTeirBoots;
	public GameObject woodenBowRecipe;
	public GameObject woodenArrowRecipe;
	public GameObject glassBottleRecipe;
	public GameObject healthPotionRecipe;
	public GameObject copperIngotRecipe;


	void Start()
	{
	}

	void Update()
	{
		if (Inventory.stoneBlocks >= 20)
		{

			furnaceRecipe.SetActive(true);

		}
		else
		{
			furnaceRecipe.SetActive(false);
		}

		if (Inventory.ironIngot >= 5)
		{

			anvilRecipe.SetActive(true);

		}
		else
		{
			anvilRecipe.SetActive(false);
		}

		if (Inventory.ironIngot >= 15)
		{

			ironSwordRecipe.SetActive(true);

		}
		else
		{
			ironSwordRecipe.SetActive(false);
		}

		if (Inventory.ironOre >= 2)
		{

			ironIngotRecipe.SetActive(true);

		}
		else
		{
			ironIngotRecipe.SetActive(false);
		}

		if (Inventory.ironIngot >= 12)
		{

			ironTeirHelmet.SetActive(true);

		}
		else
		{
			ironTeirHelmet.SetActive(false);
		}

		if (Inventory.ironIngot >= 24)
		{

			ironTeirChestplate.SetActive(true);

		}
		else
		{
			ironTeirChestplate.SetActive(false);
		}

		if (Inventory.ironIngot >= 24)
		{

			ironTeirChestplate.SetActive(true);

		}
		else
		{
			ironTeirChestplate.SetActive(false);
		}

		if (Inventory.ironIngot >= 18)
		{

			ironTeirLeggings.SetActive(true);

		}
		else
		{
			ironTeirLeggings.SetActive(false);
		}

		if (Inventory.ironIngot >= 8)
		{

			ironTeirBoots.SetActive(true);

		}
		else
		{
			ironTeirBoots.SetActive(false);
		}

		if (Inventory.sticks >= 10)
		{

			woodenBowRecipe.SetActive(true);

		}
		else
		{
			woodenBowRecipe.SetActive(false);
		}

		if (Inventory.sticks >= 6 && Inventory.stoneBlocks >= 6)
		{

			woodenArrowRecipe.SetActive(true);

		}
		else
		{
			woodenArrowRecipe.SetActive(false);
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

		if (Inventory.copperOre >= 8)
		{
			copperIngotRecipe.SetActive(true);
		}
		else
		{
			copperIngotRecipe.SetActive(false);
		}
	}

	public void CraftFurnace()
	{

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 20 });
		Inventory.stoneBlocks -= 20;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Furnace, amount = 1 });
		Inventory.furnace += 1;

	}

	public void CrafAnvil()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 5 });
		Inventory.ironIngot -= 5;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.Anvil, amount = 1 });
		Inventory.anvil += 1;
	}

	public void CraftIronSword()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 15 });
		Inventory.ironIngot -= 15;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronSword, amount = 1 });
		Inventory.ironSword += 1;
	}

	public void CraftIronIngot()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronOre, amount = 2 });
		Inventory.ironOre -= 2;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.IronIngot, amount = 1 });
		Inventory.ironIngot += 1;
	}

	public void CraftIronTeirHelmet()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 12 });
		Inventory.ironIngot -= 12;

		if (PlayerStatus.Instance.ht <= 1)
		{
			PlayerStatus.Instance.ht += 1;
		}
	}

	public void CraftIronTeirChestplate()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 24 });
		Inventory.ironIngot -= 24;

		if (PlayerStatus.Instance.ct <= 1)
		{
			PlayerStatus.Instance.ct += 1;
		}
	}

	public void CraftIronTeirLeggings()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 18 });
		Inventory.ironIngot -= 18;

		if (PlayerStatus.Instance.lt <= 1)
		{
			PlayerStatus.Instance.lt += 1;
		}
	}

	public void CraftIronTeirBoots()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronIngot, amount = 8 });
		Inventory.ironIngot -= 8;

		if (PlayerStatus.Instance.bt <= 1)
		{
			PlayerStatus.Instance.bt += 1;
		}
	}

	public void CraftWoodenBow()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sticks, amount = 10 });
		Inventory.sticks -= 10;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.WoodenBow, amount = 1 });
		Inventory.woodenBow += 1;
	}

	public void CraftStoneArrow()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 6 });
		Inventory.stoneBlocks -= 6;

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sticks, amount = 6 });
		Inventory.sticks -= 6;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.StoneArrow, amount = 6 });
		Inventory.stoneArrow += 6;
	}

	public void CraftGlassBottles()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sand, amount = 2 });
		Inventory.sand -= 2;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.GlassBottle, amount = 6 });
		Inventory.glassBottles += 6;
	}

	public void CraftHealthPotion()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.GlassBottle, amount = 4 });
		Inventory.glassBottles -= 4;

		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Lifeshroom, amount = 1 });
		Inventory.lifeshroom -= 1;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 4 });
		Inventory.healthPotion += 4;
	}

	public void CraftCopperIngot()
	{
		Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.CopperOre, amount = 8 });
		Inventory.copperOre -= 8;

		Player.inventory.AddItem(new Item { itemType = Item.ItemType.CopperIngot, amount = 1 });
		Inventory.copperIngot += 1;
	}
}
