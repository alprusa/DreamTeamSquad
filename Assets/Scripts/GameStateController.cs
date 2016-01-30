using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {
	public GameIntroController GameIntroController;
	public GameMainController GameMainController;
	public GameEndController GameEndController;
	
	void Start() {
		GameIntroController.Show (true);
		GameMainController.Show (false);
		GameEndController.Show(false);
	}

	public void OnIntroTransition() {
		GameIntroController.Show(false);
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