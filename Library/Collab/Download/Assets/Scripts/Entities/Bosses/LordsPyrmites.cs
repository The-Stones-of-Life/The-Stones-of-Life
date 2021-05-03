using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordsPyrmites : AIBase
{
	public Rigidbody2D rb;

	public int maxHealth;
	public int currentHealth;

	public int attackCooldown = 0;

	void Start()
    {
		maxHealth = 60;
		currentHealth = maxHealth;
		rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		if (this.currentHealth <= 0)
		{
			Destroy(this.gameObject);
		}

		if (getPosX() >= Player.Instance.getPosX())
		{
			rb.AddForce(new Vector2(-1, 0));
		}
		else if (getPosX() <= Player.Instance.getPosX())
		{
			rb.AddForce(new Vector2(1, 0));
		}

		if (getPosY() >= Player.Instance.getPosY())
		{
			rb.AddForce(new Vector2(0, -1));
		}
		else if (getPosY() <= Player.Instance.getPosY())
		{
			rb.AddForce(new Vector2(0, 1));
		}
	}
	public void attack(int damage)
	{
		currentHealth -= damage;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			attackCooldown += 1;
			if (attackCooldown >= 2000)
			{
				Health.health -= 24 - PlayerStatus.Instance.td;
				attackCooldown = 0;
			}
		}

		if (collision.gameObject.tag == "FireArrow")
		{
			attack(6);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Arrow")
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

    private void OnTriggerStay2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			attackCooldown += 1;
			if (attackCooldown >= 600)
			{
				Health.health -= 24 - PlayerStatus.Instance.td;
				attackCooldown = 0;
			}
		}
	}
}
