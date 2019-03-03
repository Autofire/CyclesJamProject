using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.VariableObjects;

public class TimeScaler : AbstractApplier
{
	[SerializeField] private FloatConstReference targetScale;

	public override void Apply() {
		Time.timeScale = targetScale.ConstValue;
	}
}
