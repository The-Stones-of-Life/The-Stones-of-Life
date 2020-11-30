using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;

public class Health : MonoBehaviour
{	
	public static int health = 500;
	public int maxHealth = 500;
	
	public int CMPlayerHealth;
	
	public struct userAttributes {	
	}

	public struct appAttributes {
	}
	
	public Text health_bar;
	
	void Start()
    {
		health_bar = GameObject.Find("HealthText").GetComponent<Text>();
		
		// Add a listener to apply settings when successfully retrieved:
        ConfigManager.FetchCompleted += ApplyRemoteSettings;
		
        // Fetch configuration setting from the remote service:
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

	void ApplyRemoteSettings(ConfigResponse configResponse) {
		
		CMPlayerHealth = ConfigManager.appConfig.GetInt("CMPlayerHealth");
		
		maxHealth = CMPlayerHealth;
		health = CMPlayerHealth;
	}
	
	
	// Update is called once per frame
	void Update () {
		health_bar.text = health.ToString();
		
		if (health <= 0) {
			
			health = maxHealth;
			
		}
		
		if (health >= maxHealth) {
			health = maxHealth;
		}
	}
	
	public void damageSelf(int damage) {
		health -= damage;
	}
}
