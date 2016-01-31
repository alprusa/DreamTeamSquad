using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AppleController : Controller {
	public SpeechBubble SpeechBubble;
	public ShopController ShopController;
	public Text custom;
	
	private bool currentShopping = false;
	
	protected override void Start() {
		int currency = PlayerData.currency;
		SpeechBubble.SetText("You have " + currency + " apple bits left!");
	}
	
	public void Shopping() {
		currentShopping = !currentShopping;
		if (currentShopping) {
			ShopController.Show(true);
			custom.text = "Exit";
		} else {
			ShopController.Show (false);
			custom.text = "Customize";
		}
	}
	
	public void GoBack() {
		Application.LoadLevel("tempscene");
	}
}