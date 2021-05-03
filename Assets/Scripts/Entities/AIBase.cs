using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AIBase : NetworkBehaviour
{
	public static bool isOnFire = false;
	public bool isAffectedByFire;
	
	public Player player;
	public Health pHealth;

	public static bool spawnedFireParticals = false;
	
	public static int maxOnFireTime;
	public static int onFireTime = 0;

	public static int fireDamageFrames = 0;

	public GameObject fireParticals;
	
	void Start() {
	}
	
	void Update() {

		if (!isOnFire && this.transform.childCount >= 1)
        {
			Destroy(this.transform.GetChild(0).gameObject);
        }
	}
	
	public static void fireDamage()
    {
		if (onFireTime >= maxOnFireTime)
        {
			onFireTime = 0;
			fireDamageFrames = 0;
			isOnFire = false;
			spawnedFireParticals = false;
        }

		if (fireDamageFrames >= 50)
        {
			fireDamageFrames = 0;
        }
    }
	
	public float getPosX() {
		return transform.position.x;
	}

	public float getPosY()
	{
		return transform.position.y;
	}
}
