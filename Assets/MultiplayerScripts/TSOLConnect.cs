using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class TSOLConnect : MonoBehaviourPunCallbacks
{
	public GameObject playerPrefab;
	public string GameVersion = "0.5";
	private string nickname = "Player";
	public string NickName
	{
		get
		{
			int value = Random.Range(0, 9999);
			return nickname = value.ToString();
		}
	}
	
    // Start is called before the first frame update
    private void Start()
    {
		print("Connecting to server");
		PhotonNetwork.NickName = nickname + NickName;
		PhotonNetwork.GameVersion = GameVersion;
		PhotonNetwork.AutomaticallySyncScene  = true;
		PhotonNetwork.ConnectUsingSettings();
    }
	
	public override void OnConnectedToMaster()
	{
		print("Connected to server");
		print(PhotonNetwork.LocalPlayer.NickName);
		PhotonNetwork.JoinLobby();
	}
	
	public override void OnDisconnected(DisconnectCause cause)
	{
		print("Disconnected from server");
	}
	
	public override void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
	}
	
	public void OnClick_StartGame()
	{
		if (PhotonNetwork.IsMasterClient)
		{
			PhotonNetwork.LoadLevel(3);
		}
	}
}
