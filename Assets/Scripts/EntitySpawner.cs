using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
   
   public GameObject sludge;
   public GameObject deathBat;
   public GameObject demonFlower;
   
   public GameObject chicken;
   
	public LightCycle time;
	
    void Update()
    {
        if (Random.Range(1, 12000) == 1) {
			
			Instantiate(sludge, new Vector2(Random.Range(1, 120), 118), Quaternion.identity);
			
		}
		
		if (time._time >= 430 && time._time <= 700) {
			
			if (Random.Range(1, 11000) == 1) {
				
				Instantiate(deathBat, new Vector2(Random.Range(1, 120), 70), Quaternion.identity);
				
			}
		}
			
		if (Random.Range(1, 9000) == 1) {
				
			Instantiate(demonFlower, new Vector2(Random.Range(1, 120), 118), Quaternion.identity);
				
		}
		
		if (Random.Range(1, 7500) == 1) {
				
			Instantiate(chicken, new Vector2(Random.Range(1, 120), 118), Quaternion.identity);
				
		}
    }
}
