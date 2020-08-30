using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPrefab
{
    
	public GameObject Prefab;
	public string Path;
	
    public NetworkedPrefab(GameObject obj, string path)
    {
        Prefab = obj;
		Path = ReturnPrefabModified(path);
    }
	
	private string ReturnPrefabModified(string path) {
		
		int extensionLength = System.IO.Path.GetExtension(path).Length;
		int startIndex = path.ToLower().IndexOf("resources");
		
		if (startIndex == -1) {
			return string.Empty;
		}
		else {
			return path.Substring(startIndex, path.Length - (startIndex + extensionLength));
		}
		
	}
}
