using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour {

	public Text SpeechText;

	public void SetText(string speechText) {
		SpeechText.text = speechText;
	}
}
