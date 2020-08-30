using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDefence : MonoBehaviour
{
   
   public static int defense = 0;

	public Text defT;

    void Start()
    {
		defT = GameObject.Find("Def").GetComponent<Text>();
    }
	
	void Update()
    {
		defT.text = defense.ToString();
    }
}
