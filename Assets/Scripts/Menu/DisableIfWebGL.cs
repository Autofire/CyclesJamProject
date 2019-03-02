using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfWebGL : MonoBehaviour
{
    
    void Awake()
    {
#if UNITY_WEBGL
		enabled = false;
#else
		enabled = true;
#endif
	}
}
