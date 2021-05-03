using UnityEngine;

// Copyright (C) 2018 Matthew K Wilson

namespace TerrainEngine2D.SideScrollerDemo
{
    /// <summary>
    /// A parallaxing background
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ParallaxBackground : MonoBehaviour
    {
        [HideInInspector]
        public ParallaxBackground leftBackground;
        [HideInInspector]
        public ParallaxBackground rightBackground;

        private SpriteRenderer spriteRenderer;
        public SpriteRenderer SpriteRenderer
        {
            get { return spriteRenderer; }
        }

        public Sprite forestBack;
        public Sprite desertBack;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            this.GetComponent<SpriteRenderer>().sprite = forestBack;
        }
    }
}