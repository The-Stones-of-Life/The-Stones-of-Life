using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TerrainEngine2D.Lighting;

// Copyright (C) 2018 Matthew K Wilson

namespace TerrainEngine2D
{
    /// <summary>
    /// Example**
    /// Handles input for the World Modifier
    /// </summary>
    public class WorldInputHandlerMultiplayer : MonoBehaviourSingleton<WorldInputHandlerMultiplayer>
    {
        private World world;
        private WorldMultiplayer worldMultiplayer;
        private FluidDynamics fluidDynamics;
        private AdvancedFluidDynamics advancedFluidDynamics;
        private AdvancedLightSystem advancedLightSystem;

        [SerializeField]
        [Tooltip("A prefab of a GameObject with a LightSource Component")]
        private GameObject lightPrefab;
        [SerializeField]
        [Tooltip("The Z position for the light on instantiation")]
        private float lightZPosition;
        /// <summary>
        /// The manually set Z position for a placed light object
        /// </summary>
        public float LightZPosition
        {
            get { return lightZPosition; }
        }
        [SerializeField]
        [Tooltip("The LayerMask used to determine if a collider block can be placed (checks for any other 2d colliders that are not terrain)")]
        private LayerMask colliderMask;
        //The light source attached to the light prefab
        private LightSource prefabLightSource;

        private bool isBuilding;
        /// <summary>
        /// Whether terrain will be built on click
        /// If this is false, terrain will be destroyed on click
        /// </summary>
        public bool IsBuilding
        {
            get { return isBuilding; }
            set { isBuilding = value; }
        }
        private byte selectedBlock;
        /// <summary>
        /// Current selected block of the current selected layer (used when building)
        /// </summary>
        public byte SelectedBlock
        {
            get { return selectedBlock; }
            set { selectedBlock = value; }
        }
        private List<byte> selectedLayers;
        /// <summary>
        /// The current selected BlockLayers
        /// </summary>
        public List<byte> SelectedLayers
        {
            get { return selectedLayers; }
        }
        private int modifyRadius;
        /// <summary>
        /// The radius for modifying blocks
        /// </summary>
        public int ModifyRadius
        {
            get { return modifyRadius; }
            set { modifyRadius = value; }
        }
        private int xGridPosition;
        /// <summary>
        /// X position of the cursor in grid coordinates
        /// </summary>
        public int XGridPosition
        {
            get { return xGridPosition; }
        }
        private int yGridPosition;
        /// <summary>
        /// Y position of the cursor in grid coordinates
        /// </summary>
        public int YGridPosition
        {
            get { return yGridPosition; }
        }
        private OSDController.Tool selectedTool;
        /// <summary>
        /// The tool selected in the OSD for modifying the world
        /// </summary>
        public OSDController.Tool SelectedTool
        {
            get { return selectedTool; }
            set { selectedTool = value; }
        }
        private Color32 fluidColor = new Color32(0, 80, 200, 225);
        /// <summary>
        /// The color to set placed fluid (Advanced Fluid System)
        /// </summary>
        public Color32 FluidColor
        {
            get { return fluidColor; }
            set { fluidColor = value; }
        }
        private byte fluidDensity;
        /// <summary>
        /// The density to set the placed fluid (Advanced Fluid System)
        /// </summary>
        public byte FluidDensity
        {
            get { return fluidDensity; }
            set { fluidDensity = value; }
        }

        private bool initialized;
		
		public enum Layers { Main }




        public GameObject torch;



        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            prefabLightSource = lightPrefab.GetComponent<LightSource>();
            if (prefabLightSource == null)
            {
                prefabLightSource = lightPrefab.GetComponentInChildren<LightSource>();
                if(prefabLightSource == null)
                    throw new MissingComponentException("The Light Source Prefab is missing a LightSource component.");
            }
            if (!initialized)
            {
                if (GameObject.Find("NetworkManager") != null)
                {
                    InitializeMultiplayer();
                } else {
                    Initialize();
                }
            }
        }

        /// <summary>
        /// Setup the WorldInputHandler
        /// </summary>
        public void Initialize()
        {
            world = World.Instance;
            fluidDynamics = FluidDynamics.Instance;
            advancedFluidDynamics = AdvancedFluidDynamics.Instance;
            advancedLightSystem = AdvancedLightSystem.Instance;
            selectedLayers = new List<byte>(world.NumBlockLayers);
            selectedLayers.Add(0);
			selectedLayers.Add(1);
            isBuilding = false;
            initialized = true;
        }

