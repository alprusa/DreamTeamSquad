using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class apple : MonoBehaviour {
	public Sprite saveimage; 
	public Button[] buttonarray = new Button[4];
	public bool removeit = false;
	public void imageplace(){
		for (int i = 0; i < buttonarray.Length; i++) {
			buttonarray[i].image.enabled = true;
			buttonarray[i].GetComponent<Button> ().enabled = true;
		}
	}
	public void setimage(Button b){
		
			b.GetComponent<Image> ().sprite = saveimage;

			}

	public void imagedisable(){
		for (int i = 0; i < buttonarray.Length; i++) {
			//Debug.Log (buttonarray [i].GetComponent<Image> ().sprite );

			if (buttonarray [i].GetComponent<Image> ().sprite == null) {
				buttonarray [i].image.enabled = false;
			} 
			buttonarray [i].GetComponent<Button> ().enabled = false;

		}
		saveimage = null;
	}
	public void removeimage(Button b){
		if (!removeit) {
			b.GetComponent<Image> ().sprite = null;
		}
	}

}
