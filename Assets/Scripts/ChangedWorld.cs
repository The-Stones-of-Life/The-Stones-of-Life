using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedWorld : MonoBehaviour
{
	
	public Inventory2 inv;
	
    void Start()
    {
		inv = GameObject.Find("inventory").GetComponent<Inventory2>();
		inv.LoadInv();
    }
	
	void Update()
    {
		inv = GameObject.Find("inventory").GetComponent<Inventory2>();
    }
}
