using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int ht = 0;
    public int ct = 0;
    public int lt = 0;
    public int bt = 0;
    public int td;

    public Text htv;
    public Text ctv;
    public Text ltv;
    public Text btv;
    public Text tdtv;

    public static PlayerStatus Instance;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {

        td = (ht + ct + lt + bt) * 2;

        tdtv.text = td.ToString();

        htv.text = ht.ToString();
        ctv.text = ct.ToString();
        ltv.text = lt.ToString();
        btv.text = bt.ToString();
    }
}
