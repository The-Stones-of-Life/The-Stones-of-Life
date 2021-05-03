using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
   
	public GameObject pettleDemon;
	public GameObject manEater;
   
    void Update()
    {
        if (Random.Range(1, 2000) == 1) {
			
			Instantiate(pettleDemon, new Vector2(Random.Range(1, 512), 118), Quaternion.identity);
			
		}
		
		if (Random.Range(1, 2000) == 1) {
			
			Instantiate(manEater, new Vector2(Random.Range(1, 512), 118), Quaternion.identity);
			
		}
    }
}
