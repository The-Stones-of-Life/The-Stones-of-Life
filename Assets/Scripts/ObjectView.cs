using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView : MonoBehaviour
{
   
   public bool isVisiable;
   public GameObject prefab;
   
    void Update()
    {
        if (isVisiable == true) {	
			prefab.SetActive(true);	
		}
		else {
			prefab.SetActive(false);
		}
    }
	
	void OnBecameVisiable() {
		
		isVisiable = true;
		
	}
	
	void OnBecameInvisiable() {
		
		
		isVisiable = false;
	}
}
