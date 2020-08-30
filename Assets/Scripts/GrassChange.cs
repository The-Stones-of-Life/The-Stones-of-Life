using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassChange : MonoBehaviour
{
	private InDepthTime TMngr;
	
	public SpriteRenderer Grass;
	
	public Sprite grass_spring;
	public Sprite grass_summer;
	public Sprite grass_fall;
	public Sprite grass_winter;
	
    void Start()
    {
		TMngr = GameObject.Find("TimeManager").GetComponent<InDepthTime>();
    }

    void Update()
    {
        if (TMngr.season == 1) {
			Grass.sprite = grass_spring;
		}
		
		if (TMngr.season == 2) {
			Grass.sprite = grass_summer;
		}
		
		if (TMngr.season == 3) {
			Grass.sprite = grass_fall;
		}
		
		if (TMngr.season == 4) {
			Grass.sprite = grass_winter;
		}
    }
}
