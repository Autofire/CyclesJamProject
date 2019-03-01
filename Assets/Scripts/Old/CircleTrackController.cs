using UnityEngine;

namespace Old {
	public class CircleTrackController : MonoBehaviour {

		private static CircleTrackController _instance;
		public static CircleTrackController Instance {
			get { return _instance; }
		}

		public float radius;

		private void Awake() {
			_instance = this;
		}

#if UNITY_EDITOR
		private void OnValidate() {
			if (radius < 0) {
				radius = 0;
				Debug.LogWarning("Radius cannot be negative!");
			}
		}
#endif

	}
}