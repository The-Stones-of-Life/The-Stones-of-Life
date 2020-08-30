using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;
using UnityEngine.SceneManagement;
using Mirror;

public class NetworkGenerate : NetworkBehaviour
{
	
	public static bool loadWorld = false;
	public static bool saveWorld = false;
	
	public int loadedTiles = 1;

    public int width;
    public int height;
    public int distance;
    public int space;
	public string idk;
	
	public NetworkIdentity Grass;
	public NetworkIdentity Dirt;
	public NetworkIdentity Stone;
	public NetworkIdentity Tree1;
	public NetworkIdentity Tree2;
	public NetworkIdentity Tree3;
	public NetworkIdentity AbandonHouse;
	public NetworkIdentity Coal;
	public NetworkIdentity Iron;
	public NetworkIdentity CrudeOilOre;
    public float heightpoint;
    public float heightpoint2;
	
	public override void OnStartServer() {
		Generation();
	}
	
    void Generation()
    {
		if (loadWorld == false) {
				
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
						GameObject stone = Instantiate(Stone.gameObject, new Vector3(w, j), Quaternion.identity);
						NetworkServer.Spawn(stone);
						SceneManager.MoveGameObjectToScene(stone, gameObject.scene);
						
						if (Random.Range(1, 10) == 1) {
							
							GameObject coal = Instantiate(Coal.gameObject, new Vector3(w, j), Quaternion.identity);
							NetworkServer.Spawn(coal);
							SceneManager.MoveGameObjectToScene(coal, gameObject.scene);
							
						}
						
						if (Random.Range(1, 15) == 1) {
							
							GameObject iron = Instantiate(Iron.gameObject, new Vector3(w, j), Quaternion.identity);
							SceneManager.MoveGameObjectToScene(iron, gameObject.scene);
							NetworkServer.Spawn(iron);
							
						}
						
						if (Random.Range(1, 115) == 1) {
							
							GameObject coo = Instantiate(CrudeOilOre.gameObject, new Vector3(w, j), Quaternion.identity);
							NetworkServer.Spawn(coo);
							SceneManager.MoveGameObjectToScene(coo, gameObject.scene);
							
						}
					}

					for (int j = stonespace; j < distance; j++)
					{
						GameObject dirt = Instantiate(Dirt.gameObject, new Vector3(w, j), Quaternion.identity);
						NetworkServer.Spawn(dirt);
						SceneManager.MoveGameObjectToScene(dirt, gameObject.scene);
					}
					GameObject grass = Instantiate(Grass.gameObject, new Vector3(w, distance), Quaternion.identity);
					NetworkServer.Spawn(grass);
					SceneManager.MoveGameObjectToScene(grass, gameObject.scene);
					
					if (Random.Range(1, 21) == 1) {
						
						GameObject tree1 = Instantiate(Tree1.gameObject, new Vector3(w, distance + 4), Quaternion.identity);
						SceneManager.MoveGameObjectToScene(tree1, gameObject.scene);
						NetworkServer.Spawn(tree1);
						
					}
					if (Random.Range(1, 26) == 1) {
						
						GameObject tree2 = Instantiate(Tree2.gameObject, new Vector3(w, distance + 4), Quaternion.identity);
						SceneManager.MoveGameObjectToScene(tree2, gameObject.scene);
						NetworkServer.Spawn(tree2);
						
					}
					if (Random.Range(1, 33) == 1) {
						
						GameObject tree3 = Instantiate(Tree3.gameObject, new Vector3(w, distance + 4), Quaternion.identity);
						SceneManager.MoveGameObjectToScene(tree3, gameObject.scene);
						NetworkServer.Spawn(tree3);
						
					}
					
					if (Random.Range(1, 150) == 1) {
						
						GameObject house = Instantiate(AbandonHouse.gameObject, new Vector3(w, distance + 1), Quaternion.identity);
						SceneManager.MoveGameObjectToScene(house, gameObject.scene);
						NetworkServer.Spawn(house);
						
					}
				}

			}
	}
}
