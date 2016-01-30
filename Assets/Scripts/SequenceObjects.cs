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

		for (int i = 0; i < sequenceLength; i++) {
			switch (Random.Range (0.0f, 2.0f)) {
			case 0.0f:
				sequence [i] = Department.A;
				break;
			case 1.0f:
				sequence[i] = Department.B;
				break;
			case 2.0f:
				sequence [i] = Department.C;
				break;
			}
		}
	}

	//function for failer?
	//
}
