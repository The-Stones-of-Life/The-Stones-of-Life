using Tsol.ModLoader;
using UnityEngine;

public class ModLoaderSetup : MonoBehaviour
{
    void Start()
    {
        ModTSOL.Instance.ModLoad();
    }

    void Update()
    {
        ModTSOL.Instance.GameUpdate();
    }
}
