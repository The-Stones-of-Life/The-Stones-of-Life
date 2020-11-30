﻿using System;
using UnityEngine;

// Copyright (C) 2020 Matthew K Wilson

namespace TerrainEngine2D
{
    /// <summary>
    /// Fluid Data to be saved to file
    /// </summary>
    [Serializable]
    public class FluidData : SaveData
    {
        [SerializeField]
        private float[,] fluidWeight;
        /// <summary>
        /// Storage for all the fluid weight data
        /// </summary>
        public float[,] FluidWeight
        {
            get { return fluidWeight; }
        }

        public FluidData(FluidDynamics fluidDynamics) : base()
        {
            fluidWeight = new float[worldData.WorldWidth, worldData.WorldHeight];
            for (int x = 0; x < fluidDynamics.FluidBlocks.GetLength(0); x++)
            {
                for (int y = 0; y < fluidDynamics.FluidBlocks.GetLength(1); y++)
                {
                    fluidWeight[x, y] = fluidDynamics.FluidBlocks[x, y].Weight;
                }
            }
        }
    }
}