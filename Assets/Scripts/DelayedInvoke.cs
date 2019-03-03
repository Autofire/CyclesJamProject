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
		if(Time.time >= invokeTime) {
			invoker.Invoke();
			enabled = false;
		}
	}
}

