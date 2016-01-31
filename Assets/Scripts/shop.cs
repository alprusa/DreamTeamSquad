using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class shop : MonoBehaviour {
	//public Button b1, b2, b3, b4;
	//private Button storebutton;
	public GameObject apple;
	public wage usercurrency;

	public void chosenimage(Button b){
		int temp = int.Parse (b.GetComponentInChildren<Text>().text);
		if (usercurrency.currency >= temp) {
			usercurrency.currency -= temp;
			apple.GetComponent<apple> ().saveimage = b.GetComponent<Image> ().sprite;
			gameObject.SetActive (false);
		}

	}
	public void removeimage(){
		apple.GetComponent<apple> ().saveimage = null;
		gameObject.SetActive (false);
	}
}
