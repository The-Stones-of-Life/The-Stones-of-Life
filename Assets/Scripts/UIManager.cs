using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public GameObject workbenchUI;
	public GameObject furnaceUI;
	public GameObject anvilUI;
	
	 public static UIManager Instance { get; private set; }
	
	void Awake() {
		Instance = this;
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			workbenchUI.SetActive(false);
			furnaceUI.SetActive(false);
			anvilUI.SetActive(false);
		}
	}
}
