using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{	
	public static int health = 500;
	public static int maxHealth = 500;
	
	public int CMPlayerHealth;
	
	public struct userAttributes {	
	}

	public struct appAttributes {
	}
	
	public Text health_bar;

    [System.Obsolete]
    void Start()
	{
		health_bar = GameObject.Find("Canvas").transform.FindChild("Health").transform.FindChild("HealthText").GetComponent<Text>();
	}


	// Update is called once per frame
	void Update()
	{
		health_bar.text = health.ToString();

		if (health >= maxHealth)
        {
			health = maxHealth;
        }
	}

	public static void killPlayer()
    {
		health = maxHealth;
    }
}
