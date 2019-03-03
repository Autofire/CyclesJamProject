using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractApplier : MonoBehaviour
{

	[SerializeField] private bool loadOnEnable;

	virtual protected void OnEnable() {
		if(loadOnEnable) {
			Apply();
		}
	}

	abstract public void Apply();
}
