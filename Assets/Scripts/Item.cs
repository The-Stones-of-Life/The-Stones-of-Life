using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Sword,
        HealthPotion,
        ManaPotion,
        Coin,
        Medkit,
		Grass,
		Dirt,
		Stone,
		Log,
		Leaves,
		Planks,
		Sticks,
		Workbench,
		IronOre,
		Furnace,
		IronIngot,
		Coal,
		IronWire,
		ElectronicCase,
		IronButton,
		BasicScreen,
		RetroConsol,
		Anvil,
		IronSword,
		WoodenBow,
		StoneArrow,
		PlantFiberSack,
		BrownMushroom,
		Lifeshroom,
		Torch,
		FlamingArrows,
		MysertiousTabletShardOne,
		MysertiousTabletShardTwo,
		MysertiousTabletShardThree,
		MysertiousTablet,
		Sand,
		GlassBottle,
		ThePyrmidsSword,
		IronArrow,
		CopperOre,
		CopperIngot
	}

	public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
			case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
			case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
			case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
			case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
			case ItemType.Medkit:       return ItemAssets.Instance.medkitSprite;
			case ItemType.Grass:       return ItemAssets.Instance.grassSprite;
			case ItemType.Dirt:       return ItemAssets.Instance.dirtSprite;
			case ItemType.Stone:       return ItemAssets.Instance.stoneSprite;
			case ItemType.Log:       return ItemAssets.Instance.logSprite;
			case ItemType.Leaves:       return ItemAssets.Instance.leavesSprite;
			case ItemType.Planks:       return ItemAssets.Instance.planksSprite;
			case ItemType.Sticks:       return ItemAssets.Instance.sticksSprite;
			case ItemType.Workbench:       return ItemAssets.Instance.workbenchSprite;
			case ItemType.IronOre:       return ItemAssets.Instance.ironOreSprite;
			case ItemType.Furnace:       return ItemAssets.Instance.furnaceSprite;
			case ItemType.IronIngot:       return ItemAssets.Instance.ironIngotSprite;
			case ItemType.Coal:       return ItemAssets.Instance.coalSprite;
			case ItemType.IronWire:       return ItemAssets.Instance.ironWireSprite;
			case ItemType.ElectronicCase:       return ItemAssets.Instance.electronicCaseSprite;
			case ItemType.IronButton:       return ItemAssets.Instance.ironButtonSprite;
			case ItemType.BasicScreen:       return ItemAssets.Instance.basicScreenSprite;
			case ItemType.RetroConsol:       return ItemAssets.Instance.retroConsolSprite;
			case ItemType.Anvil:       return ItemAssets.Instance.anvilSprite;
			case ItemType.IronSword:       return ItemAssets.Instance.ironSwordSprite;
			case ItemType.WoodenBow:       return ItemAssets.Instance.woodenBowSprite;
			case ItemType.StoneArrow:       return ItemAssets.Instance.stoneArrowSprite;
			case ItemType.PlantFiberSack:       return ItemAssets.Instance.plantFiberSackSprite;
			case ItemType.BrownMushroom:       return ItemAssets.Instance.brownMushroomSprite;
			case ItemType.Lifeshroom:       return ItemAssets.Instance.lifeshroomSprite;
			case ItemType.Torch:	return ItemAssets.Instance.torchSprite;
			case ItemType.FlamingArrows:		return ItemAssets.Instance.flamingArrowSprite;
			case ItemType.MysertiousTabletShardOne:		return ItemAssets.Instance.myseriousTabletShardOne;
			case ItemType.MysertiousTabletShardTwo:		return ItemAssets.Instance.myseriousTabletShardTwo;
			case ItemType.MysertiousTabletShardThree:	return ItemAssets.Instance.myseriousTabletShardThree;
			case ItemType.MysertiousTablet:		return	ItemAssets.Instance.myseriousTablet;
			case ItemType.Sand:		return ItemAssets.Instance.sandSprite;
			case ItemType.GlassBottle:	return ItemAssets.Instance.glassBottleSprite;
			case ItemType.ThePyrmidsSword:	return ItemAssets.Instance.thePyrmidsSwordSprite;
			case ItemType.IronArrow:	return ItemAssets.Instance.ironArrowSprite;
			case ItemType.CopperOre:	return ItemAssets.Instance.copperOreSprite;
			case ItemType.CopperIngot:	return ItemAssets.Instance.copperIngotSprite;
		

		}
	}

    public Color GetColor() {
        switch (itemType) {
        default:
			case ItemType.Sword:        return new Color(1, 1, 1);
			case ItemType.HealthPotion: return new Color(1, 0, 0);
			case ItemType.ManaPotion:   return new Color(0, 0, 1);
			case ItemType.Coin:         return new Color(1, 1, 0);
			case ItemType.Medkit:       return new Color(1, 0, 1);
        }
    }

    public bool IsStackable() {
        switch (itemType) {
        default:
			case ItemType.Coin:
			case ItemType.HealthPotion:
			case ItemType.ManaPotion:
			case ItemType.Grass:
			case ItemType.Dirt:		
			case ItemType.Stone:
			case ItemType.Log:
			case ItemType.Leaves:
			case ItemType.Planks:
			case ItemType.Sticks:
			case ItemType.Workbench:
			case ItemType.IronOre:
			case ItemType.Furnace:
			case ItemType.IronIngot:
			case ItemType.Coal:
			case ItemType.IronWire:
			case ItemType.ElectronicCase:
			case ItemType.IronButton:
			case ItemType.BasicScreen:
			case ItemType.Anvil:
			case ItemType.StoneArrow:
			case ItemType.BrownMushroom:
			case ItemType.Lifeshroom:
			case ItemType.Torch:
			case ItemType.FlamingArrows:
			case ItemType.MysertiousTabletShardOne:
			case ItemType.MysertiousTabletShardTwo:
			case ItemType.MysertiousTabletShardThree:
			case ItemType.Sand:
			case ItemType.GlassBottle:
			case ItemType.IronArrow:
			case ItemType.CopperOre:
			case ItemType.CopperIngot:
				return true;
			case ItemType.Sword:
			case ItemType.Medkit:
			case ItemType.RetroConsol:
			case ItemType.IronSword:
			case ItemType.WoodenBow:
			case ItemType.PlantFiberSack:
			case ItemType.MysertiousTablet:
			case ItemType.ThePyrmidsSword:
				return false;
        }
    }

}
