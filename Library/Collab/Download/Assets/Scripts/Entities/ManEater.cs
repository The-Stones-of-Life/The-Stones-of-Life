using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManEater : AIBase
{

	public int maxHealth;
	public int currentHealth;

	void Start()
    {
		isAffectedByFire = true;
		maxOnFireTime = 120;
        maxHealth = 5;
		currentHealth = maxHealth;
		player = GameObject.Find("Player").GetComponent<Player>();
		pHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    private void Update()
    {
		if (this.currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Health.health -= 30;
		}

		if (coll.gameObject.tag == "IronArrow")
		{
			attack(12);
			Destroy(coll.gameObject);
		}

		if (coll.gameObject.tag == "Tool")
		{
			attack(Player.Instance.damage);
			Player.justAttackedEntity = true;
		}
	}

	public void attack(int damage)
	{
		currentHealth -= damage;
	}
}
