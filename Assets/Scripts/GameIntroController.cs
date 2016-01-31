using UnityEngine;
using System.Collections;

public class GameIntroController : Controller {
	public GameStateController GameStateController;
	public Controller FirstTimePromptController;
	public FirstTimeController FirstTimeController;
	
	protected override void Start() {
		FirstTimePromptController.Show (true);
		ShowFirstTime(false);
	}
	
	public void ShowFirstTime(bool flag) {
		FirstTimePromptController.Show (!flag);
		FirstTimeController.Show(flag);
	}
	
	public void OnFinishFirstTime() {
		GameStateController.OnIntroTransition();
	}
}