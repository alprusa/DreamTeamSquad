using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {
	public GameIntroController GameIntroController;
	public GameMainController GameMainController;

	public void OnIntroTransition() {
		GameIntroController.Show(false);
		GameMainController.Show(true);
	}
}