using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu]
public class MasterCameraController : ScriptableObject
{
    public Dictionary<string, CinemachineVirtualCameraBase> _masterList;
    public CinemachineVirtualCameraBase _activeCam;

    public void AddToMasterList(CinemachineVirtualCameraBase camToAdd)
    {
        _masterList.Add(camToAdd.name, camToAdd);
    }

    public void SwitchCamera(string camName)
    {
        _activeCam.gameObject.SetActive(false);
        _masterList[camName].gameObject.SetActive(true);
        _activeCam = _masterList[camName];
    }

    public void Initialize()
    {
        _masterList = new Dictionary<string, CinemachineVirtualCameraBase>();
    }
}
