using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SaveSystem;

public class SaveWorld : MonoBehaviour
{	

	public static int saveId = 1;


	void Start() {
		
	}
	
	void Update() {
		if (Generate.saveWorld == true) {
			
			ES3.Save("gameobject" + saveId, this);
			saveId += 1;
			
		}
	}
}
