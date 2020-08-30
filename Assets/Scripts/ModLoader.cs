using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.IO;
using static System.Environment;

public class ModLoader : MonoBehaviour
{	
	public JsonData scriptData;
	
	public static List<ModComponent> modFeatures = new List<ModComponent>();
	
    void Start()
    {
		
		string homeRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		
		string TestDir = homeRoot;
		
		string modFile = homeRoot + "/tsolMods/Mod.json";
		
		string tsolModDir = homeRoot + "/tsolMods";
		
		if (!File.Exists(tsolModDir)) {
			
			Directory.CreateDirectory(homeRoot + "/tsolMods");
			
		}
		
		if (!File.Exists(modFile)) {
			string path = homeRoot + "/tsolMods/Mod.json";
			
			FileStream stream = new FileStream(path, FileMode.Create);
			stream.Close();
		}
			
		scriptData = JsonMapper.ToObject(File.ReadAllText(homeRoot + "/tsolMods/Mod.json"));
		
		LoadModScripts();
    }
	
	public static ModComponent FetchItemById(int id)
	{
		for (int i = 0; i < modFeatures.Count; i++)
		{
			if (modFeatures[i].ID == id)
			{
				return modFeatures[i];
			}
		}

		return null;
	}
	
	public void LoadModScripts()
    {
       for (int i = 0; i < scriptData.Count; i++) {

			ModComponent newModElement = new ModComponent();

			newModElement.Type = scriptData[i]["Type"].ToString();
			newModElement.Name = scriptData[i]["Name"].ToString();
			newModElement.hasDurablility = (bool)scriptData[i]["hasDurablility"];
			newModElement.Texture = Resources.Load<Sprite>("Texture");
			newModElement.ID = (int)scriptData[i]["ID"];
			
			modFeatures.Add(newModElement);
	   }   
    }
}

public class ModComponent 
{	
	public int ID { get; set; }
	public string Type { get; set; }
	public string Name{ get; set; }
	public bool hasDurablility { get; set; }
	public Sprite Texture { get; set; }
	
	public string typeT { get; set; }
	public string nameT { get; set; }
	public string hasDurablilityT { get; set; }
	public string textureT { get; set; }
}
