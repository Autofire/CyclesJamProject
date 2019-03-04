using UnityEngine;
using ReachBeyond.VariableObjects;

public class FloatVariableSetter : MonoBehaviour
{
	public FloatVariable target;
	public FloatConstReference source;

	public void Apply() {
		target.StoredValue = source.ConstValue;
	}
}
