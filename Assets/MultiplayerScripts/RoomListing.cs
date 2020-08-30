using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
	 [SerializeField]
	 private Text text;
	 
	 public RoomInfo RoomInfo { get; private set; }
	
	 public void SetRoomInfo(RoomInfo roomInfo)
	 {
		 RoomInfo = roomInfo;
		 text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
	 } 
	 
	 public void Onlick_Button()
	 {
		 PhotonNetwork.JoinRoom(RoomInfo.Name);
	 }
}
