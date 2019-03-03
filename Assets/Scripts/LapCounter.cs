using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;

public class LapCounter : MonoBehaviour
{
	[SerializeField] private EventObjectInvoker lapEvent;

	private static Dictionary<Transform, int> _lapCount = new Dictionary<Transform, int>();
	public static Dictionary<Transform, int> LapCount {
		get {
			return new Dictionary<Transform, int>(_lapCount);
		}
	}

	public static void ClearAllLapCounts() {
		_lapCount = new Dictionary<Transform, int>();
	}

	public void IncrementCount() {
		if(_lapCount.ContainsKey(transform)) {
			_lapCount[transform]++;
		}
		else {
			_lapCount[transform] = 0;
		}

		Debug.Log("Lap: " + _lapCount[transform].ToString());
		lapEvent.Invoke();
	}

}