        public void InitializeMultiplayer()
        {
            worldMultiplayer = WorldMultiplayer.Instance;
            fluidDynamics = FluidDynamics.Instance;
            advancedFluidDynamics = AdvancedFluidDynamics.Instance;
            advancedLightSystem = AdvancedLightSystem.Instance;
            selectedLayers = new List<byte>(worldMultiplayer.NumBlockLayers);
            selectedLayers.Add(0);
            selectedLayers.Add(1);
            isBuilding = false;
            initialized = true;
        }

        private void Update()
        {

            if (GameObject.Find("NetworkManager") != null)
            {
                //Save the position of the mouse in grid coordinates
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                xGridPosition = Mathf.FloorToInt(mousePosition.x);
                yGridPosition = Mathf.FloorToInt(mousePosition.y);

                //Pressing the Left Mouse Button
                if (Input.GetMouseButton(0))
                {
                    //Check if input should be handled
                    if (DoNotHandleInput())
                        return;
                    switch (selectedTool)
                    {
                        case OSDController.Tool.Terrain:
                            //Place blocks if building is toggled, else destroy blocks at the mouse position
                            if (isBuilding)
                            {
                                //If this is a collider layer, check to make sure you aren't placing a block on another collider
                                if (worldMultiplayer.GetBlockLayer(selectedLayers[0]).ColliderLayer)
                                {
                                    RaycastHit2D hit = Physics2D.BoxCast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), new Vector2(modifyRadius * 2 + 1 - 0.1f, modifyRadius * 2 + 1 - 0.1f), 0, Vector2.zero, 1, colliderMask);
                                    if (hit.collider == null)
                                        WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, selectedLayers[0], selectedBlock, modifyRadius);
                                }
                                else
                                    WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, selectedLayers[0], selectedBlock, modifyRadius);
                            }
                            else
                            {
                                WorldModifierMultiplayer.RemoveBlock(xGridPosition, yGridPosition, selectedLayers, modifyRadius);
                            }
                            break;
                        case OSDController.Tool.Fluid:
                            if (isBuilding)
                            {
                                if (worldMultiplayer.BasicFluid)
                                    WorldModifierMultiplayer.PlaceFluid(xGridPosition, yGridPosition, fluidDynamics.FluidDropAmount, modifyRadius);
                                else
                                    WorldModifierMultiplayer.PlaceFluid(xGridPosition, yGridPosition, advancedFluidDynamics.FluidDropAmount, modifyRadius, fluidDensity, fluidColor);
                            }
                            else
                                WorldModifierMultiplayer.RemoveFluid(xGridPosition, yGridPosition, modifyRadius);
                            break;
                        case OSDController.Tool.Light:
                            if (worldMultiplayer.BasicLighting)
                                return;

