using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PregameCameraController : VirtualCameraControllerBase
{
    //make the camera lerp from one side of track to the other
    //path position is between 0-1
    //at 1 switch to the other camera
    CinemachinePath path;
    CinemachineVirtualCamera thisCam;
    CinemachineTrackedDolly _dolly;
    public float lerpRate = .05f;
    public MasterCameraController masterCam;

    // Start is called before the first frame update
    void Start()
    {
        thisCam = GetComponent<CinemachineVirtualCamera>();

        _dolly = thisCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _dolly.m_PathPosition = Mathf.Lerp(_dolly.m_PathPosition, 1, lerpRate);
        
        //switch camera
        if (_dolly.m_PathPosition >= 0.9)
        {
            masterCam.SwitchCamera("CM vcam1");
        }
    }
}
