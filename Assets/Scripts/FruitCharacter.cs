using UnityEngine;
using System.Collections;
using System;

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
	
	private float elapsedTime = 0f;
	
	void Update() {
		elapsedTime += Time.deltaTime;
		
		HoursTextMesh.text = (cachedModel.CheckedIn ? "Checked in: " : "Checked out");
		if(cachedModel.CheckedIn)
			HoursTextMesh.text += this.GetTimeStr(cachedModel.Hours + elapsedTime / 3600f);
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
	
	public void Freeze(bool flag) {
		GetComponent<Animator>().speed = (flag ? 0 : 1);
	}
	
	#region Event Listeners
	
	public void OnMouseDown() {
		SpriteRender.color = Color.gray;
	}
	
	public void OnMouseUp() {
		SpriteRender.color = Color.white;
		
		if(PlayerData.name == null || PlayerData.name.Length == 0 || cachedModel.Name != PlayerData.name)
			return;
		
		Application.LoadLevel("tree_branch");
	}
	
	
	#endregion
	
	private string GetTimeStr(float time) {
		TimeSpan t = TimeSpan.FromHours( time );
		
		string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
		                              t.Hours, 
		                              t.Minutes, 
		                              t.Seconds);
		                    return answer;
	}
}