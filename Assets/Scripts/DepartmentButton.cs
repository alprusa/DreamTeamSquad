using UnityEngine;
using System.Collections;

public enum Department {
	A,
	B,
	C
}

public class DepartmentButton : MonoBehaviour {

	public Department Department;
	public SequenceChecker SequenceChecker;

	// Use this for initialization
	void Start () {
		
	}
	
	#region Event Listeners
	
	
	public void OnPressed() {
		SequenceChecker.GetPlayersSequence(Department);
	}
	
	
	#endregion
}