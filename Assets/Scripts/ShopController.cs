using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ShopController : Controller {
	public AppleController AppleController;
	public BuildSlotsController BuildSlotsController;
	public SpeechBubble SpeechBubble;
	public Text back;
	protected override void Start() {
		
	}

	public void ChooseDecoration(DecorationModel decorationModel) {

		if (PlayerData.currency >= decorationModel.cost) {			
			PlayerData.currency -= decorationModel.cost;
			SpeechBubble.SetText ("You have " + PlayerData.currency + " apple bits left!");
			BuildSlotsController.PrepareSlotsForPlacement(decorationModel);
			Show (false);
			AppleController.Shopping();

		}

	}
	
	public void RemoveDecoration() {
		if (back.text == "Remove") {
			BuildSlotsController.PrepareSlotsForRemoval ();
			Show (false);
			AppleController.Shopping ();
			back.text = "Go Back";
		}
	}
}