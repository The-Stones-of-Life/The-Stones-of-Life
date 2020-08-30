using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
	
	private Inventory2 inv;
	
	public bool isSMOpen = false;
	
	public GameObject testSpellEffect;
	public GameObject fireSpellEffect;
	
	public GameObject testSpellB;
	public GameObject fireSpellB;
	
	public GameObject SpellMenu;
	public GameObject magicStaff;
	
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && isSMOpen == false) {
			isSMOpen = true;
			SpellMenu.SetActive(true);
		}
		
		if (Input.GetKeyDown(KeyCode.Escape) && isSMOpen == true) {
			isSMOpen = false;
			SpellMenu.SetActive(false);
		}
		
		if (inv.test_spell_scroll >= 1) {
			testSpellB.SetActive(true);
		}
		else {
			testSpellB.SetActive(false);
		}
		
		if (inv.fire_spell_scroll >= 1) {
			fireSpellB.SetActive(true);
		}
		else {
			fireSpellB.SetActive(false);
		}
    }
	
	public void CastTestSpell() {
		
		if (Equipment.hasMagicStaffT1 == true && inv.magic_dust >= 1 && SpecialGear.hasSpellBook == true) {
			inv.test_spell_scroll -= 1;
			inv.magic_dust -= 1;
			Instantiate(testSpellEffect, new Vector2(magicStaff.transform.position.x, magicStaff.transform.position.y), Quaternion.identity);
		}
		StartCoroutine(TestSpell());
	}
	
	public void CastFireSpell() {
		
		if (Equipment.hasMagicStaffT1 == true && inv.magic_dust >= 5 && SpecialGear.hasSpellBook == true) {
			inv.fire_spell_scroll -= 1;
			inv.magic_dust -= 5;
			Instantiate(fireSpellEffect, new Vector2(magicStaff.transform.position.x, magicStaff.transform.position.y), Quaternion.identity);
		}
		StartCoroutine(FireSpell());
	}
	
	IEnumerator TestSpell() {
		
		yield return new WaitForSeconds(3.0f);
		Destroy(testSpellEffect);
		
	}
	
	IEnumerator FireSpell() {
		
		yield return new WaitForSeconds(20.0f);
		Destroy(fireSpellEffect);
		
	}
}
