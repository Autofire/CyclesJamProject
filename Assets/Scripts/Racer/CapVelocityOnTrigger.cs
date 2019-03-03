using UnityEngine;

namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class CapVelocityOnTrigger : MonoBehaviour {

		[SerializeField] private Vector2 velocityCap = new Vector2(Mathf.Infinity, Mathf.Infinity);
		[SerializeField] private string triggerTag = "Wall";

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
		}

		private void Start() {
			// This is here just to add the checkbox
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (enabled && other.CompareTag(triggerTag)) {
				rb.velocity = new Vector2(
					Mathf.Min(velocityCap.x, rb.velocity.x),
					Mathf.Min(velocityCap.y, rb.velocity.y)
				);
			}
		}
	} // End class
} // End namespace