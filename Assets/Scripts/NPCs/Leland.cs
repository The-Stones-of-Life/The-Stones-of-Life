using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leland : MonoBehaviour
{
   
    public bool isTalking = false;
    public int talkTime = 0;

    public string name = "Leland";

    public int health = 5000;

    public string dialog1 = "Leland: How do you like my hair?";
    public string dialog2 = "Leland: Where am I?";
    public string dialog3 = "Leland: I like to make things in my free time.";

    public GameObject dialogObject;
    public Text dialogBox;


    void Update()
    {
	if (isTalking == true) {
		talkTime += 1;
	}  
	else {
		talkTime = 0;
	}

	if (isTalking == true) {
		dialogObject.SetActive(true);
	}
	else {
		dialogObject.SetActive(false);
	}

	if (talkTime >= 30) {
		isTalking = false;
	}
    }

    void OnTriggerStay2D(Collider2D coll) {

	if (coll.gameObject.tag == "Player") {
		if (Input.GetKeyDown(KeyCode.O)) {
			if (Random.Range(1, 4) == 1) {
				isTalking = true;
				dialogBox.text = dialog1;
			}

			if (Random.Range(1, 4) == 2) {
				isTalking = true;
				dialogBox.text = dialog2;
			}

			if (Random.Range(1, 4) == 3) {
				isTalking = true;
				dialogBox.text = dialog3;
			}
		}	
	}

    }
}
