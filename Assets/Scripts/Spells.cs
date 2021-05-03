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
        if (Input.GetKeyDown(KeyCode.N) && isSMOpen == false && Player.uiLock == false) {
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
		
		StartCoroutine(TestSpell());
	}
	
	public void CastFireSpell() {
		
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
