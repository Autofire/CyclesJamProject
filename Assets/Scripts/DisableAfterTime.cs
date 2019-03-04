using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script disables the object automatically after some time
// whenever it is enabled
public class DisableAfterTime : MonoBehaviour
{
    // Time after which object disables itself
    [SerializeField] private float time;
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disable", time);
    }
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
