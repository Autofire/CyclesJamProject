using UnityEngine;
using ReachBeyond.EventObjects;

namespace Racer {
	[RequireComponent(typeof(Rigidbody2D))]
	public class BoostOnTrigger : MonoBehaviour {

		[SerializeField] private EventObjectInvoker invoker;
		[SerializeField] private Vector2 boostImpulse;
		[SerializeField] private string triggerTag = "Booster";

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
		}

		private void Start() {
			// This is here just to add the checkbox
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (enabled && other.CompareTag(triggerTag)) {
				rb.AddForce(boostImpulse, ForceMode2D.Impulse);
				invoker.Invoke();
			}
		}
	} // End class

} // End namespace