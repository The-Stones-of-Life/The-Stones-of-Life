using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefabs : MonoBehaviour
{
	
	public static GameObject player;
	public static string Path;
	
    // Start is called before the first frame update
    void NetworkedPrefab(GameObject obj, string path)
    {
		player = obj;
		Path = path;
	}
	
	private string ReturnPrefabPathModified(string path)
	{
		int extensionLength = System.IO.Path.GetExtension(path).Length;
		int startIndex = path.ToLower().IndexOf("resources");
		
		if (startIndex == -1)
		{
			return string.Empty;
		}else{
			return path.Substring(startIndex, path.Length - ( startIndex + extensionLength));
		}
	}
}
