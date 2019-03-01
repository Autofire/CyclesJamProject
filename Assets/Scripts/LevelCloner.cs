using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This makes a clone of the level so that the player cannot tell that 
/// they are looping around.
/// </summary>
public class LevelCloner : MonoBehaviour {

	[SerializeField] private BoxCollider2D levelBounds;
	[SerializeField] private GameObject originalLevel;
	[SerializeField] private bool makeBackClone = true;
	[SerializeField] private bool makeForwardClone = true;

	void Start () {
		Vector3 offsetAmount = Vector3.right * levelBounds.transform.localScale.x;

		if (makeBackClone) {
			MakeClone(originalLevel.transform.position - offsetAmount);
		}

		if (makeForwardClone) {
			MakeClone(originalLevel.transform.position + offsetAmount);
		}
	}

	void MakeClone(Vector3 clonePos) {
		Instantiate(
			originalLevel,
			clonePos,
			originalLevel.transform.rotation,
			originalLevel.transform.parent
		);
	}

}
