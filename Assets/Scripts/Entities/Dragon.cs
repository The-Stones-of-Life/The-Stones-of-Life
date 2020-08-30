using UnityEngine;
using System.Collections;
 
public class Dragon : MonoBehaviour
{
    private GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    private Rigidbody2D rb;
	
	public int health;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		target = GameObject.Find("Player");
    }
    void Update()
    {
		 if (health <= 1)
		{
			Destroy(this.gameObject);
		}
        //move towards the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
	
	void OnMouseDown() {
		
		if (IronSword.isHolding == true) {
			
			health -= IronSword.damage;
			IronSword.durability -= 100;			
		}
		else {
		  health -= 1;
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Health.health -= 30 - PlayerDefence.defense;
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "FireSpell") {
			
			health -= 15;
			
		}
	}
}