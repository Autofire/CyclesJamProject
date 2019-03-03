using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.VariableObjects;
using ReachBeyond.EventObjects;

public class RaceController : MonoBehaviour
{
	public enum RaceMode {
		LapLimit, TimeLimit
	}

	[SerializeField] private FloatReference raceStartTime;
	[SerializeField] private EventObjectInvoker startEvent;
	[SerializeField] private RaceModeConstReference currentRaceMode;

	public void OnEnable() {
		raceStartTime.Value = Time.time;
		startEvent.Invoke();
	}
}
