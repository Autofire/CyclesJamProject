using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class RacerBody : MonoBehaviour {

	[SerializeField] private float forwardForce = 1f;
	[SerializeField] private float turnForce = 30f;
	[SerializeField] private float turnStiffnessFactor = 8f;
	[SerializeField] private float boostForce = 10f;
	[SerializeField] private float maxSpeedAfterImpact = 1f;

	[SerializeField] private string loopBoundaryTag = "LevelBoundary";
	[SerializeField] private string boosterTag = "Booster";
	[SerializeField] private string wallTag = "Wall";

	[SerializeField] private Renderer[] disableWhileTeleporting;

	private Rigidbody2D rb;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();

		UnityEngine.Assertions.Assert.IsNotNull(rb);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag(boosterTag)) {
			Boost();
		}
		else if(other.CompareTag(wallTag)) {
			Impact();
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag(loopBoundaryTag)) {

			foreach(Renderer r in disableWhileTeleporting) {
				r.enabled = false;
			}

			rb.position = new Vector3(
				rb.position.x - other.bounds.size.x,
				rb.position.y
			);
			Debug.Log(rb.velocity);

			foreach (Renderer r in disableWhileTeleporting) {
				r.enabled = true;
			}
		}
	}

	private void FixedUpdate() {
		rb.AddForce(Vector2.right * forwardForce);
		rb.velocity = new Vector2(
			rb.velocity.x,
			Mathf.MoveTowards(
				rb.velocity.y,
				0f,
				Time.deltaTime * turnStiffnessFactor * Mathf.Max( Mathf.Pow(rb.velocity.y, 4), 1f )
			)
		);

	}

	public void Turn(float magnitude) {

		float clampedMagnitude = Mathf.Clamp(magnitude, -1f, 1f);
		rb.AddForce(Vector2.up * turnForce * clampedMagnitude);
	}

	public void Boost() {
		rb.AddForce(Vector2.right * boostForce, ForceMode2D.Impulse);
	}

	public void Impact() {
		rb.velocity = new Vector2(
			Mathf.Min(maxSpeedAfterImpact, rb.velocity.x),
			rb.velocity.y
		);
	}

}
