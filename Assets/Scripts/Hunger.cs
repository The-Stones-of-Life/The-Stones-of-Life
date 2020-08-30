using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;

public class Hunger : MonoBehaviour
{
	
    public static int hunger = 500;
    public int maxHunger = 500;

    public int time = 0;
	
	public struct userAttributes {	
	}

	public struct appAttributes {
	}
	
	public int CMPlayerHunger;
	
    public Text hungerAmnt;

	void Start() {
		
		hungerAmnt = GameObject.Find("Hungertext").GetComponent<Text>();
		
		// Add a listener to apply settings when successfully retrieved:
        ConfigManager.FetchCompleted += ApplyRemoteSettings;
		
        // Fetch configuration setting from the remote service:
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
	}
	
	void ApplyRemoteSettings(ConfigResponse configResponse) {
		
		CMPlayerHunger = ConfigManager.appConfig.GetInt("CMPlayerHunger");
		
		maxHunger = CMPlayerHunger;
		hunger = CMPlayerHunger;
	}

    void Update()
    {
	
		hungerAmnt.text = hunger.ToString();
		
		time += 1;
		
		if (hunger >= maxHunger) {
			hunger = maxHunger;
		}
		
		if (time >= 1000 && hunger >= 1) {
			hunger -= 10;
			time = 0;
		}
		else {
			if (time >= 1000)
			{
				time = 0;
			}
		}

		if (hunger == 0)
		{
			Health.health -= 5;
		}
    }
}