                            if (Input.GetMouseButtonDown(0))
                            {
                                if (isBuilding)
                                {
                                    RaycastHit2D hit = Physics2D.Raycast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), Vector2.zero);
                                    if (hit.collider == null && worldMultiplayer.GetBlockLayer(0).IsBlockAt(xGridPosition, yGridPosition) && !advancedLightSystem.IsLightAt(new Vector2Int(XGridPosition, yGridPosition)))
                                    {
                                        if (!(prefabLightSource is BlockLightSource) || !AdvancedLightSystem.Instance.IsLightAt(new Vector2Int(xGridPosition, yGridPosition)))
                                            Instantiate(lightPrefab, new Vector3(xGridPosition, yGridPosition, lightZPosition), new Quaternion(0, 0, 0, 0));
                                    }
                                }
                                else
                                {
                                    LightSource lightSource;
                                    if (advancedLightSystem.TryGetLight(new Vector2Int(xGridPosition, yGridPosition), out lightSource))
                                        Destroy(lightSource.transform.parent.gameObject);
                                }
                            }
                            break;
                    }
                }
                //Pressing the Right Mouse Button
                else if (Input.GetMouseButton(1))
                {
                    if ((int)worldMultiplayer.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 0)
                    {
                        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), new Vector2(modifyRadius * 2 + 1 - 0.1f, modifyRadius * 2 + 1 - 0.1f), 0, Vector2.zero, 1, colliderMask);
                        if (PlayerMultiplayer.selectedBlockId == 1 && Inventory.grassBlocks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)1);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Grass, amount = 1 });
                            Inventory.grassBlocks -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 2 && Inventory.dirtBlocks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)2);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Dirt, amount = 1 });
                            Inventory.dirtBlocks -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 3 && Inventory.stoneBlocks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)3);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 1 });
                            Inventory.stoneBlocks -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 4 && Inventory.logs >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)4);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Log, amount = 1 });
                            Inventory.logs -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 5 && Inventory.leaves >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)5);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Leaves, amount = 1 });
                            Inventory.leaves -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 6 && Inventory.planks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)6);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Planks, amount = 1 });
                            Inventory.planks -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 7 && Inventory.workbench >= 1)
                        {
                            Debug.Log(PlayerMultiplayer.selectedBlockId);
                            Debug.Log(Inventory.workbench);
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)7);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
                            Inventory.workbench -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 8 && Inventory.ironOre >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)8);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronOre, amount = 1 });
                            Inventory.ironOre -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 9 && Inventory.furnace >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)9);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Furnace, amount = 1 });
                            Inventory.furnace -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 10 && Inventory.furnace >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)10);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Coal, amount = 1 });
                            Inventory.coal -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 11 && Inventory.anvil >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)11);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Anvil, amount = 1 });
                            Inventory.anvil -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 12 && Inventory.torch >= 1)
                        {
                            Instantiate(torch, new Vector2(xGridPosition, yGridPosition), Quaternion.identity);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Torch, amount = 1 });
                            Inventory.torch -= 1;
                            return;
                        }
                        if (PlayerMultiplayer.selectedBlockId == 13 && Inventory.sand >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)12);
                            PlayerMultiplayer.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sand, amount = 1 });
                            Inventory.sand -= 1;
                            return;
                        }
                        return;
                    }

                    if (worldMultiplayer.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 7)
                    {
                        UIManager.Instance.workbenchUI.SetActive(true);
                    }

                    if (worldMultiplayer.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 9)
                    {
                        UIManager.Instance.furnaceUI.SetActive(true);
                    }

                    if (worldMultiplayer.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 11)
                    {
                        UIManager.Instance.anvilUI.SetActive(true);
                    }
                }
            } else
            {
                //Save the position of the mouse in grid coordinates
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                xGridPosition = Mathf.FloorToInt(mousePosition.x);
                yGridPosition = Mathf.FloorToInt(mousePosition.y);

                //Pressing the Left Mouse Button
                if (Input.GetMouseButton(0))
                {
                    //Check if input should be handled
                    if (DoNotHandleInput())
                        return;
                    switch (selectedTool)
                    {
                        case OSDController.Tool.Terrain:
                            //Place blocks if building is toggled, else destroy blocks at the mouse position
                            if (isBuilding)
                            {
                                //If this is a collider layer, check to make sure you aren't placing a block on another collider
                                if (world.GetBlockLayer(selectedLayers[0]).ColliderLayer)
                                {
                                    RaycastHit2D hit = Physics2D.BoxCast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), new Vector2(modifyRadius * 2 + 1 - 0.1f, modifyRadius * 2 + 1 - 0.1f), 0, Vector2.zero, 1, colliderMask);
                                    if (hit.collider == null)
                                        WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, selectedLayers[0], selectedBlock, modifyRadius);
                                }
                                else
                                    WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, selectedLayers[0], selectedBlock, modifyRadius);
                            }
                            else
                            {
                                WorldModifierMultiplayer.RemoveBlock(xGridPosition, yGridPosition, selectedLayers, modifyRadius);
                            }
                            break;
                        case OSDController.Tool.Fluid:
                            if (isBuilding)
                            {
                                if (world.BasicFluid)
                                    WorldModifierMultiplayer.PlaceFluid(xGridPosition, yGridPosition, fluidDynamics.FluidDropAmount, modifyRadius);
                                else
                                    WorldModifierMultiplayer.PlaceFluid(xGridPosition, yGridPosition, advancedFluidDynamics.FluidDropAmount, modifyRadius, fluidDensity, fluidColor);
                            }
                            else
                                WorldModifierMultiplayer.RemoveFluid(xGridPosition, yGridPosition, modifyRadius);
                            break;
                        case OSDController.Tool.Light:
                            if (world.BasicLighting)
                                return;

                            if (Input.GetMouseButtonDown(0))
                            {
                                if (isBuilding)
                                {
                                    RaycastHit2D hit = Physics2D.Raycast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), Vector2.zero);
                                    if (hit.collider == null && world.GetBlockLayer(0).IsBlockAt(xGridPosition, yGridPosition) && !advancedLightSystem.IsLightAt(new Vector2Int(XGridPosition, yGridPosition)))
                                    {
                                        if (!(prefabLightSource is BlockLightSource) || !AdvancedLightSystem.Instance.IsLightAt(new Vector2Int(xGridPosition, yGridPosition)))
                                            Instantiate(lightPrefab, new Vector3(xGridPosition, yGridPosition, lightZPosition), new Quaternion(0, 0, 0, 0));
                                    }
                                }
                                else
                                {
                                    LightSource lightSource;
                                    if (advancedLightSystem.TryGetLight(new Vector2Int(xGridPosition, yGridPosition), out lightSource))
                                        Destroy(lightSource.transform.parent.gameObject);
                                }
                            }
                            break;
                    }
                }
                //Pressing the Right Mouse Button
                else if (Input.GetMouseButton(1))
                {
                    if ((int)world.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 0)
                    {
                        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(xGridPosition + 0.5f, yGridPosition + 0.5f), new Vector2(modifyRadius * 2 + 1 - 0.1f, modifyRadius * 2 + 1 - 0.1f), 0, Vector2.zero, 1, colliderMask);
                        if (Player.selectedBlockId == 1 && Inventory.grassBlocks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)1);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Grass, amount = 1 });
                            Inventory.grassBlocks -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 2 && Inventory.dirtBlocks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)2);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Dirt, amount = 1 });
                            Inventory.dirtBlocks -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 3 && Inventory.stoneBlocks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)3);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Stone, amount = 1 });
                            Inventory.stoneBlocks -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 4 && Inventory.logs >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)4);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Log, amount = 1 });
                            Inventory.logs -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 5 && Inventory.leaves >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)5);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Leaves, amount = 1 });
                            Inventory.leaves -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 6 && Inventory.planks >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)6);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Planks, amount = 1 });
                            Inventory.planks -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 7 && Inventory.workbench >= 1)
                        {
                            Debug.Log(Player.selectedBlockId);
                            Debug.Log(Inventory.workbench);
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)7);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Workbench, amount = 1 });
                            Inventory.workbench -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 8 && Inventory.ironOre >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)8);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.IronOre, amount = 1 });
                            Inventory.ironOre -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 9 && Inventory.furnace >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)9);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Furnace, amount = 1 });
                            Inventory.furnace -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 10 && Inventory.furnace >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)10);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Coal, amount = 1 });
                            Inventory.coal -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 11 && Inventory.anvil >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)11);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Anvil, amount = 1 });
                            Inventory.anvil -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 12 && Inventory.torch >= 1)
                        {
                            Instantiate(torch, new Vector2(xGridPosition, yGridPosition), Quaternion.identity);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Torch, amount = 1 });
                            Inventory.torch -= 1;
                            return;
                        }
                        if (Player.selectedBlockId == 13 && Inventory.sand >= 1)
                        {
                            WorldModifierMultiplayer.SetBlock(xGridPosition, yGridPosition, false, (byte)Layers.Main, (byte)12);
                            Player.inventory.RemoveItem(new Item { itemType = Item.ItemType.Sand, amount = 1 });
                            Inventory.sand -= 1;
                            return;
                        }
                        return;
                    }

                    if (world.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 7)
                    {
                        UIManager.Instance.workbenchUI.SetActive(true);
                    }

                    if (world.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 9)
                    {
                        UIManager.Instance.furnaceUI.SetActive(true);
                    }

                    if (world.GetBlockLayer(selectedLayers[0]).GetBlockType(xGridPosition, yGridPosition) == 11)
                    {
                        UIManager.Instance.anvilUI.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// Check if input should not be handled
        /// </summary>
        /// <returns>Returns true if mouse is hovering over UI</returns>
        bool DoNotHandleInput()
        {
            //Check if mouse is hovering over UI
            if (EventSystem.current)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return true;
            }
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                return true;
            return false;
        }

        /// <summary>
        /// Set the current selected layer
        /// </summary>
        /// <param name="layer">Index of the selected layer</param>
        public void SetSelectedLayer(byte layer)
        {
            if (selectedLayers == null)
                return;
            selectedLayers.Clear();
            selectedLayers[0] = layer;
        }
        /// <summary>
        /// Add a layer to the list of selected layers
        /// </summary>
        /// <param name="layer">Index of the layer to be added</param>
        /// <returns>Returns true if the layer was successfully added</returns>
        public bool AddSelectedLayer(byte layer)
        {
            if (selectedLayers == null)
                return false;
            if (selectedLayers.Count < world.NumBlockLayers)
            {
                selectedLayers.Add(layer);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears all the selected layers
        /// </summary>
        public void ClearSelectedLayers()
        {
            if (selectedLayers == null)
                return;
            selectedLayers.Clear();
        }
    }
}
