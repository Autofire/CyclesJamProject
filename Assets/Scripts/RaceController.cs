﻿using System.Collections;
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


	[Header("TimeLimit settings")]
	[SerializeField] private FloatConstReference timeLimit;

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

			default:
				Debug.Log("I got nothing for this");
				break;
		}
	}

	public void EndRace() {
		raceEndTime.Value = Time.time;
		endEvent.Invoke();

		enabled = false;
	}
}
