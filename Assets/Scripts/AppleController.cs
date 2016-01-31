using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AppleController : Controller {
	public SpeechBubble SpeechBubble;
	public ShopController ShopController;
	public Text custom;
	public Text back;
	
	private bool currentShopping = false;
	
	protected override void Start() {
		int currency = PlayerData.currency;
		SpeechBubble.SetText("You have " + currency + " apple bits left!");
	}
	
	public void Shopping() {
		currentShopping = !currentShopping;

		if (currentShopping) {
			back.text = "Remove";
			ShopController.Show(true);
			custom.text = "Exit";
		} else {
			ShopController.Show (false);
			custom.text = "Customize";
			back.text = "Go Back";
		}
	}
	
	public void GoBack() {
		if(back.text == "Go Back")Application.LoadLevel("tempscene");
	}
}