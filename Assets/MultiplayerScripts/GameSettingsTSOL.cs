using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettingsTSOL : ScriptableObject
{
    [SerializeField]
	private string gameversion = "0.5";
	
	public string GameVersion { get { return gameversion;} }
	[SerializeField]
	private string nickname = "Ryorama";
	public string NickName
	{
		get
		{
			int value = Random.Range(0, 9999);
			return nickname = value.ToString();
		}
	}
}
