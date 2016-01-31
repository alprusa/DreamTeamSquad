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
	
	void Update() {
		float elapsedTime = Time.deltaTime / 3600f;;
		PlayerData.hours += elapsedTime;
		string speechText = "You have " + PlayerData.currency + " apple bits left!\n";
		if(PlayerData.checkedIn)
			speechText += "You are checked in with time: " + GetTimeStr(PlayerData.hours) + ".";
		else
			speechText += "You are checked out.";
			
		SpeechBubble.SetText(speechText);
	}

	public void ChooseDecoration(DecorationModel decorationModel) {

		if (PlayerData.currency >= decorationModel.cost) {			
			PlayerData.currency -= decorationModel.cost;
				
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
	
	private string GetTimeStr(float time) {
		TimeSpan t = TimeSpan.FromHours( time );
		
		string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
		                              t.Hours, 
		                              t.Minutes, 
		                              t.Seconds);
		return answer;
	}
}