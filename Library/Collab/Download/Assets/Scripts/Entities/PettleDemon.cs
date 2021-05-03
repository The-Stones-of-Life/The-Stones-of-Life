using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettleDemon : AIBase
{
	public int maxHealth;
	public int currentHealth;

	public Rigidbody2D rb;
	
    void Start()
    {
		isAffectedByFire = true;
		maxOnFireTime = 120;
		maxHealth = 100;
		player = GameObject.Find("Player").GetComponent<Player>();
		pHealth = GameObject.Find("Player").GetComponent<Health>();
		currentHealth = maxHealth;
    }

    void Update()
    {
		if (this.currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}

		if (player.getPosX() <= this.getPosX()) {
			rb.AddForce(new Vector2(-1, 0));
		}
		
		if (player.getPosY() <= this.getPosY()) {
			rb.AddForce(new Vector2(0, -1));
		}
		
		if (player.getPosX() <= this.getPosX() && player.getPosY() <= this.getPosY()) {
			rb.AddForce(new Vector2(-1, -1));
		}
		 if (player.getPosX() >= this.getPosX()) {
			rb.AddForce(new Vector2(1, 0));
		}
		
		if (player.getPosY() >= this.getPosY()) {
			rb.AddForce(new Vector2(0, 1));
		}
		
		if (player.getPosX() >= this.getPosX() && player.getPosY() >= this.getPosY()) {
			rb.AddForce(new Vector2(1, 1));
		}

		if (isOnFire)
		{
			if (!spawnedFireParticals)
			{
				GameObject fireObj = Instantiate(fireParticals, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				fireObj.transform.parent = this.transform;
				Debug.Log(this.transform.name);
				spawnedFireParticals = true;
			}
			fireDamageFrames += 1;
			onFireTime += 1;
			fireDamage();
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Health.health -= 10;
		}
	}

	public void attack(int damage)
	{
		currentHealth -= damage;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Coll");
		if (collision.gameObject.tag == "Fire" && isAffectedByFire)
		{
			isOnFire = true;
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "FireArrow" && isAffectedByFire)
		{
			attack(6);
			isOnFire = true;
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Arrow" && isAffectedByFire)
		{
			attack(4);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "IronArrow")
		{
			attack(12);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Tool")
		{
			attack(Player.Instance.damage);
			Player.justAttackedEntity = true;
		}
	}
}
