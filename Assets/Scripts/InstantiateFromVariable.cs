using UnityEngine;
using ReachBeyond.VariableObjects;

public class InstantiateFromVariable : MonoBehaviour
{
	[SerializeField] private GameObjectConstReference objectPrefab;
	[SerializeField] private TransformConstReference targetPoint;
	[SerializeField] private TransformConstReference targetRotation;
	[SerializeField] private TransformConstReference targetParent;

	void Start()
    {
		Instantiate(
			objectPrefab.ConstValue,
			targetPoint.ConstValue.position,
			targetRotation.ConstValue.rotation,
			targetParent.ConstValue
		);
    }

}
