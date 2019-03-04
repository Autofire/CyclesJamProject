using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;

public class AutoInvoker : MonoBehaviour
{
	[SerializeField] private EventObjectInvoker invoker;
	[SerializeField] private bool onAwake = false;
	[SerializeField] private bool onStart = false;
	[SerializeField] private bool onEnable = false;
	[SerializeField] private bool onDisable = false;

	private void Awake() {
		if(onAwake) {
			invoker.Invoke();
		}
	}

	private void Start() {

		if (onStart) {
			invoker.Invoke();
		}
	}

	private void OnEnable() {

		if (onEnable) {
			invoker.Invoke();
		}
	}

	private void OnDisable() {

		if (onDisable) {
			invoker.Invoke();
		}
	}

}
