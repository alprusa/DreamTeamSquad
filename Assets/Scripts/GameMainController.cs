using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainController : Controller {
	private int counter=0;
	public GameObject Shop;
	public Text custom;
	
	public void Shopping() {
		Shop.SetActive (true);
		custom.text = "Exit";
			if (counter > 1) {
				custom.text = "Customize";
				Shop.SetActive (false);
				counter = 0;
			}
		counter++;

	}

}