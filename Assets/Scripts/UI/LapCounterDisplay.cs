using UnityEngine;
using ReachBeyond.EventObjects;
using ReachBeyond.VariableObjects;

public class LapCounterDisplay : AbstractEventObjectListener
{
	[SerializeField] private TMPro.TextMeshProUGUI textObj;
	[SerializeField] private TransformConstReference targetRacer;

	public override void OnRaiseEvent() {
		textObj.SetText(
			LapCounter.LapCount[targetRacer.ConstValue].ToString()
		);
	}
}
