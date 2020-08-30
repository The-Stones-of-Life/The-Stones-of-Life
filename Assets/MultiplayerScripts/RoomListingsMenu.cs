using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
	[SerializeField]
	private RoomListing roomListing;
	[SerializeField]	
	private Transform content;
	
	private List<RoomListing> _listing = new List<RoomListing>();
	
	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		foreach (RoomInfo info in roomList)
		{
			if (info.RemovedFromList)
			{
				int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
				if (index != -1)
				{
					Destroy(_listing[index].gameObject);
					_listing.RemoveAt(index);
				}
			}else {
				RoomListing listing = Instantiate(roomListing, content);
				if (listing != null)
				{
					listing.SetRoomInfo(info);
					_listing.Add(listing);
				}
			}
		}
	}
}