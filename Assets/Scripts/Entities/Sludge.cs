using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sludge : MonoBehaviour
{
    public int health = 50;
	public GameObject sludgeBall;
	public Transform trans;
	
	Vector3 localScale;
	
	public Rigidbody2D rb;
	
    void Update()
    {
        if (health <= 1)
		{
			Destroy(this.gameObject);
		}
		
		if (Random.Range(1, 100) == 1) {
			Instantiate(sludgeBall, new Vector2(trans.position.x, trans.position.y), Quaternion.identity);
		}
    }
	
	void OnMouseDown() {
		
		health -= Player.Instance.damage;
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Health.health -= 7 - PlayerDefence.defense;
		}
	}
}
