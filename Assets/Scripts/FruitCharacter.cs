using UnityEngine;
using System.Collections;

public enum Department {
	A,
	B,
	C
}

public class FruitCharacter : MonoBehaviour {

	public Department Department;

	// Use this for initialization
	void Start () {
		
	}
	
	#region Event Listeners
	
	
	public void OnPressed() {
		//SequenceChecker.GetPlayersSequence(Department);
	}
	
	
	#endregion
}