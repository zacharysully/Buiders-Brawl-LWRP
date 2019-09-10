﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraControllerBase : MonoBehaviour
{
    //add to the master

    public MasterCameraController controllerRef;

    // Start is called before the first frame update
    public virtual void Start()
    {
        controllerRef.AddToMasterList(GetComponent<CinemachineVirtualCameraBase>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
