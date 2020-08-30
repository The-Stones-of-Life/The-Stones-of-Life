using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffectDuration : MonoBehaviour
{
	
	public float duration;
	
    void Awake()
    {
       StartCoroutine(Spell()); 
    }
	
	IEnumerator Spell() {
		
		yield return new WaitForSeconds(duration);
		Destroy(this.gameObject);
		
	}
}
