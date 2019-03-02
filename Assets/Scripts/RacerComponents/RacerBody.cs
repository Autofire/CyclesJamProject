﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class RacerBody : MonoBehaviour {

		[SerializeField] private float forwardForce = 1f;
		[SerializeField] private float turnForce = 30f;
		[SerializeField] private float turnStiffnessFactor = 8f;

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();

			UnityEngine.Assertions.Assert.IsNotNull(rb);
		}

		private void FixedUpdate() {
			rb.AddForce(Vector2.right * forwardForce);
			rb.velocity = new Vector2(
				rb.velocity.x,
				Mathf.MoveTowards(
					rb.velocity.y,
					0f,
					Time.deltaTime * turnStiffnessFactor * Mathf.Max(Mathf.Pow(rb.velocity.y, 4), 1f)
				)
			);

		}

		public void Turn(float magnitude) {
			float clampedMagnitude = Mathf.Clamp(magnitude, -1f, 1f);
			rb.AddForce(Vector2.up * turnForce * clampedMagnitude);
		}

	}

}