using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainController : MonoBehaviour {
	private int counter=0;
	public GameObject Shop;
	public Text custom;
	public void Shopping(){
		Shop.SetActive (true);
		counter++;
		custom.text = "Exit";
				if (counter > 2) {
			custom.text = "Customize";
			Shop.SetActive (false);
			counter = 0;
		}

	}
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