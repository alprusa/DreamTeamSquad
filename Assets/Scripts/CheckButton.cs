using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckButton : MonoBehaviour {
	public GameMainController GameMainController;
	public SpeechBubble SpeechBubble;
	public Image CheckImage;
	public Text CheckText;
	
	public void Check() {
		PlayerData.currency += 5;
		SpeechBubble.SetText("Congratulations! You just earned 5 apple bits!");
		
		Toggle();
	}

	public void Toggle() {
		GameMainController.TogglePlayerCheckedIn();
		SetButton();
	}
	
	public void SetButton() {
		if(!PlayerData.checkedIn) {
			CheckImage.color = Color.green;
			CheckText.text = "Check In";
		} else {
			CheckImage.color = Color.red;
			CheckText.text = "Check Out";
		}
	}
}
