﻿using System.Collections.Generic;
using UnityEngine;

// Copyright (C) 2020 Matthew K Wilson

namespace TerrainEngine2D.Lighting
{
    /// <summary>
    /// Renders the advanced lighting for Terrain Engine 2D
    /// Attach to a Camera
    /// </summary>
    public class LightRenderer :MonoBehaviourSingleton<LightRenderer>
    {
        private World world;

        [Header("Cameras")]
        /// <summary>
        /// The lighting camera
        /// </summary>
        public Camera LightCamera;
        /// <summary>
        /// The overlay camera; for objects that should render on top of the lighting
        /// </summary>
        public Camera OverlayCamera;

        private RenderTexture lightRenderTexture;
        /// <summary>
        /// The render texture used to capture the light graphics
        /// </summary>
        public RenderTexture LightRenderTexture
        {
            get { return lightRenderTexture; }
        }
        private RenderTexture overlayRenderTexture;
        /// <summary>
        /// The render texture used to capture graphics which overlay the lighting
        /// </summary>
        public RenderTexture OverlayRenderTexture
        {
            get { return overlayRenderTexture; }
        }

        [HideInInspector]
        /// <summary>
        /// The amount to scale down the lighting texture (in powers of 2)
        /// </summary>
        public int DownRes = 1;
        [HideInInspector]
        /// <summary>
        /// The number of times the lighting texture will be blurred
        /// </summary>
        public int NumberBlurPasses = 1;

        //Materials for processing the lights
        [Header("Materials")]
        [SerializeField]
        [Tooltip("The material used to blur the light texture")]
        private Material blurMaterial;
        [SerializeField]
        [Tooltip("The material used to blend the lighting with the rest of the graphics")]
        private Material blendMaterial;
        [SerializeField]
        [Tooltip("The material used to add the overlay graphics to the rest of the graphics")]
        private Material overlayMaterial;

        //The previous screen size
        private int prevScreenWidth;
        private int prevScreenHeight;

        protected override void Awake()
        {
            base.Awake();
            prevScreenWidth = Screen.width;
            prevScreenHeight = Screen.height;
            lightRenderTexture = new RenderTexture(prevScreenWidth, prevScreenHeight, 0);
            overlayRenderTexture = new RenderTexture(prevScreenWidth, prevScreenHeight, 0);
        }

        private void Start()
        {
            world = World.Instance;

            DownRes = World.WorldData.DownRes;
            NumberBlurPasses = World.WorldData.NumberBlurPasses;
            lightRenderTexture.filterMode = FilterMode.Point;
        }

        private void Update()
        {
            if (prevScreenWidth != Screen.width || prevScreenHeight != Screen.height)
                OnScreenResolutionChange();
        }

        private void OnScreenResolutionChange()
        {
            Debug.Log("Screen Resolution changed");
            //Set the new size of the render textures
            prevScreenWidth = Screen.width;
            prevScreenHeight = Screen.height;
            lightRenderTexture = new RenderTexture(prevScreenWidth, prevScreenHeight, 0);
            overlayRenderTexture = new RenderTexture(prevScreenWidth, prevScreenHeight, 0);
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            RenderTexture tempRenderTexture = RenderTexture.GetTemporary(source.width >> DownRes, source.height >> DownRes);
            RenderTexture tempRenderTexture2 = RenderTexture.GetTemporary(source.width, source.height);

            //Render the lighting graphics
            LightCamera.targetTexture = lightRenderTexture;
            LightCamera.Render();
            Graphics.Blit(lightRenderTexture, tempRenderTexture);

            //Blur and down res the lighting graphic to smooth the texture edges
            for (int i = 0; i < NumberBlurPasses; i++)
            {
                RenderTexture tempRenderTexture3 = RenderTexture.GetTemporary(source.width >> DownRes, source.height >> DownRes);

                Graphics.Blit(tempRenderTexture, tempRenderTexture3, blurMaterial);
                RenderTexture.ReleaseTemporary(tempRenderTexture);
                tempRenderTexture = tempRenderTexture3;
            }
            //Copy the source texture into a temporary render texture
            Graphics.Blit(source, tempRenderTexture2);

            //Add the lighting to the texture using a Multiplicative shader
            Graphics.Blit(tempRenderTexture, tempRenderTexture2, blendMaterial);

            //Render the overlay graphics
            OverlayCamera.targetTexture = overlayRenderTexture;
            OverlayCamera.Render();
            //Add the overlay to the texture using the UIOverlay material
            Graphics.Blit(overlayRenderTexture, tempRenderTexture2, overlayMaterial);

            //Copy the new texture to the destination (to be output to the screen)
            Graphics.Blit(tempRenderTexture2, destination);

            RenderTexture.ReleaseTemporary(tempRenderTexture);
            RenderTexture.ReleaseTemporary(tempRenderTexture2);
        }

        /// <summary>
        /// Get the color of the lighting at specific pixel coordinate on the screen
        /// </summary>
        /// <param name="pixelCoordinate">The pixel coordinate on the screen</param>
        /// <returns>Returns the color of the pixel</returns>
        public Color GetLightColor(Vector2Int pixelCoordinate)
        {
            if (world.LightingDisabled || world.BasicLighting)
                return Color.clear;

            if (pixelCoordinate.x <= 1 || pixelCoordinate.y <= 1 || pixelCoordinate.x >= lightRenderTexture.width - 1 || pixelCoordinate.y >= lightRenderTexture.height - 1)
                return Color.clear;

            Texture2D pixelTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
            Rect rect = new Rect(Mathf.FloorToInt(pixelCoordinate.x), Mathf.FloorToInt(lightRenderTexture.height - pixelCoordinate.y), 1, 1);

            RenderTexture prev = RenderTexture.active;
            RenderTexture.active = lightRenderTexture;

            pixelTexture.ReadPixels(rect, 0, 0, false);
            Color lightColor = pixelTexture.GetPixel(0, 0);
            RenderTexture.active = prev;

            return lightColor;
        }
    }
}