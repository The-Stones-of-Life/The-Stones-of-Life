using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }


    public Transform pfItemWorld;

    public Sprite swordSprite;
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
    public Sprite medkitSprite;
	public Sprite grassSprite;
	public Sprite dirtSprite;
	public Sprite stoneSprite;
	public Sprite logSprite;
	public Sprite leavesSprite;
	public Sprite planksSprite;
	public Sprite sticksSprite;
	public Sprite workbenchSprite;
	public Sprite ironOreSprite;
	public Sprite furnaceSprite;
	public Sprite ironIngotSprite;
	public Sprite coalSprite;
	public Sprite ironWireSprite;
	public Sprite electronicCaseSprite;
	public Sprite ironButtonSprite;
	public Sprite basicScreenSprite;
	public Sprite retroConsolSprite;
	public Sprite anvilSprite;
	public Sprite ironSwordSprite;
	public Sprite woodenBowSprite;
	public Sprite stoneArrowSprite;
	public Sprite plantFiberSackSprite;
	public Sprite brownMushroomSprite;
	public Sprite lifeshroomSprite;
	public Sprite torchSprite;
	public Sprite flamingArrowSprite;
	public Sprite myseriousTabletShardOne;
	public Sprite myseriousTabletShardTwo;
	public Sprite myseriousTabletShardThree;
	public Sprite myseriousTablet;
	public Sprite sandSprite;
	public Sprite glassBottleSprite;
	public Sprite thePyrmidsSwordSprite;
	public Sprite ironArrowSprite;
	public Sprite copperOreSprite;
	public Sprite copperIngotSprite;

}
