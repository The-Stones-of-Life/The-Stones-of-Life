using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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

	public bool dashing = false;

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

		if (GameObject.Find("NetworkManager") != null)
		{
			if (fightStarted)
			{

				if (Health.health <= 0)
				{
					Destroy(this.gameObject);
				}

				if (currentHealth <= 0)
				{
					PlayerMultiplayer.inventory.AddItem(new Item { itemType = Item.ItemType.ThePyrmidsSword, amount = 1 });
					Inventory.thePyrmidsSword += 1;
					Destroy(this.gameObject);
				}

				if (!dashing)
				{
					if (!phaseTwoChange)
					{
						if (getPosX() >= PlayerMultiplayer.Instance.getPosX() - 5)
						{
							rb.AddForce(new Vector2(-2, 0));
						}
						else if (getPosX() <= PlayerMultiplayer.Instance.getPosX() - 5)

						{
							rb.AddForce(new Vector2(2, 0));
						}

						if (getPosY() >= PlayerMultiplayer.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, -2));
						}
						else if (getPosY() <= PlayerMultiplayer.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, 2));
						}

						if (Random.Range(0, 30) == 0)
						{
							//Dash();
						}

					}
					else if (phaseTwoChange)
					{
						if (getPosX() >= PlayerMultiplayer.Instance.getPosX() - 5)
						{
							rb.AddForce(new Vector2(-5, 0));
						}
						else if (getPosX() <= PlayerMultiplayer.Instance.getPosX() - 5)

						{
							rb.AddForce(new Vector2(5, 0));
						}

						if (getPosY() >= PlayerMultiplayer.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, -5));
						}
						else if (getPosY() <= PlayerMultiplayer.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, 5));

							if (PlayerMultiplayer.Instance.getPosX() <= this.getPosX())
							{
								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(Random.Range(5, 10), 0);
								}
							}
							else
							{
								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(Random.Range(5, 10), 0);
								}
							}

							if (PlayerMultiplayer.Instance.getPosX() <= this.getPosX())
							{

								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(0, Random.Range(5, 10));
								}
							}
							else
							{
								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(0, Random.Range(5, 10));
								}

							}

							if (Random.Range(0, 10) == 0)
							{
								//Dash();
							}
						}
					}
				}

				if (currentHealth > 400)
				{
					if (Random.Range(0, 120) == 0)
					{
						GameObject lp = Instantiate(lordPyrimites, new Vector2(getPosX(), getPosY()), Quaternion.identity);

						if (GameObject.Find("NetworkManager") != null)
						{
							NetworkServer.Spawn(lp);
						}
						else
						{
							return;
						}
					}
				}
				else if (currentHealth <= 400)
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

						if (GameObject.Find("NetworkManager") != null)
						{
							NetworkServer.Spawn(lp);
						}
						else
						{
							return;
						}
					}
				}
			}
		}
		else
		{
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

				if (!dashing)
				{
					if (!phaseTwoChange)
					{
						if (getPosX() >= Player.Instance.getPosX() - 5)
						{
							rb.AddForce(new Vector2(-2, 0));
						}
						else if (getPosX() <= Player.Instance.getPosX() - 5)

						{
							rb.AddForce(new Vector2(2, 0));
						}

						if (getPosY() >= Player.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, -2));
						}
						else if (getPosY() <= Player.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, 2));
						}

						if (Random.Range(0, 30) == 0)
						{
							//Dash();
						}

					}
					else if (phaseTwoChange)
					{
						if (getPosX() >= Player.Instance.getPosX() - 5)
						{
							rb.AddForce(new Vector2(-5, 0));
						}
						else if (getPosX() <= Player.Instance.getPosX() - 5)

						{
							rb.AddForce(new Vector2(5, 0));
						}

						if (getPosY() >= Player.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, -5));
						}
						else if (getPosY() <= Player.Instance.getPosY() - 5)
						{
							rb.AddForce(new Vector2(0, 5));

							if (Player.Instance.getPosX() <= this.getPosX())
							{
								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(Random.Range(5, 10), 0);
								}
							}
							else
							{
								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(Random.Range(5, 10), 0);
								}
							}

							if (Player.Instance.getPosX() <= this.getPosX())
							{

								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(0, Random.Range(5, 10));
								}
							}
							else
							{
								if (Random.Range(0, 30) == 0)
								{
									transform.position = new Vector2(0, Random.Range(5, 10));
								}

							}

							if (Random.Range(0, 10) == 0)
							{
								//Dash();
							}
						}
					}
				}

				if (currentHealth > 400)
				{
					if (Random.Range(0, 120) == 0)
					{
						GameObject lp = Instantiate(lordPyrimites, new Vector2(getPosX(), getPosY()), Quaternion.identity);
					}
				}
				else if (currentHealth <= 400)
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
	}

	public void Dash()
    {
		dashing = true;
		
		if (PlayerMultiplayer.Instance.getPosX() <= this.getPosX())
        {
			rb.AddForce(new Vector2(8, 0));
		} else
        {
			rb.AddForce(new Vector2(-8, 0));
		}

		if (PlayerMultiplayer.Instance.getPosY() <= this.getPosY())
		{
			rb.AddForce(new Vector2(0, 8));
		}
		else
		{
			rb.AddForce(new Vector2(0, -8));
		}
		dashing = false;
	}

	public void attack(int damage)
	{
		currentHealth -= damage;
	}


	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (fightStarted)
		{
			if (collision.gameObject.tag == "PlayerMultiplayer" && phaseTwoChange)
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
				attack(PlayerMultiplayer.Instance.damage);
				PlayerMultiplayer.justAttackedEntity = true;
            }
		}
	}
}
