using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TerrainEngine2D;

public class Spacecraft : MonoBehaviour
{
	public SpriteRenderer player;
	public CameraController cc;
	
	public Rigidbody2D rb;
	
	void Update() {
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(new Vector2(0, 8));
		}
		
	}
	
	void OnMouseDown() {
		
		player.enabled = false;
		cc.objectToFollow = this.transform;
		
	}
}
