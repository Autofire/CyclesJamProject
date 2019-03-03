using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;

namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class LevelLooper : MonoBehaviour {

		[SerializeField] private string triggerTag = "LevelBoundary";

		[SerializeField] private EventObjectInvoker loopEvent;

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
		}

		private void Start() {
			// This is here just to add the checkbox
		}

		private void OnTriggerExit2D(Collider2D other) {
			if (enabled && other.CompareTag(triggerTag)) {

				float xOffset = -other.bounds.size.x;

				rb.position = new Vector3(
					rb.position.x + xOffset,
					rb.position.y
				);

				loopEvent.Invoke();

			} // End if
		} // End OnTriggerExit2D


	} // End class
} // End namespace