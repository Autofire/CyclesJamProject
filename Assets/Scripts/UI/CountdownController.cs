using UnityEngine;
using ReachBeyond.EventObjects;
using ReachBeyond.VariableObjects;

public class CountdownController : AbstractEventObjectListener
{
	[SerializeField] private IntConstReference countdownValue;

	[Tooltip("Sets each of these active, one at a time, each time the value is set to the matching index.")]
	[SerializeField] private GameObject[] countdownObjects;

	public override void OnRaiseEvent() {
		for(int i = 0; i < countdownObjects.Length; i++) {
			countdownObjects[i].SetActive(i == countdownValue.ConstValue);
		}
	}

}
