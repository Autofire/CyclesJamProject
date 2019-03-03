using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;

public class DelayedInvoke : MonoBehaviour {
	[SerializeField] private float delay;
	[SerializeField] private EventObjectInvoker invoker;

	private float invokeTime;

	private void OnEnable() {
		invokeTime = Time.time + delay;
	}

	void Update() {
		// We use a loop for this in the case that tickFrequency
		// ends up being shorter than the Update clock. That way, we'll
		// still count the same way regardless of the time step.
		if(Time.time >= invokeTime) {
			invoker.Invoke();
			enabled = false;
		}
	}
}

