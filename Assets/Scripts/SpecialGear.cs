using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGear : MonoBehaviour
{
 
	private Inventory2 inv;
	
	public GameObject spellBookIco;
	
	public static bool hasSpellBook = false;
 
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }
	
	void Update()
    {
        if (inv.spell_book >= 1) {
			hasSpellBook = true;
			spellBookIco.SetActive(true);
		}
		else {
			hasSpellBook = false;
			spellBookIco.SetActive(false);
		}
    }
}
