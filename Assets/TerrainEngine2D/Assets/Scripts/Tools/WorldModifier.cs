﻿using System.Collections.Generic;
using UnityEngine;

// Copyright (C) 2018 Matthew K Wilson

namespace TerrainEngine2D
{
    /// <summary>
    /// Controls modification of the World.Instance
    /// </summary>
    public class WorldModifier
    {
		
		static bool alreadyBroken = false;
		static int health = 0;
		static int brokenBlockId = 0;
		
		public static DropedItem dropItem;
		
        /// <summary>
        /// Places fluid at a specific location in the world
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="amount">Amount of fluid to place</param>
        /// <param name="radius">How many surrounding blocks get fluid</param>
        /// <param name="density">The density of the fluid (or type) - used by the Advanced Fluid Dynamics</param>
		
		public static void PlaceFluid(int x, int y, float amount, int radius = 0, byte density = 0, Color32 color = new Color32())
        {
            //Place fluid as long as it isn't disabled
            if (!World.Instance.FluidDisabled)
            {
                //Loop through all surrounding blocks according to the radius
                for (int posX = x - radius; posX <= x + radius; posX++)
                {
                    for (int posY = y - radius; posY <= y + radius; posY++)
                    {
                        if (World.Instance.BasicFluid)
                        {
                            //Add fluid to the block if it is in bounds and isn't a solid block
                            if (InBounds(x, y) && !FluidDynamics.Instance.GetFluidBlock(posX, posY).IsSolid())
                            {
                                FluidDynamics.Instance.GetFluidBlock(posX, posY).AddWeight(amount);
                                FluidDynamics.Instance.UpdateFluid();
                            }
                        } else
                        {
                            //Add fluid to the block if it is in bounds and isn't a solid block
                            AdvancedFluidBlock currFluidBlock = AdvancedFluidDynamics.Instance.GetFluidBlock(posX, posY);
                            if (InBounds(x, y) && !currFluidBlock.IsSolid() && (currFluidBlock.Weight == 0 || currFluidBlock.Density == density))
                            {
                                AdvancedFluidDynamics.Instance.GetFluidBlock(posX, posY).AddWeight(density, amount, color);
                                AdvancedFluidDynamics.Instance.UpdateFluid();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes fluid from a specific location
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="radius">How many surround blocks to remove fluid</param>
        public static void RemoveFluid(int x, int y, int radius = 0)
        {
            if (!World.Instance.FluidDisabled)
            {
                for (int posX = x - radius; posX <= x + radius; posX++)
                {
                    for (int posY = y - radius; posY <= y + radius; posY++)
                    {
                        if (World.Instance.BasicFluid)
                        {
                            //Remove fluid from a block as long as it is in bounds and isn't solid
                            if (InBounds(x, y) && !FluidDynamics.Instance.GetFluidBlock(posX, posY).IsSolid())
                            {
                                FluidDynamics.Instance.GetFluidBlock(posX, posY).SetEmpty();
                                FluidDynamics.Instance.UpdateFluid();
                            }
                        } else
                        {
                            //Remove fluid from a block as long as it is in bounds and isn't solid
                            if (InBounds(x, y) && !AdvancedFluidDynamics.Instance.GetFluidBlock(posX, posY).IsSolid())
                            {
                                AdvancedFluidDynamics.Instance.GetFluidBlock(posX, posY).SetEmpty();
                                AdvancedFluidDynamics.Instance.UpdateFluid();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the block at a specific location of a specific layer
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="replace">Whether to replace the current block</param>
        /// <param name="layer">Layer to modify</param>
        /// <param name="blockType">Block type to place</param>
        /// <param name="radius">Radius making up the area in which blocks will be placed</param>
        public static void SetBlock(int x, int y, bool replace, byte layer, byte blockType, int radius = 0)
        {
            for (int posX = x - radius; posX <= x + radius; posX++)
            {
                for (int posY = y - radius; posY <= y + radius; posY++)
                {
                    //Determines if there is a block at the current position
                    bool isBlock = World.Instance.GetBlockLayer(layer).IsBlockAt(posX, posY);
                    //Set the block at the current position if it is replacing the current block or if there is no block there
                    if (!isBlock || isBlock && replace)
                        World.Instance.AddBlock(posX, posY, blockType, layer);
                }
            }
        }

        /// <summary>
        /// Removes blocks from a specified location in specified layers
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="layers">Layers to remove blocks from</param>
        /// <param name="radius">How many surrounding blocks to remove</param>
        public static void RemoveBlock(int x, int y, List<byte> layers, int radius = 0)
        {
            for (int posX = x - radius; posX <= x + radius; posX++)
            {
                for (int posY = y - radius; posY <= y + radius; posY++)
                {
                    //Loops through all the layers
                    foreach (byte layer in layers)
                    {
						if (layer == 0) {
							//Removes block from layer if there is one
							if (World.Instance.GetBlockLayer(layer).IsBlockAt(posX, posY)) {
								UnityEngine.Debug.Log(health);
								UnityEngine.Debug.Log(brokenBlockId);
								if ((int)World.Instance.GetBlockLayer(layer).GetBlockType(posX, posY) != brokenBlockId) {
									health = 220;
									brokenBlockId = (int)World.Instance.GetBlockLayer(layer).GetBlockType(posX, posY);
									alreadyBroken = true;
								}
								else if ((int)World.Instance.GetBlockLayer(layer).GetBlockType(posX, posY) == brokenBlockId && alreadyBroken == true) {
									health -= Player.Instance.damage;
									if (health <= 0) {
										dropItem = GameObject.Find("Player").GetComponent<DropedItem>();
										dropItem.DropItem(World.Instance.GetBlockLayer(layer).GetBlockType(posX, posY), posX, posY);
										Debug.Log(World.Instance.GetBlockLayer(layer).GetBlockType(posX, posY));
										World.Instance.RemoveBlock(posX, posY, layer);
										alreadyBroken = false;
										brokenBlockId = 0;
									}
								}
							}
						} else if (layer == 1) {
							if (World.Instance.GetBlockLayer(layer).IsBlockAt(posX, posY)) {
								dropItem = GameObject.Find("Player").GetComponent<DropedItem>();
								dropItem.DropBackgroundItem(World.Instance.GetBlockLayer(layer).GetBlockType(posX, posY), posX, posY);
								World.Instance.RemoveBlock(posX, posY, layer);
							}
						}
                    }
                }
            }
        }

        /// <summary>
        /// Check if a specific coordinate is within World.Instance bounds
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Returns true if that position is within bounds</returns>
        static bool InBounds(int x, int y)
        {
            if (x < 0 || x >= World.Instance.WorldWidth || y < 0 || y >= World.Instance.WorldHeight)
                return false;
            return true;
        }
    }
}