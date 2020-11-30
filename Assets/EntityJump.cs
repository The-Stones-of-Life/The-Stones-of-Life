using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityJump : MonoBehaviour
{
	
	public Rigidbody2D rb;
	
    void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Terrain") {
			rb.AddForce(Vector2.up * 100f);
		}
	}
}
