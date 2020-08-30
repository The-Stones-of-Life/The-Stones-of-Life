using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSave : MonoBehaviour
{
    void Update()
    {
        ES3.Save("myKey", "save.es3");
    }
}
