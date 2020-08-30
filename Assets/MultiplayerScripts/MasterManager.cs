using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[CreateAssetMenu(menuName = "Singleton/MasterManager")]
public class MasterManager : ScriptableObject
{
    [SerializeField]
	private static GameSettingsTSOL _gameSettings;
	public static GameSettingsTSOL GameSettingsTSOL { get { return _gameSettings; } }
}