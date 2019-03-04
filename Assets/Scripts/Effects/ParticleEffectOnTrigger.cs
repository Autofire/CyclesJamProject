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
    [SerializeField] private GameObject particle;
    // Time for which the particle stays before being destroyed
    [SerializeField] private float lifetime;
    // Any trigger with one of these tags will trigger the particle effect
    [SerializeField] private List<string> triggerTags;

    // If the other collider's tag is in the list, trigger the particle effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool triggerEffect = triggerTags.Contains(collision.tag);
        if(triggerEffect)
        {
            TriggerParticleEffect();
        }
    }
    // Reactivate the local object, then disable it after specified time
    private void TriggerParticleEffect()
    {
        // Reactivate the particle
        particle.SetActive(false);
        particle.SetActive(true);
        // Cause the particle to disable after specified time
        CancelInvoke();
        Invoke("DisableParticle", lifetime);
    }
    private void DisableParticle()
    {
        particle.SetActive(false);
    }
}
