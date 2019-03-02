using UnityEngine;

namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class LevelLooper : MonoBehaviour {

		[SerializeField] private string triggerTag = "LevelBoundary";
		[SerializeField] private TrailRenderer[] movableTrails;

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

				Debug.Log(rb.velocity);

				foreach (TrailRenderer r in movableTrails) {
					Vector3[] positions = new Vector3[r.positionCount];
					r.GetPositions(positions);

					for (int i = 0; i < positions.Length; i++) {
						positions[i].x += xOffset;
					}

					r.SetPositions(positions);
				} // End foreach
			} // End if
		} // End OnTriggerExit2D

	} // End class
} // End namespace