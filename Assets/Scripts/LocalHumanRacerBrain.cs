using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RacerBody))]
public class LocalHumanRacerBrain : MonoBehaviour {

	private RacerBody body;

	private void Awake() {
		body = GetComponent<RacerBody>();
	}

	void FixedUpdate () {
		body.Turn(Input.GetAxis("Vertical"));
	}
}
