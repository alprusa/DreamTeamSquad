using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainController : Controller {
	public CameraController CameraController;
	public SpeechBubble SpeechBubble;
	public FruitGenerator FruitGenerator;
	
	private FruitCharacter playerFruitCharacter;
	
	public void InitWithPlayer() {
		SpeechBubble.SetText ("Good morning, " + PlayerData.name + "!");
		playerFruitCharacter = FruitGenerator.ChoosePlayerFruit();
		CameraController.SetTargetPosition(new Vector3(playerFruitCharacter.transform.position.x, 
			playerFruitCharacter.transform.position.y, CameraController.transform.position.z));
		UpdatePlayerFruit();
	}
	
	public void TogglePlayerCheckedIn() {
		PlayerData.checkedIn = !PlayerData.checkedIn;
		Debug.Log (PlayerData.checkedIn);
		UpdatePlayerFruit();
	}
	
	public void UpdatePlayerFruit() {
		
		Debug.Log (playerFruitCharacter);
		
		FruitModel playerModel = new FruitModel();
		playerModel.Name = PlayerData.name;
		playerModel.Hours = 0;
		playerModel.CheckedIn = PlayerData.checkedIn;
		playerFruitCharacter.InitWithModel(playerModel);
	}
}