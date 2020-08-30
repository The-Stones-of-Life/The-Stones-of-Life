using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerManager : MonoBehaviourPunCallbacks
{
	[Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
	public static GameObject LocalPlayerInstance;
	
	#if !UNITY_5_4_OR_NEWER
	/// <summary>See CalledOnLevelWasLoaded. Outdated in Unity 5.4.</summary>
	void OnLevelWasLoaded(int level)
	{
		this.CalledOnLevelWasLoaded(level);
	}
	#endif

	#if UNITY_5_4_OR_NEWER
	public override void OnDisable()
	{
		// Always call the base to remove callbacks
		base.OnDisable ();
		UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
	}	
	#endif

	void CalledOnLevelWasLoaded(int level)
	{
		// check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
		if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
		{
			transform.position = new Vector3(0f, 5f, 0f);
		}
	}
	
	void Awake()
	{
		if (photonView.IsMine)
		{
			PlayerManager.LocalPlayerInstance = this.gameObject;
		}
		// #Critical
		// we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Start()
	{
		#if UNITY_5_4_OR_NEWER
		// Unity 5.4 has a new scene management. register a method to call CalledOnLevelWasLoaded.
		UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
		#endif
	}
	
	#if UNITY_5_4_OR_NEWER
	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadingMode)
	{
		this.CalledOnLevelWasLoaded(scene.buildIndex);
	}
	#endif
}

	
