﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoMechanic : MonoBehaviour
{
    public float timeUntilErupt;
    //public float timeUntilExplosion;
    public float moveSpeed; //Lava Movement Speed
    public float lavaEndYPos; //Position to Halt Lava Movement
    public bool eruptCooldown = true;
    public float shakeDuration;
    public float shakeMagnitude;

    private Vector3 lavaStartingPos;
    private float startTimer;
    private float explosionTimer;
    //private float timePassedUntilExplosion = 0f;
    private bool doCameraShake = true;
    private Transform cameraTransform;
    private Countdown countdownRef;
    public DangerIdentifier dangerSignRef;
    private GameObject countdown;
    private GameObject dangerSign;
    private bool allowFlash = true;
    private LavaParticlesIdentifier[] lavaParticleRef;
    private GameObject[] lavaGeysers;
    private bool currentlyExploding = false;
    private bool returnLavaState = false;

    private void Awake()
    {
        countdownRef = FindObjectOfType(typeof(Countdown)) as Countdown;
        //dangerSignRef = FindObjectOfType(typeof(DangerIdentifier)) as DangerIdentifier; //just drag into inspector
        lavaParticleRef = FindObjectsOfType<LavaParticlesIdentifier>();
    }

    private void Start()
    {
        lavaStartingPos = transform.localPosition;
        //startTimer = Time.time;
        explosionTimer = 0f;
        cameraTransform = GameManager.S.cameraRef.transform;
        GameManager.S.cameraRef.GetComponent<CameraController>().volcRef = this;
        countdown = countdownRef.gameObject;
        dangerSign = dangerSignRef.gameObject;
        dangerSign.SetActive(false);
        lavaGeysers = new GameObject[lavaParticleRef.Length];
        for (int i = 0; i < lavaParticleRef.Length; i++)
        {
            lavaGeysers[i] = lavaParticleRef[i].gameObject;
        }

        //Tom mod
        StartCoroutine(ShakeAtStartOnly());

    }

    /*
    private void Update()
    {
        if (!countdownRef.GetComponent<Countdown>().countDown)
        {
            float timePassed = Time.time - startTimer;
            /*
            if (!eruptCooldown && currentlyExploding)
            {
                if (!lavaGeysers[lavaGeysers.Length - 1].transform.GetChild(2).GetComponent<ParticleSystem>().isEmitting)
                {
                    currentlyExploding = false;
                    transform.position = lavaStartingPos;
                    eruptCooldown = true;
                    allowFlash = true;
                }

            }*
            if (!eruptCooldown)
            {
                if (transform.localPosition.y <= lavaEndYPos)
                {
                    //timePassedUntilExplosion += 1f;

                    Debug.Log("Lava is Emerging!");
                    transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                    if (doCameraShake)
                    {
                        GameManager.S.cameraRef.GetComponent<CameraController>().cameraShake = true;
                        doCameraShake = false;
                    }
                }
                if (transform.localPosition.y >= lavaEndYPos - 2 && !currentlyExploding)
                {
                    currentlyExploding = true;
                    EruptLava();
                }
                if (currentlyExploding)
                {
                    if (!lavaGeysers[lavaGeysers.Length - 1].transform.GetChild(2).GetComponent<ParticleSystem>().isEmitting)
                    {
                        currentlyExploding = false;
                        //transform.position = lavaStartingPos;
                        eruptCooldown = true;
                        returnLavaState = true;
                        //allowFlash = true;
                    }
                }
                /*
                if (timePassed >= timeUntilExplosion)
                {
                    GameManager.S.cameraRef.GetComponent<CameraController>().cameraShake = true;
                }*

            }
            else if (eruptCooldown && returnLavaState)
            {
                Debug.Log("Receding Lava!");
                if (transform.localPosition.y > lavaStartingPos.y)
                {
                    transform.position += Vector3.down * moveSpeed * Time.deltaTime;
                }
                else
                {
                    returnLavaState = false;
                    allowFlash = true;
                    startTimer = Time.time;

                }

            }
            else
            {
                Debug.Log("The Volcano Lies Dormant.");
                if (timePassed >= timeUntilErupt)
                {

                    eruptCooldown = false; //End the Cooldown (Volcano is now active!)
                    startTimer = Time.time;
                    //timePassedUntilExplosion = 0f;
                    doCameraShake = true;

                }
                else if (timePassed >= timeUntilErupt - 2.5f)
                {
                    if (allowFlash)
                    {
                        allowFlash = false;
                        StartCoroutine("ShowDangerSign");
                    }
                }
            }

        }
        else
        {
            startTimer = Time.time;
        }
    }
    */


    public IEnumerator ShakeAtStartOnly()
    {
        yield return new WaitForSeconds(25f);
        //danger sign 
        StartCoroutine(ShowDangerSign());

        yield return new WaitForSeconds(3f);
        //danger sign 
        StartCoroutine(ScreenShake());



    }

    public IEnumerator ScreenShake()
    {
        //print("screen shake");

        float elapsed = 0.0f;

        //Vector3 originalCamPos = cameraTransform.position;

        while (elapsed < shakeDuration)
        {
            Vector3 originalCamPos = cameraTransform.position;

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / shakeDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            float x = Random.value * 2.0f - 1.0f;
            float z = Random.value * 2.0f - 1.0f;

            x *= shakeMagnitude * damper;
            z *= shakeMagnitude * damper;

            cameraTransform.position = new Vector3(originalCamPos.x + x, originalCamPos.y, originalCamPos.z + z);

            yield return null;
        }

        /*
        if (elapsed >= shakeDuration)
        {
            //eruptCooldown = true;
            startTimer = Time.time;
            //transform.position = lavaStartingPos;
        }*/
        //cameraTransform.position = originalCamPos;
    }

    private IEnumerator ShowDangerSign()
    {
        dangerSign.SetActive(true);
        yield return new WaitForSeconds(.5f);
        dangerSign.SetActive(false);
        yield return new WaitForSeconds(.5f);
        dangerSign.SetActive(true);
        yield return new WaitForSeconds(.5f);
        dangerSign.SetActive(false);
        yield return new WaitForSeconds(.5f);
        dangerSign.SetActive(true);
        yield return new WaitForSeconds(.5f);
        dangerSign.SetActive(false);

    }

    private void EruptLava()
    {
        for (int i = 0; i < lavaGeysers.Length; i++)
        {
            for (int c = 0; c < lavaGeysers[i].transform.childCount; c++)
            {
                lavaGeysers[i].transform.GetChild(c).GetComponent<ParticleSystem>().Play();
            }
        }
    }

    /*
    public IEnumerator ScreenShake()
    {
        yield return new WaitForSeconds(timeUntilExplosion);
        Debug.Log("Shaking Screen");
        //Vector3 originalPos = cameraTransform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float z = Random.Range(-1f, 1f) * shakeMagnitude;

            cameraTransform.position = new Vector3(x, cameraTransform.position.y, z);
            Debug.Log("Elapsed Time: " + elapsed);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        //cameraTransform.position = originalPos;
    }*/
}
