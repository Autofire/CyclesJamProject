using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRacerBrain : MonoBehaviour {

	public CircleRacerBody body;
	public string turnAxisName = "Vertical";

	void Update () {
		body.Turn(Input.GetAxis(turnAxisName));
	}
}
