using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordPyrmid : AIBase
{
	public Animation anim;
    public AnimationClip start;
    public AnimationClip changePhaseTwo;
	public int startFrames = 0;
	public bool fightStarted = false;

	public static int maxHealth;
	public int currentHealth;

	public int attackCooldown = 0;

	public GameObject lordPyrimites;

	public bool phaseTwoChange = false;

	public Rigidbody2D rb;

    void Start()
    {
		anim = this.GetComponent<Animation>();
		rb = this.GetComponent<Rigidbody2D>();
        maxHealth = 800;
        currentHealth = maxHealth;
		anim.clip = start;
		anim.Play();

    }

    void Update()
    {
        if (!fightStarted)
        {
			startFrames += 1;
        }

		if (startFrames >= 30)
        {
			startFrames = 0;
			fightStarted = true;
        }

		if (fightStarted)
        {

			if (Health.health <= 0)
			{
				Destroy(this.gameObject);
            }

			if (currentHealth <= 0)
			{
				Player.inventory.AddItem(new Item { itemType = Item.ItemType.ThePyrmidsSword, amount = 1 });
				Inventory.thePyrmidsSword += 1;
				Destroy(this.gameObject);
			}

			if (!phaseTwoChange)
			{
				if (getPosX() >= Player.Instance.getPosX())
				{
					rb.AddForce(new Vector2(-2, 0));
				}
				else if (getPosX() <= Player.Instance.getPosX())

				{
					rb.AddForce(new Vector2(2, 0));
				}

				if (getPosY() >= Player.Instance.getPosY())
				{
					rb.AddForce(new Vector2(0, -2));
				}
				else if (getPosY() <= Player.Instance.getPosY())

				{
					rb.AddForce(new Vector2(0, 2));
				}
			} else if (phaseTwoChange)
            {
				if (getPosX() >= Player.Instance.getPosX())
				{
					rb.AddForce(new Vector2(-12, 0));
				}
				else if (getPosX() <= Player.Instance.getPosX())

				{
					rb.AddForce(new Vector2(12, 0));
				}

				if (getPosY() >= Player.Instance.getPosY())
				{
					rb.AddForce(new Vector2(0, -12));
				}
				else if (getPosY() <= Player.Instance.getPosY())
				{
					rb.AddForce(new Vector2(0, 12));
				}
			}

			if (currentHealth > 400) {
				if (Random.Range(0, 30) == 0)
				{
					GameObject lp = Instantiate(lordPyrimites, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				}		
			} else if (currentHealth <= 400)
            {
				if (!phaseTwoChange)
                {
					anim.clip = changePhaseTwo;
					anim.Play();
					phaseTwoChange = true;
                }

				if (Random.Range(0, 60) == 0)
                {
					GameObject lp = Instantiate(lordPyrimites, new Vector2(getPosX(), getPosY()), Quaternion.identity);
				}
			}
		}
    }

	public void attack(int damage)
	{
		currentHealth -= damage;
	}


	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (fightStarted)
		{
			if (collision.gameObject.tag == "Player" && phaseTwoChange)
			{
				Health.health -= 60 - PlayerStatus.Instance.td;
			}

			if (collision.gameObject.tag == "FireArrow")
			{
				attack(6);
				Destroy(collision.gameObject);
			}

			if (collision.gameObject.tag == "IronArrow")
			{
				attack(12);
				Destroy(collision.gameObject);
			}

			if (collision.gameObject.tag == "Arrow")
			{
				attack(4);
				Destroy(collision.gameObject);
			}

			if (collision.gameObject.tag == "Tool")
            {
				attack(Player.Instance.damage);
				Player.justAttackedEntity = true;
            }
		}
	}
}
