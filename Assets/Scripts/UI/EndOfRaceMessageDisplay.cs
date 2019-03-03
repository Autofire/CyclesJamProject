using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.EventObjects;
using ReachBeyond.VariableObjects;

public class EndOfRaceMessageDisplay : AbstractEventObjectListener
{
	[SerializeField] GameObject enableTarget;
	[SerializeField] RaceModeConstReference currentRaceMode;
	[SerializeField] RaceController.RaceMode[] associatedModes;

	public override void OnRaiseEvent() {
		if(associatedModes.Contains(currentRaceMode.ConstValue)) {
			enableTarget.SetActive(true);
		}
	}
}
