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

	[SerializeField] private EventObjectInvoker startEvent;
	[SerializeField] private EventObjectInvoker endEvent;
	[SerializeField] private FloatReference raceStartTime;
	[SerializeField] private FloatReference raceEndTime;
	[SerializeField] private RaceModeConstReference currentRaceMode;


	[Header("Time limit settings")]
	[SerializeField] private FloatConstReference timeLimit;

	[Header("Lap limit settings")]
	[SerializeField] private IntConstReference lapTarget;

	public void OnEnable() {
		raceStartTime.Value = Time.time;
		LapCounter.ClearAllLapCounts();
		startEvent.Invoke();
	}

	public void Update() {
		switch(currentRaceMode.ConstValue) {
			case RaceMode.TimeLimit:
				if(Time.time >= raceStartTime.ConstValue + timeLimit) {
					//enabled = false;
					EndRace();
				}
				break;

			case RaceMode.LapLimit:
				// Do nothing; we'll get notified to check this
				// whenever a racer makes a lap
				break;
		}
	}

	public void CheckLaps() {
		switch(currentRaceMode.ConstValue) {
			case RaceMode.LapLimit:
				List<int> laps = new List<int>(LapCounter.LapCount.Values);

				bool allRacersMetLapTarget =
					laps.TrueForAll((count) => count >= lapTarget.ConstValue);

				if(allRacersMetLapTarget) {
					EndRace();
				}

				break;
			default:
				break;
		}
	}

	public void EndRace() {
		raceEndTime.Value = Time.time;
		endEvent.Invoke();

		enabled = false;
	}
}
