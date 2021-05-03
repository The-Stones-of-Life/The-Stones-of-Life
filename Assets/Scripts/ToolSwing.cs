using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwing : MonoBehaviour
{

	public static float specialAbilityCooldownOne = 0;

    public Animation swing;

    public Sprite ironSword;
    public Sprite thePyrmidsSword;

    public SpriteRenderer toolRender;

    public BoxCollider2D coll;

    private void Update()
    {
		/*
		if (Player.Instance.selectedWeaponId == 1) {
			toolRender.sprite = ironSword;
		}
		if (Player.Instance.selectedWeaponId == 2) {
			toolRender.sprite = thePyrmidsSword;
		}
		if (Player.Instance.selectedWeaponId == 0) {
			toolRender.sprite = null;
		}
		
        if (Input.GetMouseButtonDown(0))
        {
            if (Player.Instance.selectedWeaponId == 1)
            {
                swing.Play();
                Player.Instance.isSwinging = true;
                coll.enabled = true;
            }
               
            if (Player.Instance.selectedWeaponId == 2)
            {
                swing.Play();
                Player.Instance.isSwinging = true;
                coll.enabled = true;
            }
        }

        if (!swing.isPlaying && Player.Instance.isSwinging)
        {
            Player.Instance.isSwinging = false;
            coll.enabled = false;
        }
		if (Input.GetKeyDown(KeyCode.M) && specialAbilityCooldownOne <= Time.time) {
			Player.sa1Active = true;
			specialAbilityCooldownOne = Time.time + 15;
			Debug.Log("Special Ablility One has been activated!");
		}
        */
        

        //Multiplayer changes needed
    }
}
