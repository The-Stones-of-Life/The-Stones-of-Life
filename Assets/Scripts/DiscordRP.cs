using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordRP : MonoBehaviour {

	public Discord.Discord discord;

	// Use this for initialization
	void Start () {
		discord = new Discord.Discord(693806096183197766, (System.UInt64)Discord.CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			State = "In Game",
			Details = "In the world ",
			Assets = 
			{
				
				LargeImage = "tsol",
				LargeText = "tsol",
				
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("Everything is fine!");
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
		discord.RunCallbacks();
	}
}