using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	public Rigidbody2D rb;
	public Transform trans;
	
	public int damage;
	
    void Update()
    {
		rb.velocity = new Vector2(5, 0);
    }
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag != "Sludge") {
			
			Destroy(this.gameObject);
			
			if (coll.gameObject.tag == "Player") {
				Health.health -= damage - PlayerDefence.defense;
			}
		}
	}
}
