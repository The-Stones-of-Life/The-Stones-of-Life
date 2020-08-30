using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemObject", menuName = "Inventory/ItemObject")]
public class ItemObject : ScriptableObject
{
    public string name;
	public int id;
	public bool isPickaxe;
	public bool isAxe;
	public bool isSword;
	public bool isBow;
	public Sprite icon;
	public int stackSize;
	public int currentAmmount;
	
}
