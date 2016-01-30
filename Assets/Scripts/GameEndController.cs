using UnityEngine;
using System.Collections;

public class GameEndController : MonoBehaviour {

	public CanvasGroup CanvasGroup;
	
	public void Start() {
		CanvasGroup = GetComponent<CanvasGroup>();
		if(CanvasGroup == null) {
			Debug.LogError("Invalid controller object");
		}
	}

	public void Show(bool flag) {
		CanvasGroup.alpha = flag ? 1 : 0;
		CanvasGroup.interactable = flag;
		CanvasGroup.blocksRaycasts = flag;
	}
}