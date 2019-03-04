using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;
using ReachBeyond.VariableObjects;

public class LapCounter : MonoBehaviour
{
	[SerializeField] private EventObjectInvoker lapEvent;
	[SerializeField] private StringConstReference racerName;

	private static Dictionary<string, int> _lapCount = new Dictionary<string, int>();

	/// <summary>
	/// Gets the set of laps made. The keys are the racer's names, while the
	/// values are their lap totals. Note that this is a copy, and modifying
	/// it will NOT change the actual number of laps made.
	/// </summary>
	/// <value>The lap count.</value>
	public static Dictionary<string, int> LapCount {
		get {
			return new Dictionary<string, int>(_lapCount);
		}
	}

	public static void ClearAllLapCounts() {
		_lapCount = new Dictionary<string, int>();
	}

	public void IncrementCount() {
		if(_lapCount.ContainsKey(racerName.ConstValue)) {
			_lapCount[racerName.ConstValue]++;
		}
		else {
			_lapCount[racerName.ConstValue] = 0;
		}

		Debug.Log("Lap: " + _lapCount[racerName.ConstValue].ToString());
		lapEvent.Invoke();
	}

}
