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

	public FruitQuality Quality;
	
	private FruitModel cachedModel;

	// Use this for initialization
	void Start () {
		
	}
	
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
	}
	
	#region Event Listeners
	
	public void OnMouseDown() {
		SpriteRender.color = Color.gray;
	}
	
	public void OnMouseUp() {
		SpriteRender.color = Color.white;
		
		
	}
	
	
	#endregion
}