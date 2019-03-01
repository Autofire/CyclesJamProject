using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRacerBody : MonoBehaviour {

	public float velocity = 0f;
	public float acceleration = 1f;
	public float dragCoefficient = 0.5f;

	public float verticalMoveSpeed = 1f;
	public float verticalClamp = 2f;

	public void Turn(float magnitude) {

		float clampedMagnitude = Mathf.Clamp(magnitude, -1f, 1f);
		float rawYPos = transform.position.y + clampedMagnitude * verticalMoveSpeed * Time.deltaTime;
		float clampedYPos = Mathf.Clamp(rawYPos, -verticalClamp, verticalClamp);

		transform.position = new Vector3(
			transform.position.x,
			clampedYPos,
			transform.position.z
		);
	}

	void Update () {
		MoveForward();
	}

	private void MoveForward() {
		// The equation is:
		//  v = v0 + a * dt
		//
		// where v0 is the intial velocity, a is the acceleration, and
		// dt is the change in time. The result is the new velocity on this
		// step.
		velocity =
			velocity
			+ acceleration * Time.deltaTime
			- dragCoefficient * velocity * velocity * Time.deltaTime;

		// The distance to travel in this timestep.
		float dist = velocity * Time.time;

		// However, the distance we have is a linear distance. We travel
		// in a big circle, so we gotta figure out the amount we'd move
		// in terms of a rotation.
		//
		// This is an arc, which has a length of:
		//  arcLength = radius * theta
		// 
		// We want theta, so we solve for it:
		//  theta = arcLength / radius
		//
		// In this case, the total distance traveled is arcLength, which
		// we have already found. Radius can come out of CircleTrackController.
		float radius = Vector3.Distance(CircleTrackController.Instance.transform.position, transform.position);
		float rotationAmount = dist / radius;

		// Alright, finally, we can move ourself. 
		transform.RotateAround(
			CircleTrackController.Instance.transform.position,
			CircleTrackController.Instance.transform.up,
			rotationAmount
		);
	}

}
