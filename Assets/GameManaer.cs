using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaer : MonoBehaviour
{
	
	private Hotbar hb;
	
	[SerializeField] private InventoryUI invUI;
	
	private void Awake() {
		
		hb = new Hotbar();
		
	}
	
    void Start()
    {
        invUI.SetInventory(hb);
    }

    void Update()
    {
    }
}
