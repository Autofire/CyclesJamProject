using UnityEngine;
using Cinemachine;
using ReachBeyond.VariableObjects;

namespace ReachBeyond.Camera {
	public class TargetSetter : MonoBehaviour {

		[SerializeField] private TransformConstReference target;
		[SerializeField] private bool setLookAt = true;
		[SerializeField] private bool setFollow = true;

		[SerializeField] private CinemachineVirtualCamera virtualCamera;
		[SerializeField] private int nullPriority = 0;
		[SerializeField] private int nonNullPriority = 10;

		public void SetTarget() {
			if(setLookAt) {
				virtualCamera.LookAt = target.ConstValue;
			}

			if(setFollow) {
				virtualCamera.Follow = target.ConstValue;
			}

			virtualCamera.Priority = (
				target.ConstValue == null ? nullPriority : nonNullPriority
			);
		}
	}

}