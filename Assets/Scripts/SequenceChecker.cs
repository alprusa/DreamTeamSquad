using UnityEngine;
using System.Collections;

public class SequenceChecker : MonoBehaviour {

	public SequenceObjects sequenceObjects;

	private int currentIndex;

	// Use this for initialization
	void Start () {
		sequenceObjects = new SequenceObjects ();
		currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GetPlayersSequence(Department val){
		if (sequenceObjects [currentIndex] != val)
			Debug.Log ("Fail");
		
		currentIndex++;
	}
}
