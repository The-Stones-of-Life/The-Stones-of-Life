using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesChange : MonoBehaviour
{
	private InDepthTime TMngr;
	
	public SpriteRenderer Leaves;
	
	public Sprite leaves_spring;
	public Sprite leaves_summer;
	public Sprite leaves_fall;
	public Sprite leaves_winter;
	
    void Start()
    {
		TMngr = GameObject.Find("TimeManager").GetComponent<InDepthTime>();
    }

    void Update()
    {
        if (TMngr.season == 1) {
			Leaves.sprite = leaves_spring;
		}
		
		if (TMngr.season == 2) {
			Leaves.sprite = leaves_summer;
		}
		
		if (TMngr.season == 3) {
			Leaves.sprite = leaves_fall;
		}
		
		if (TMngr.season == 4) {
			Leaves.sprite = leaves_winter;
		}
    }
}
