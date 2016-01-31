using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class search : MonoBehaviour {
	public Text searchstring;
	private List<string> community;
	public FruitGenerator fruitgen;

	public void enter(){
		community = fruitgen.getname ();
		for (int i = 0; i < community.Count; i++) {
			if(community[i].Equals(searchstring.text))
				CameraController.SetTargetPosition(new Vector3(playerFruitCharacter.transform.position.x, 
					playerFruitCharacter.transform.position.y, CameraController.transform.position.z));
			
		}
	}
}
