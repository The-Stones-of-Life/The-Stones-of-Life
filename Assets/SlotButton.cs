using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{

    public Button btn;
    public int selectedIndex = 0;
    public Inventory inventory;

    // Start is called before the first frame update
    void Awake()
    {
        btn = this.gameObject.GetComponent<Button>();
    }

    public void SetInventory(Inventory inv)
    {
        this.inventory = inv;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ActivateButton()
    {
        Item item = inventory.GetItemList()[inventory.GetItemList().Count - selectedIndex];
        inventory.UseItem(item);
    }
}
