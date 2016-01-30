using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceObjects {

	public Department department;
	public string value;
	public int amount;

	public List<Department> sequence;

	public int sequenceLength = 10;

	// Use this for initialization
	public SequenceObjects() {
		sequence = new List<Department> ();

		string tempStr = "";
		for (int i = 0; i < sequenceLength; i++) {
			string rand = Random.Range (0.0f, 2.0f).ToString();
			switch (rand) {
			case "0.0":
				sequence.Add(Department.A);
				break;
			case "1.0":
				sequence.Add(Department.B);
				break;
			default:
				sequence.Add(Department.C);
				break;
			}
			tempStr = sequence [i].ToString ();
		}
		Debug.Log (tempStr);
	}

	//function for failer?
	//
}
