using UnityEngine;
// Copyright (C) 2018 Matthew K Wilson

namespace TerrainEngine2D.Demo
{
    //Layer types
    public enum Layers { Background, Trees, Decoration, Main, Ore, Foreground }
    //Block types
    public enum BackgroundLayer { Dirt, Stone, Wood }
    public enum TreesLayer { Stump, Branch, Trunk, Head }
    public enum DecorationLayer { LeftChair, Table, RightChair }
    public enum MainLayer { Wood, Dirt, HardDirt, Rock, BedRock, Sand }
    public enum OreLayer { Gems, Coal, Silver }
    public enum ForegroundLayer { Grass, Flower, VineEnd, VineMiddle, VineStart }

    public class OriginalTerrainGenerator : TerrainGenerator
    {
        /// <summary>
        /// Procedurally generates world block data using random and pseudo-random functions
        /// </summary>
        public override void GenerateData()
        {
            base.GenerateData();

            //Pass 1
            for (int x = 0; x < world.WorldWidth; x++)
            {
                //-----Add height variables here-----
                int groundLevel = PerlinNoise(x, 0, 75, 20, 1);
                groundLevel += PerlinNoise(x, 0, 45, 30, 1);
                groundLevel += PerlinNoise(x, 0, 8, 8, 1);
                groundLevel += 60;

                int stoneLevel = PerlinNoise(x, 0, 70, 20, 1);
                stoneLevel += PerlinNoise(x, 0, 40, 35, 1);
                stoneLevel += 50;
                //----------
                for (int y = 0; y < world.WorldHeight; y++)
                {
                    //-----Set block data here-----
                    if (y <= groundLevel)
                    {
                        //Start with a layer of dirt covering the whole ground level
                        SetBlock(x, y, (byte)Layers.Background, (byte)BackgroundLayer.Dirt);
                        SetBlock(x, y, (byte)Layers.Main, (byte)MainLayer.Dirt);
                        //Cover the background with stone if below the stone level
                        if (y <= stoneLevel)
                            SetBlock(x, y, (byte)Layers.Background, (byte)BackgroundLayer.Stone);
                        //Set blocks below a random level (5 to 19 blocks below ground level) to rock/hard dirt and add ore
                        if (y < groundLevel - random.Next(5, 20))
                        {
                            //Place large rock chunks in pseudo random positions and add clumps of ore
                            if (PerlinNoise(x * 4, y, 5, 6, 1) > 1)
                            {
                                SetBlock(x, y, (byte)Layers.Main, (byte)MainLayer.Rock);
                                //Place ore in pseudo-random positions in rocks
                                if (PerlinNoise(x, y * 2, 9, 12, 1) > 8)
                                    SetBlock(x, y, (byte)Layers.Ore, (byte)OreLayer.Coal);
                                if (PerlinNoise(x, y * 2, 10, 12, 1) > 8)
                                    SetBlock(x, y, (byte)Layers.Ore, (byte)OreLayer.Silver);
                                //Place gems randomly in rocks (about 1% chance to place a gem)
                                SetBlock(x, y, (byte)Layers.Ore, (byte)OreLayer.Gems, 1);
                            }
                            //Add hard dirt clumps in pseudo random positions
                            if (PerlinNoise(x, y, 15, 16, 1) > 8)
                            {
                                SetBlock(x, y, (byte)Layers.Main, (byte)MainLayer.HardDirt);
                                RemoveBlock(x, y, (byte)Layers.Ore);
                            }
                        }
                        //Remove clumps of main and ore to create caves
                        if (PerlinNoise(x, y, 10, 10, 1) > 5)
                        {
                            RemoveBlock(x, y, (byte)Layers.Main);
                            RemoveBlock(x, y, (byte)Layers.Ore);
                        }

                        //Add bedrock to the bottom of the world
                        if (y < PerlinNoise(x, y, 13, 16, 1) + 3)
                        {
                            SetBlock(x, y, (byte)Layers.Main, (byte)MainLayer.BedRock);
                            RemoveBlock(x, y, (byte)Layers.Ore);
                        }

                        //Add foreground elements and trees to the top of the ground level if there is a main block there
                        if (y == groundLevel && IsBlockAt(x, y, (byte)Layers.Main))
                        {
                            //Add grass with a 25% probability 
                            SetBlock(x, y + 1, (byte)Layers.Foreground, (byte)ForegroundLayer.Grass, 25);
                            //Add flowers with a 25% probability
                            SetBlock(x, y + 1, (byte)Layers.Foreground, (byte)ForegroundLayer.Flower, 25);

                            //Places a tree with 10% probability
                            if (DoAddBlock(10))
                            {
                                bool genTree = true;
                                //Check for enough room to place a stump
                                if (IsBlockAt(x - 1, y + 1, (byte)Layers.Main))
                                    genTree = false;
                                //Check for a tree within 6 blocks away
                                for (int xTree = x - 6; xTree < x; xTree++)
                                {
                                    //Check for blocks of trees at a few different vertical positions (since tree sizes and positions vary)
                                    if (IsBlockAt(xTree, y + 2, (byte)Layers.Trees) || IsBlockAt(xTree, y + 5, (byte)Layers.Trees) || IsBlockAt(xTree, y + 8, (byte)Layers.Trees))
                                    {
                                        genTree = false;
                                        break;
                                    }
                                }
                                //Generate a tree if there are none nearby
                                if (genTree)
                                {
                                    //Set stump at a horizontal offset since it is 3 blocks wide
                                    SetBlock(x - 1, y + 1, (byte)Layers.Trees, (byte)TreesLayer.Stump);
                                    //Randomly generate a tree height between 5 and 12 blocks high
                                    int treeHeight = random.Next(6, 12);
                                    //Loop up the height of the tree
                                    for (int yTree = y + 2; yTree < y + treeHeight; yTree++)
                                    {
                                        SetBlock(x, yTree, (byte)Layers.Trees, (byte)TreesLayer.Trunk);
                                        //Place a branch if positioned at approximately 70% of the trees height
                                        if (yTree == y + Mathf.RoundToInt(treeHeight * 0.7f))
                                            SetBlock(x - 3, yTree, (byte)Layers.Trees, (byte)TreesLayer.Branch);
                                    }
                                    //Finish the tree with the head 
                                    SetBlock(x - 3, y + treeHeight, (byte)Layers.Trees, (byte)TreesLayer.Head);
                                }
                            }
                        }
                    }
                }
            }

            //Pass 2...
            for (int x = 0; x < world.WorldWidth; x++)
            {
                //-----Add height variables here-----
                int groundHeight = PerlinNoise(x, 0, 80, 15, 1);
                groundHeight += PerlinNoise(x, 0, 50, 30, 1);
                groundHeight += PerlinNoise(x, 0, 10, 10, 1);
                groundHeight += 60;
                //----------
                for (int y = 0; y < world.WorldHeight; y++)
                {
                    //-----Set block data here-----
                    if (y < groundHeight)
                    {
                        //Add water to caves
                        if (!IsBlockAt(x, y, world.FluidLayer))
                        {
                            //Generate a pool of water with 0.5% probability
                            if (DoAddBlock(0.5f))
                                GeneratePool(x, y, fluidDynamics.MaxWeight, y, new Vector2Int(x, y));
                        }
                    }
                    //Place a vine if there is no main block at this positon, but there is one above it at a 10% probability
                    if (DoAddBlock(10) && !IsBlockAt(x, y, (byte)Layers.Main) && IsBlockAt(x, y + 1, (byte)Layers.Main))
                    {
                        SetBlock(x, y, (byte)Layers.Foreground, (byte)ForegroundLayer.VineStart);
                        //Generate the length of the vine (between 2 to 6 blocks
                        int vineBottom = y - random.Next(2, 6);
                        //Loop down the length of the vine
                        for (int yVine = y - 1; yVine > vineBottom; yVine--)
                        {
                            //Place middle vine blocks unless it reaches a main block
                            if (!IsBlockAt(x, yVine, (byte)Layers.Main))
                                SetBlock(x, yVine, (byte)Layers.Foreground, (byte)ForegroundLayer.VineMiddle);
                            else
                                break;
                        }
                        //As long as there is no main block at the bottom of the vine, place the end vine block
                        if (!IsBlockAt(x, vineBottom, (byte)Layers.Main))
                            SetBlock(x, vineBottom, (byte)Layers.Foreground, (byte)ForegroundLayer.VineEnd);
                    }
                    //----------
                }
            }
        }
    }
}