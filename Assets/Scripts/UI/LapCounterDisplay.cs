using UnityEngine;
using ReachBeyond.EventObjects;
using ReachBeyond.VariableObjects;

public class LapCounterDisplay : AbstractEventObjectListener
{
	[SerializeField] private TMPro.TextMeshProUGUI textObj;
	[SerializeField] private StringConstReference targetRacer;

	[SerializeField] private bool triggerOnEnable = false;

	protected override void OnEnable() {
		base.OnEnable();

		if(triggerOnEnable) {
			OnRaiseEvent();
		}
	}

	override public void OnRaiseEvent() {
		textObj.SetText(
			LapCounter.LapCount[targetRacer.ConstValue].ToString()
		);
	}
}
