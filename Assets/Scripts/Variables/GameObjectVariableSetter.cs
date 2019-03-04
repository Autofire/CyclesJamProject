using UnityEngine;
using ReachBeyond.VariableObjects;

public class GameObjectVariableSetter : MonoBehaviour
{
	public GameObjectVariable target;
	public GameObjectConstReference source;

	public void Apply() {
		target.StoredValue = source.ConstValue;
	}
}
