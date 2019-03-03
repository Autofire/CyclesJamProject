using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfWebGL : MonoBehaviour
{
	[SerializeField] private GameObject target;
    
    void Awake()
    {
#if UNITY_WEBGL
		//enabled = false;
		target.SetActive(false);
#else
		//enabled = true;
#endif
	}
}
