using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowHolder : MonoBehaviour
{
  
	public SpriteRenderer bow;
	
	public Sprite woodenBow;
	
    void Update()
    {
        if (Player.Instance.holdingBow) {
			bow.sprite = woodenBow;
		} else {
			bow.sprite = null;
		}
    }
}
