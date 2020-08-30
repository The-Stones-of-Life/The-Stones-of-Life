using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingMerchantShop : MonoBehaviour
{

    public Inventory2 inv;    

    public GameObject shopMenu;
    public bool shopOpen = false;


    void Start() {

		inv = GameObject.Find("Inventory").GetComponent<Inventory2>();
		shopMenu = GameObject.Find("TravelingMerchantShop");

    }


    void Update()
    {
	if (Input.GetKeyDown(KeyCode.Escape) && shopOpen == true) {

		shopMenu.SetActive(false);
		shopOpen = false;

	}   
    }

    void OnTriggerStay2D(Collider2D coll) {

	if (coll.gameObject.tag == "Player" && shopOpen == false) {
		if (Input.GetKeyDown(KeyCode.O)) {
			shopMenu.SetActive(true);
			shopOpen = true;
		}
	}

     }

     public void BuyAnvil() {
	if (Currency.money >= 50) {

		Currency.money -= 50;
		inv.anvil += 1;

	}
     }
}
