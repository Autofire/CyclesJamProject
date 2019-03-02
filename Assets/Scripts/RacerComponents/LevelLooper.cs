using UnityEngine;

namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class LevelLooper : MonoBehaviour {

		[SerializeField] private string triggerTag = "LevelBoundary";
		[SerializeField] private Renderer[] disableWhileTeleporting;

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
		}

		private void Start() {
			// This is here just to add the checkbox
		}

		private void OnTriggerExit2D(Collider2D other) {
			if (enabled && other.CompareTag(triggerTag)) {

				foreach (Renderer r in disableWhileTeleporting) {
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
	} // End class
} // End namespace