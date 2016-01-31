using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class search : MonoBehaviour {
	public CameraController CameraController;
	public Text searchstring;
	private List<string> community;
	public FruitGenerator fruitgen;

	public void enter() {
		string query = searchstring.text;
		if(query == null || query.Length == 0)
			return;
			
		List<FruitCharacter> fruits = fruitgen.GetFruits();
		foreach(FruitCharacter fruit in fruits) {
			if(fruit.GetName().ToLower() == query.ToLower()) {
				Transform target = fruit.transform;
				CameraController.SetTargetPosition(new Vector3(target.position.x, target.position.y, CameraController.transform.position.z));
			}
		}
		
		
	}
}
