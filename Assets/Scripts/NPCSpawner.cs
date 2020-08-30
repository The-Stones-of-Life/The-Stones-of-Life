using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    public GameObject Ryan;
    public GameObject Leland;
    public GameObject TravelingMerchant;

    void Update()
    {
 	if (Random.Range(1, 100000) == 1) {
		
		Instantiate(Ryan, new Vector2(Random.Range(1, 120), 118), Quaternion.identity);

	}

	if (Random.Range(1, 75000) == 1) {
		
		Instantiate(Leland, new Vector2(Random.Range(1, 120), 118), Quaternion.identity);

	}

	if (Random.Range(1, 9500) == 1) {
		
		Instantiate(TravelingMerchant, new Vector2(Random.Range(1, 120), 118), Quaternion.identity);

	}         
    }
}
