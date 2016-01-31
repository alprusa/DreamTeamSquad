using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shop : MonoBehaviour {
	//public Button b1, b2, b3, b4;
	//private Button storebutton;
	public GameObject apple;

	public void chosenimage(Button b){
		apple.GetComponent<apple> ().saveimage = b.GetComponent<Image> ().sprite;
		gameObject.SetActive (false);
	}
	public void removeimage(){
		apple.GetComponent<apple> ().saveimage = null;
		gameObject.SetActive (false);
	}
}
