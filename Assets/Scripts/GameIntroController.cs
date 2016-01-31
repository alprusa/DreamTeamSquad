using UnityEngine;
using System.Collections;

public class GameIntroController : Controller {
	public GameStateController GameStateController;
	public Controller FirstTimePromptController;
	public FirstTimeController FirstTimeController;
	public SpeechBubble SpeechBubble;
	
	protected override void Start() {
		FirstTimePromptController.Show (true);
		ShowFirstTime(false);
	}
	
	public void ShowFirstTime(bool flag) {
		if(flag)
			SpeechBubble.SetText("Tell us your name!");
		FirstTimePromptController.Show (!flag);
		FirstTimeController.Show(flag);
	}
	
	public void OnFinishFirstTime() {
		GameStateController.OnIntroTransition();
	}
}