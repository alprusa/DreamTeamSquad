using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public CanvasGroup CanvasGroup;
	
	protected virtual void Start() {}
	
	public void Show(bool flag) {
		CanvasGroup.alpha = flag ? 1 : 0;
		CanvasGroup.interactable = flag;
		CanvasGroup.blocksRaycasts = flag;
	}
	
	private IEnumerator ShowCoroutine(bool flag) {
		while(CanvasGroup == null)
			yield return null;
			
		Show (flag);
	}
}