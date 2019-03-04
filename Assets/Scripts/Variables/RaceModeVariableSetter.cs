using UnityEngine;
using ReachBeyond.VariableObjects;

public class RaceModeVariableSetter : MonoBehaviour
{
	public RaceModeVariable target;
	public RaceModeConstReference source;

	public void Apply() {
		target.StoredValue = source.ConstValue;
	}
}
