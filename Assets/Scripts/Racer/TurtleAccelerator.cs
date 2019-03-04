using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racer {
	[RequireComponent(typeof(RacerBody))]
	public class TurtleAccelerator : MonoBehaviour {
		[SerializeField] private float accelerationIncreaseAmount;

		private RacerBody body;

		private void Awake() {
			body = GetComponent<RacerBody>();
		}

		public void IncreaseSpeed() {
			body.forwardForce += accelerationIncreaseAmount;
		}
	}
}
