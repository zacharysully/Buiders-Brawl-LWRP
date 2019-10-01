using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : MonoBehaviour
{
    [SerializeField]
    private float timeUntilKill = 20f;
    [SerializeField]
    private GameObject fireEffect;
    private float collisionCooldown = 1f;
    private bool isCooldown = false;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (!isCooldown)
            {
                isCooldown = true;
                GameObject fireParticles = Instantiate(fireEffect, other.gameObject.transform.position, other.gameObject.transform.rotation, other.gameObject.transform);


                //Ragdoll Physics
                StartCoroutine(KillPlayer(other, fireParticles));
            }
        }
    }

    private IEnumerator KillPlayer(GameObject player, GameObject particles)
    {
        yield return new WaitForSeconds(timeUntilKill);
        isCooldown = false;
        particles.GetComponentInChildren<ParticleSystem>().Stop();
        Destroy(particles);
        player.gameObject.GetComponent<PlayerDeath>().KillMe();
    }
}
