using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawner : MonoBehaviour
{
    private LightningIdentifier[] lightningboltIdenitifiers;
    private GameObject[] lightningBolts;
    private bool isCooldown = false;
    [SerializeField]
    private float minTimeUntilStrike = 1f;
    [SerializeField]
    private float maxTimeUntilStrike = 5f;
    private GameObject lastFiredBolt;

    private void Start()
    {
        lightningboltIdenitifiers = (LightningIdentifier[]) FindObjectsOfType(typeof(LightningIdentifier));
        lightningBolts = new GameObject[lightningboltIdenitifiers.Length];
        for (int i = 0; i < lightningboltIdenitifiers.Length; i++)
        {
            lightningBolts[i] = lightningboltIdenitifiers[i].gameObject;
        }
        lastFiredBolt = lightningBolts[Random.Range(0, lightningBolts.Length - 1)];
    }

    private void Update()
    {
        if (!isCooldown)
        {
            isCooldown = true;
            GameObject lightningBolt = RandomLightningBolt();
            StartCoroutine(LightningStrike(lightningBolt));
        }
    }

    private GameObject RandomLightningBolt()
    {
        Randomize:
        GameObject newBolt = lightningBolts[Random.Range(0, lightningBolts.Length - 1)];
        if (!lastFiredBolt.Equals(newBolt))
        {
            lastFiredBolt = newBolt;
        }
        else
        {
            goto Randomize;
        }
        return newBolt;
    }

    private IEnumerator LightningStrike(GameObject lightning)
    {
        yield return new WaitForSeconds(Random.Range(minTimeUntilStrike, maxTimeUntilStrike));

        lightning.GetComponent<ParticleSystem>().Play();
        isCooldown = false;
    }


}
