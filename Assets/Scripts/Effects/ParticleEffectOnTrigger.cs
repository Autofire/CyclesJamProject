using UnityEngine;
using System.Collections.Generic;

/*
 * CLASS ParticleEffectOnTrigger
 * -----------------------------
 * Instantiates a copy of the given object at the script object's transform
 * position as soon as it hits a trigger with one of the designated tags,
 * then destroys the copy after some time
 * -----------------------------
 */
 
public class ParticleEffectOnTrigger : MonoBehaviour
{
    // Local GameObject enabled/disabled to create the effect
    [SerializeField] private GameObject particlePrefab;
    // Any trigger with one of these tags will trigger the particle effect
    [SerializeField] private List<string> triggerTags;
    // A group of reusable copies of the particle prefab
    private ObjectPool<Transform> particlePool;

    // Initialize the particle pool
    private void Start()
    {
        particlePool = new ObjectPool<Transform>(particlePrefab, "TriggerParticles");
    }
    // If the other collider's tag is in the list, trigger the particle effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool triggerEffect = triggerTags.Contains(collision.tag);
        if(triggerEffect)
        {
            TriggerParticleEffect();
        }
    }
    // Get an object from the pool, move it, and activate it
    private void TriggerParticleEffect()
    {
        Transform particleTrans = particlePool.getOneQuick;
        particleTrans.position = transform.position;
        particleTrans.gameObject.SetActive(true);
    }
}
