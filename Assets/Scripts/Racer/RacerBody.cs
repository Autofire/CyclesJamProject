using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class RacerBody : MonoBehaviour {

		[SerializeField] public float forwardForce = 1f;
		[SerializeField] private float turnForce = 30f;
		[SerializeField] private float turnStiffnessFactor = 8f;

		[Space(10)]
		[SerializeField] private Transform modelTransform;
		[SerializeField] private Vector3 turnUpRotation;
		[SerializeField] private Vector3 forwardRotation;
		[SerializeField] private Vector3 turnDownRotation;

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

			if (modelTransform != null) {
				if (magnitude > 0f) {
					modelTransform.rotation = Quaternion.Euler(
						Vector3.Lerp(forwardRotation, turnUpRotation, magnitude)
					);
				}
				else if(magnitude < 0f) {
					modelTransform.rotation = Quaternion.Euler(
						Vector3.Lerp(forwardRotation, turnDownRotation, Mathf.Abs(magnitude))
					);
				}
				else {
					modelTransform.rotation = Quaternion.Euler(forwardRotation);
				}
			}
		} // End Turn function

	} // End class

} // End namespace