using UnityEngine;
using System.Collections;

public class GameMainController : MonoBehaviour {

	private CanvasGroup canvasGroup;
	
	public void Start() {
		canvasGroup = GetComponent<CanvasGroup>();
		if(canvasGroup == null) {
			Debug.LogError("Invalid controller object");
		}
	}

	public void Show(bool flag) {
		canvasGroup.alpha = flag ? 1 : 0;
		canvasGroup.interactable = flag;
		canvasGroup.blocksRaycasts = flag;
	}
}