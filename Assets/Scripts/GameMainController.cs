using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainController : Controller {
	public CameraController CameraController;
	public SpeechBubble SpeechBubble;
	public FruitGenerator FruitGenerator;
	public CheckButton CheckButton;
	
	private FruitCharacter playerFruitCharacter;
	
	public void InitWithPlayer() {
		SpeechBubble.SetText ("Good morning, " + PlayerData.name + "!\n" + "You have " + PlayerData.currency + " apple bits.");
		
		CheckButton.SetButton();
		StartCoroutine(WaitForFruits());
	}
	
	private IEnumerator WaitForFruits() {
		while(!FruitGenerator.HasFinishedGenerating()) {
			yield return null;
		}
		
		playerFruitCharacter = FruitGenerator.ChoosePlayerFruit();
		CameraController.SetTargetPosition(new Vector3(playerFruitCharacter.transform.position.x, 
		                                               playerFruitCharacter.transform.position.y, CameraController.transform.position.z));
		UpdatePlayerFruit();
	}
	
	public void TogglePlayerCheckedIn() {
		PlayerData.checkedIn = !PlayerData.checkedIn;
		CheckButton.SetButton();
		UpdatePlayerFruit();
	}
	
	public void UpdatePlayerFruit() {
		FruitModel playerModel = new FruitModel();
		playerModel.Name = PlayerData.name;
		playerModel.Hours = 0;
		playerModel.CheckedIn = PlayerData.checkedIn;
		if(playerFruitCharacter != null)
			playerFruitCharacter.InitWithModel(playerModel);
	}
}