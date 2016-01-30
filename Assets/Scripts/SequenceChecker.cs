using UnityEngine;
using System.Collections;

public class SequenceChecker : MonoBehaviour {

	public GameStateController GameStateController;
	public SequenceObjects sequenceObjects;

	private int currentIndex;

	// Use this for initialization
	void Start () {
		sequenceObjects = new SequenceObjects ();
		currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("q"))
			GetPlayersSequence (Department.A);
		if (Input.GetKey ("w"))
			GetPlayersSequence (Department.B);
		if (Input.GetKey ("e"))
			GetPlayersSequence (Department.C);
	}


	public void GetPlayersSequence(Department val) {
		if (sequenceObjects.sequence [currentIndex] != val) {
			Debug.Log ("Fail");
			GameStateController.OnMainTransition();
		}
		
		if(sequenceObjects.sequence.Count >= currentIndex) currentIndex++;
	}
}
