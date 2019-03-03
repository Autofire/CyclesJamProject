using UnityEngine;
using ReachBeyond.VariableObjects;
using ReachBeyond.EventObjects;

/// <summary>
/// Hook this into an EventObjectListener to have it check whenever the
/// variable changes.
/// </summary>
public class IntChecker : AbstractEventObjectListener
{
	private enum CheckMode {
		EqualTo, NotEqualTo, LessThan, GreaterThan, LessThanOrEqualTo, GreatherThanOrEqualTo,
	}

	[SerializeField] private IntConstReference value1;
	[SerializeField] private CheckMode mode;
	[SerializeField] private IntConstReference value2;
	[SerializeField] private EventObjectInvoker invoker;

	public override void OnRaiseEvent() {
		bool result = false;

		switch(mode) {
			case CheckMode.EqualTo:
				result = value1.ConstValue == value2.ConstValue;
				break;
			case CheckMode.NotEqualTo:
				result = value1.ConstValue != value2.ConstValue;
				break;
			case CheckMode.LessThan:
				result = value1.ConstValue < value2.ConstValue;
				break;
			case CheckMode.GreaterThan:
				result = value1.ConstValue > value2.ConstValue;
				break;
			case CheckMode.LessThanOrEqualTo:
				result = value1.ConstValue <= value2.ConstValue;
				break;
			case CheckMode.GreatherThanOrEqualTo:
				result = value1.ConstValue >= value2.ConstValue;
				break;
		}

		if (result) {
			invoker.Invoke();
		}
	}
}
