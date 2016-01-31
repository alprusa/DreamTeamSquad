using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {
	public GameIntroController GameIntroController;
	public GameMainController GameMainController;
	public GameEndController GameEndController;
	
	void Start() {
		if(PlayerData.name == null || PlayerData.name.Length == 0) {
			GameIntroController.Show (true);
			GameMainController.Show (false);
			GameEndController.Show(false);
		} else {
			OnIntroTransition();
		}
	}

	public void OnIntroTransition() {
		GameIntroController.Show(false);
		GameMainController.InitWithPlayer();
		GameMainController.Show(true);
	}
	
	public void OnMainTransition() {
		GameMainController.Show(false);
		GameEndController.Show(true);
	}
	
	public void OnEndTransition() {
		GameEndController.Show(false);
		GameIntroController.Show (true);
	}
}