using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumPad : MonoBehaviour {
	public string stringToEdit = "";
	public Text output;
	private TouchScreenKeyboard keyboard;

	// 
	public void Enter(string input) {
		stringToEdit += input;
		output.text = stringToEdit;
	}
	public void Done(){
		Destroy(gameObject);

	}
	public void Backspace(){
		stringToEdit = stringToEdit.Substring (0, stringToEdit.Length - 1);
	}
}