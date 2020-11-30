using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
	
	public static int maxHealth;
	public static int currentHealth;
	
	public Player player;
	public Health pHealth;
	
	void Start() {
		currentHealth = maxHealth;
	}
	
	void Update() {
		if (currentHealth <= 0) {
			Destroy(this.gameObject);
		}
	}
	
    public static void attack(int damage)
    {
        currentHealth -= damage;
    }
	
	public float getPosX() {
		return transform.position.x;
	}
	
	public float getPosY() {
		return transform.position.y;
	}
}
