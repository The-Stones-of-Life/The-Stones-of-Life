using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	public Hotbar hb;
	
	public Transform itemSlotContainer;
	public Transform itemSlotTemplate;
	public Transform itemSlotTemplateInst;
	
	void Awake() {
		hb = GameObject.Find("Hotbar").GetComponent<Hotbar>();
		itemSlotContainer = GameObject.Find("Container").GetComponent<Transform>();
		itemSlotTemplate = itemSlotContainer.Find("Slot");

	}
	
	void Update() {
		
		itemSlotTemplateInst = itemSlotContainer.Find("Slot(Clone)");
		
	}
	
	public void SetInventory(Hotbar hb) {
		this.hb = hb;
		
		RefreshInventoryItems();
	}
	
	public void RefreshInventoryItems() {
		
		foreach (Transform child in itemSlotContainer) {
			if (child == itemSlotTemplateInst) continue;
			Destroy(child.gameObject);
		}
		
		int x = 0;
		int y = 0;
		float itemSlotCellSize = 60f;
		foreach (Item item in hb.GetItemList()) {
			
			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
			
			Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
			image.sprite = item.GetSprite();
			
			Text text = itemSlotRectTransform.Find("text").GetComponent<Text>();
			if (item.ammount > 1) {
				text.text = item.ammount.ToString();
			}
			else {
				text.text = "";
			}
			
			x++;
			if (x > 7) {
				x = 0;
				y++;
			}
			
		}
	}
}
