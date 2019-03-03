using UnityEngine;
using ReachBeyond.VariableObjects;

public class IntVariableSetter : MonoBehaviour
{
	public IntVariable target;
	public IntConstReference source;

	public void Apply() {
		target.StoredValue = source.ConstValue;
	}
}
