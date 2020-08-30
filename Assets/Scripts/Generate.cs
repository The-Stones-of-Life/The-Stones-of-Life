using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;

public class Generate : MonoBehaviour
{
	
	public static bool loadWorld = false;
	public static bool saveWorld = false;
	
	public int loadedTiles = 1;

    public int width;
    public int height;
    public int distance;
    public int space;
	
	[System.Serializable]
	public class Pool {
		
		public string idk;
		public GameObject Grass;
		public GameObject Dirt;
		public GameObject Stone;
		public GameObject Tree1;
		public GameObject Tree2;
		public GameObject Tree3;
		public GameObject AbandonHouse;
		public GameObject Coal;
		public GameObject Iron;
		public GameObject CrudeOilOre;
		public GameObject GoldOre;
		public GameObject DiamondOre;
		public GameObject MudPuddle;
                
		
	}

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;
    public float heightpoint;
    public float heightpoint2;


    // Use this for initialization
    void Start()
    {
        Generation();
    }

    void Generation()
    {
		if (loadWorld == false) {
		
			poolDictionary = new Dictionary<string, Queue<GameObject>>();
			
			foreach (Pool pool in pools) {
				
			Queue<GameObject> objectPool = new Queue<GameObject>();
				
				distance = height;
				for (int w = 0; w < width; w++)
				{
					int lowernum = distance - 1;
					int heighernum = distance + 2;
					distance = Random.Range(lowernum, heighernum);
					space = Random.Range(12, 20);
					int stonespace = distance - space;


					for (int j = 0; j < stonespace; j++)
					{
						GameObject stone = Instantiate(pool.Stone, new Vector3(w, j), Quaternion.identity) as GameObject;
						objectPool.Enqueue(stone);
						
						if (Random.Range(1, 10) == 1) {
							
							GameObject coal = Instantiate(pool.Coal, new Vector3(w, j), Quaternion.identity) as GameObject;
							objectPool.Enqueue(coal);
							
						}
						
						if (Random.Range(1, 15) == 1) {
							
							GameObject iron = Instantiate(pool.Iron, new Vector3(w, j), Quaternion.identity) as GameObject;
							objectPool.Enqueue(iron);
							
						}
						
						if (Random.Range(1, 115) == 1) {
							
							GameObject coo = Instantiate(pool.CrudeOilOre, new Vector3(w, j), Quaternion.identity) as GameObject;
							objectPool.Enqueue(coo);
							
						}
						
						if (Random.Range(1, 200) == 1) {
							
							GameObject goldOre = Instantiate(pool.GoldOre, new Vector3(w, j), Quaternion.identity) as GameObject;
							objectPool.Enqueue(goldOre);
							
						}
						
						if (Random.Range(1, 350) == 1) {
							
							GameObject diamondOre = Instantiate(pool.DiamondOre, new Vector3(w, j), Quaternion.identity) as GameObject;
							objectPool.Enqueue(diamondOre);
							
						}
					}

					for (int j = stonespace; j < distance; j++)
					{
						GameObject dirt = Instantiate(pool.Dirt, new Vector3(w, j), Quaternion.identity) as GameObject;
						objectPool.Enqueue(dirt);
					}
					GameObject grass = Instantiate(pool.Grass, new Vector3(w, distance), Quaternion.identity);
					objectPool.Enqueue(grass);
					if (Random.Range(1, 21) == 1) {
						
						GameObject tree1 = Instantiate(pool.Tree1, new Vector3(w, distance + 4), Quaternion.identity) as GameObject;
						objectPool.Enqueue(tree1);
						
					}
					if (Random.Range(1, 45) == 1) {
						
						GameObject mudPuddle = Instantiate(pool.MudPuddle, new Vector3(w, distance), Quaternion.identity) as GameObject;
						objectPool.Enqueue(mudPuddle);
						
					}
					if (Random.Range(1, 26) == 1) {
						
						GameObject tree2 = Instantiate(pool.Tree2, new Vector3(w, distance + 4), Quaternion.identity) as GameObject;
						objectPool.Enqueue(tree2);
						
					}
					if (Random.Range(1, 33) == 1) {
						
						GameObject tree3 = Instantiate(pool.Tree3, new Vector3(w, distance + 4), Quaternion.identity) as GameObject;
						objectPool.Enqueue(tree3);
						
					}
					
					if (Random.Range(1, 150) == 1) {
						
						GameObject house = Instantiate(pool.AbandonHouse, new Vector3(w, distance + 1), Quaternion.identity) as GameObject;
						objectPool.Enqueue(house);
						
					}
				}
				
				poolDictionary.Add(pool.idk, objectPool);

			}
		}
    }
	
	public GameObject spawnFromPool(string idk) {
		
		
		GameObject objectsToSpawn = poolDictionary[idk].Dequeue();
		
		objectsToSpawn.SetActive(true);
		
		poolDictionary[idk].Enqueue(objectsToSpawn);
		
		return objectsToSpawn;
		
	}
}
