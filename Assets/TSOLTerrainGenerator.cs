using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TerrainEngine2D;

namespace TerrainEngine2D {
	public class TSOLTerrainGenerator : TerrainGenerator
	{

		//seeds I like:
		//-1526726

		//18162338

		//-21433383
		public enum Layers { Main, Background }
		public enum MainLayer { Grass, Dirt, Stone, Log, Leaves, Planks, Workbench, IronOre, Furnace, CoalOre, Anvil, Sand, Snow }
		public enum BackgroundLayer { GrassPlant, TallGrasPlant, BrownMushroom, Lifeshroom, Sticks }
		
		public int currentBiomeId = 1;

		public static List<int> worldBiomeList = new List<int>();
		
		public enum FluidType { Water, Lava }

		public override void GenerateData()
		{
			
			base.GenerateData();
			//Pass 1

			if (GameObject.Find("NetworkManager") != null)
			{
				for (int x2 = 0; x2 < worldMultiplayer.WorldWidth; x2++)
				{

					if (x2 % 200 == 0)
					{
						if (random.Next(0, 2) == 0)
						{
							currentBiomeId = 1;
							worldBiomeList.Add(1);
						}
						else if (random.Next(0, 2) == 0)
						{
							currentBiomeId = 2;
							worldBiomeList.Add(2);
						}
						else
						{
							currentBiomeId = 3;
							worldBiomeList.Add(3);
						}

					}

					//-----Add height variables here-----
					int groundLevel = PerlinNoise(x2, 0, 75, 20, 1);
					groundLevel += PerlinNoise(x2, 0, 45, 30, 1);
					groundLevel += PerlinNoise(x2, 0, 8, 8, 1);
					groundLevel += 60;

					int stoneLevel = PerlinNoise(x2, 0, 70, 20, 1);
					stoneLevel += PerlinNoise(x2, 0, 40, 35, 1);
					stoneLevel += 50;
					//----------
					for (int y = 0; y < worldMultiplayer.WorldHeight; y++)
					{
						//-----Set block data here-----
						if (y <= groundLevel)
						{
							//Start with a layer of dirt covering the whole ground level

							if (currentBiomeId == 1)
							{
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Dirt);
								SetBlock(x2, y + 1, (byte)Layers.Main, (byte)MainLayer.Grass);
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Dirt, 20);
							}
							else if (currentBiomeId == 2)
							{
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Sand);
								SetBlock(x2, y + 1, (byte)Layers.Main, (byte)MainLayer.Sand);
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Sand, 20);
							}
							else if (currentBiomeId == 3)
							{
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Snow);
								SetBlock(x2, y + 1, (byte)Layers.Main, (byte)MainLayer.Snow);
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Snow, 20);
							}
							if (y < groundLevel - random.Next(5, 20))
							{
								if (currentBiomeId == 1)
								{

									//Place large rock chunks in pseudo random positions and add clumps of ore
									if (PerlinNoise(x2 * 4, y, 5, 6, 1) > 1)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Stone);
										//Place ore in pseudo-random positions in rocks
										if (PerlinNoise(x2, y * 2, 9, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.IronOre);
										}
										if (PerlinNoise(x2, y * 2, 13, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.CoalOre);
										}
									}
									//Add hard dirt clumps in pseudo random positions
									if (PerlinNoise(x2, y, 15, 16, 1) > 8)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Dirt);
									}
								}
								else if (currentBiomeId == 2)
								{
									//Place large rock chunks in pseudo random positions and add clumps of ore
									if (PerlinNoise(x2 * 4, y, 5, 6, 1) > 1)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Sand);
										//Place ore in pseudo-random positions in rocks
										if (PerlinNoise(x2, y * 2, 9, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.IronOre);
										}
										if (PerlinNoise(x2, y * 2, 13, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.CoalOre);
										}
									}
								}
								else if (currentBiomeId == 3)
								{
									//Place large rock chunks in pseudo random positions and add clumps of ore
									if (PerlinNoise(x2 * 4, y, 5, 6, 1) > 1)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Snow);
										//Place ore in pseudo-random positions in rocks
										if (PerlinNoise(x2, y * 2, 9, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.IronOre);
										}
										if (PerlinNoise(x2, y * 2, 13, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.CoalOre);
										}
									}
								}
							}
							//Remove clumps of main and ore to create caves
							if (PerlinNoise(x2, y, 10, 10, 1) > 5)
							{
								RemoveBlock(x2, y, (byte)Layers.Main);
							}

							if (currentBiomeId == 1)
							{

								//Add foreground elements and trees to the top of the ground level if there is a main block there
								if (y == groundLevel && IsBlockAt(x2, y, (byte)Layers.Main))
								{

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.GrassPlant, 16);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.TallGrasPlant, 12);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.BrownMushroom, 7);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.Lifeshroom, 3);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.Sticks, 10);
								}

								if (x2 >= 5)
								{

									if (currentBiomeId == 1)
									{
										//Places a tree with 10% probability
										if (DoAddBlock(130))
										{
											bool genTree = true;
											//Check for enough room to place a stump
											if (IsBlockAt(x2 - 1, y + 1, (byte)Layers.Main))
												genTree = false;
											//Check for a tree within 7 blocks away
											for (int x2Tree = x2 - 6; x2Tree < x2; x2Tree++)
											{
												//Check for blocks of trees at a few different vertical positions (since tree sizes and positions vary)
												if (IsBlockAt(x2Tree, y + 2, (byte)Layers.Main) || IsBlockAt(x2Tree, y + 5, (byte)Layers.Main) || IsBlockAt(x2Tree, y + 8, (byte)Layers.Main))
												{
													genTree = false;
													break;
												}
											}
											//Generate a tree if there are none nearby
											if (genTree)
											{
												//Set stump at a horizontal offset since it is 3 blocks wide
												SetBlock(x2, y + 2, (byte)Layers.Main, (byte)MainLayer.Log);
												//Randomly generate a tree height between 5 and 12 blocks high
												int treeHeight = random.Next(5, 12);
												//Loop up the height of the tree
												for (int yTree = y + 3; yTree < y + treeHeight; yTree++)
												{
													SetBlock(x2, yTree, (byte)Layers.Main, (byte)MainLayer.Log);
												}

												for (int i = x2; i <= x2 + 2; i++)
												{
													for (int j = treeHeight + 1; j <= treeHeight + 3; j++)
													{
														SetBlock(i, j, (byte)Layers.Main, (byte)MainLayer.Leaves);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				for (int x2 = 0; x2 < world.WorldWidth; x2++)
				{

					if (x2 % 200 == 0)
					{
						if (random.Next(0, 2) == 0)
						{
							currentBiomeId = 1;
							worldBiomeList.Add(1);
						}
						else if (random.Next(0, 2) == 0)
						{
							currentBiomeId = 2;
							worldBiomeList.Add(2);
						}
						else
						{
							currentBiomeId = 3;
							worldBiomeList.Add(3);
						}

					}

					//-----Add height variables here-----
					int groundLevel = PerlinNoise(x2, 0, 75, 20, 1);
					groundLevel += PerlinNoise(x2, 0, 45, 30, 1);
					groundLevel += PerlinNoise(x2, 0, 8, 8, 1);
					groundLevel += 60;

					int stoneLevel = PerlinNoise(x2, 0, 70, 20, 1);
					stoneLevel += PerlinNoise(x2, 0, 40, 35, 1);
					stoneLevel += 50;
					//----------
					for (int y = 0; y < world.WorldHeight; y++)
					{
						//-----Set block data here-----
						if (y <= groundLevel)
						{
							//Start with a layer of dirt covering the whole ground level

							if (currentBiomeId == 1)
							{
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Dirt);
								SetBlock(x2, y + 1, (byte)Layers.Main, (byte)MainLayer.Grass);
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Dirt, 20);
							}
							else if (currentBiomeId == 2)
							{
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Sand);
								SetBlock(x2, y + 1, (byte)Layers.Main, (byte)MainLayer.Sand);
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Sand, 20);
							}
							else if (currentBiomeId == 3)
							{
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Snow);
								SetBlock(x2, y + 1, (byte)Layers.Main, (byte)MainLayer.Snow);
								SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Snow, 20);
							}
							if (y < groundLevel - random.Next(5, 20))
							{
								if (currentBiomeId == 1)
								{

									//Place large rock chunks in pseudo random positions and add clumps of ore
									if (PerlinNoise(x2 * 4, y, 5, 6, 1) > 1)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Stone);
										//Place ore in pseudo-random positions in rocks
										if (PerlinNoise(x2, y * 2, 9, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.IronOre);
										}
										if (PerlinNoise(x2, y * 2, 13, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.CoalOre);
										}
									}
									//Add hard dirt clumps in pseudo random positions
									if (PerlinNoise(x2, y, 15, 16, 1) > 8)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Dirt);
									}
								}
								else if (currentBiomeId == 2)
								{
									//Place large rock chunks in pseudo random positions and add clumps of ore
									if (PerlinNoise(x2 * 4, y, 5, 6, 1) > 1)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Sand);
										//Place ore in pseudo-random positions in rocks
										if (PerlinNoise(x2, y * 2, 9, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.IronOre);
										}
										if (PerlinNoise(x2, y * 2, 13, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.CoalOre);
										}
									}
								}
								else if (currentBiomeId == 3)
								{
									//Place large rock chunks in pseudo random positions and add clumps of ore
									if (PerlinNoise(x2 * 4, y, 5, 6, 1) > 1)
									{
										SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.Snow);
										//Place ore in pseudo-random positions in rocks
										if (PerlinNoise(x2, y * 2, 9, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.IronOre);
										}
										if (PerlinNoise(x2, y * 2, 13, 12, 1) > 8)
										{
											RemoveBlock(x2, y, (byte)Layers.Main);
											SetBlock(x2, y, (byte)Layers.Main, (byte)MainLayer.CoalOre);
										}
									}
								}
							}
							//Remove clumps of main and ore to create caves
							if (PerlinNoise(x2, y, 10, 10, 1) > 5)
							{
								RemoveBlock(x2, y, (byte)Layers.Main);
							}

							if (currentBiomeId == 1)
							{

								//Add foreground elements and trees to the top of the ground level if there is a main block there
								if (y == groundLevel && IsBlockAt(x2, y, (byte)Layers.Main))
								{

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.GrassPlant, 16);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.TallGrasPlant, 12);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.BrownMushroom, 7);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.Lifeshroom, 3);

									SetBlock(x2, y + 2, (byte)Layers.Background, (byte)BackgroundLayer.Sticks, 10);
								}

								if (x2 >= 5)
								{

									if (currentBiomeId == 1)
									{
										//Places a tree with 10% probability
										if (DoAddBlock(130))
										{
											bool genTree = true;
											//Check for enough room to place a stump
											if (IsBlockAt(x2 - 1, y + 1, (byte)Layers.Main))
												genTree = false;
											//Check for a tree within 7 blocks away
											for (int x2Tree = x2 - 6; x2Tree < x2; x2Tree++)
											{
												//Check for blocks of trees at a few different vertical positions (since tree sizes and positions vary)
												if (IsBlockAt(x2Tree, y + 2, (byte)Layers.Main) || IsBlockAt(x2Tree, y + 5, (byte)Layers.Main) || IsBlockAt(x2Tree, y + 8, (byte)Layers.Main))
												{
													genTree = false;
													break;
												}
											}
											//Generate a tree if there are none nearby
											if (genTree)
											{
												//Set stump at a horizontal offset since it is 3 blocks wide
												SetBlock(x2, y + 2, (byte)Layers.Main, (byte)MainLayer.Log);
												//Randomly generate a tree height between 5 and 12 blocks high
												int treeHeight = random.Next(5, 12);
												//Loop up the height of the tree
												for (int yTree = y + 3; yTree < y + treeHeight; yTree++)
												{
													SetBlock(x2, yTree, (byte)Layers.Main, (byte)MainLayer.Log);
												}

												for (int i = x2; i <= x2 + 2; i++)
												{
													for (int j = treeHeight + 1; j <= treeHeight + 3; j++)
													{
														SetBlock(i, j, (byte)Layers.Main, (byte)MainLayer.Leaves);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}