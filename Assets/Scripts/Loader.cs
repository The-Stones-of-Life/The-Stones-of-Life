using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
	
	public Generate gen;
  
    void FixedUpdate()
    {
        gen.spawnFromPool("idk");
    }
}
