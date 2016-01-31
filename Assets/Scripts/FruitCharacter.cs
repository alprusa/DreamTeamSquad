using UnityEngine;
using System.Collections;

public enum FruitQuality {
	Good,
	Neutral,
	Bad
}

public class FruitCharacter : MonoBehaviour {

	// GUI
	public SpriteRenderer SpriteRender;
	public TextMesh NameTextMesh;
	public TextMesh HoursTextMesh;

	public FruitQuality Quality;
	
	private FruitModel cachedModel;
	
	public void InitWithModel(FruitModel model) {
		cachedModel = model;
		
		if(model.Hours >= 15) {
			Quality = FruitQuality.Good;
		} else if(model.Hours >= 5) {
			Quality = FruitQuality.Neutral;
		} else {
			Quality = FruitQuality.Bad;
		}
		
		NameTextMesh.text = cachedModel.Name;
		HoursTextMesh.text = (cachedModel.CheckedIn ? "Checked in: " : "Checked out: ") +
			cachedModel.Hours;
	}
	
	#region Event Listeners
	
	public void OnMouseDown() {
		SpriteRender.color = Color.gray;
	}
	
	public void OnMouseUp() {
		if(PlayerData.name == null || PlayerData.name.Length == 0)
			return;
			
		SpriteRender.color = Color.white;
		
		Application.LoadLevel("tree_branch");
	}
	
	
	#endregion
}