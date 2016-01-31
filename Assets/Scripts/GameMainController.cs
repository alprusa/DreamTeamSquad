using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainController : Controller {
	public SpeechBubble SpeechBubble;
	
	public void InitWithPlayer() {
		SpeechBubble.SetText ("Good morning, " + PlayerData.name + "!");
	}
}