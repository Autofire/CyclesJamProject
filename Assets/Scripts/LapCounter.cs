using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;
using ReachBeyond.VariableObjects;

public class LapCounter : MonoBehaviour
{
	[SerializeField] private EventObjectInvoker lapEvent;
	[SerializeField] private StringConstReference name;

	private static Dictionary<string, int> _lapCount = new Dictionary<string, int>();
	public static Dictionary<string, int> LapCount {
		get {
			return new Dictionary<string, int>(_lapCount);
		}
	}

	public static void ClearAllLapCounts() {
		_lapCount = new Dictionary<string, int>();
	}

	public void IncrementCount() {
		if(_lapCount.ContainsKey(name.ConstValue)) {
			_lapCount[name.ConstValue]++;
		}
		else {
			_lapCount[name.ConstValue] = 0;
		}

		Debug.Log("Lap: " + _lapCount[name.ConstValue].ToString());
		lapEvent.Invoke();
	}

}
