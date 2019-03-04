using UnityEngine;

public class VelocitySpin : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 initialSpeed;
	[SerializeField] private Vector3 velocityScale;

	private void Update() {
		target.Rotate((initialSpeed + velocityScale * rb.velocity.x) * Time.deltaTime);
	}
}
