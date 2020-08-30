using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
   [SerializeField]
   private Text roomName;
   
  public void OnClick_CreateRoom()
  {
	  if (!PhotonNetwork.IsConnected)
		return;
	
	  RoomOptions options = new RoomOptions();
	  options.MaxPlayers = 8;
	  PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);
  }
  
  public override void OnCreatedRoom()
  {
	  Debug.Log("Created Room Sucessfuly", this);
	  SceneManager.LoadScene(1);
  }
  
  public override void OnCreateRoomFailed(short returnCode, string message)
  {
	  Debug.Log("Creating room failed" + message, this);
  }
}
