using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveALoad
{
    public static void SaveInventory(Inventory2 inv)
    {
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/inv.tsolsave";
		FileStream stream = new FileStream(path, FileMode.Create);
		
		Inventory2Data data = new Inventory2Data(inv);
		
		formatter.Serialize(stream, data);
		stream.Close();
	}
	
	public static Inventory2Data LoadInventory()
	{
		string path = Application.persistentDataPath + "/inv.tsolsave";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			
			Inventory2Data data = formatter.Deserialize(stream) as Inventory2Data;
			stream.Close();
			
			return data;
		}
		else {
			Debug.Log("No Save File Found");
			return null;
		}
	}
}
