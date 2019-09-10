using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraController : VirtualCameraControllerBase
{
    public Vector3 midpoint;
    public Transform midpointT;
    public Transform followObject;
    public float followXOffset = 30;
    float furthestDistance = 0f;
    private Vector3 furthestPlayer1 = Vector3.zero;
    private Vector3 furthestPlayer2 = Vector3.zero;
    private float height = 0;
    public float cameraYHeightFloor;
    public float cameraYHeightCeiling;
    private float pitchPercent;
    public float cameraPlayerDistanceFloor;
    public float cameraPlayerDistanceCeiling;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        FindMidpoint();
        midpointT.transform.position = midpoint;
        followObject.position = new Vector3(midpointT.position.x + followXOffset, FindHeight(), midpointT.position.z);
    }

    float FindHeight()
    {
        pitchPercent = (furthestDistance - cameraPlayerDistanceFloor) / (cameraPlayerDistanceCeiling - cameraPlayerDistanceFloor);
        height = Mathf.Lerp(cameraYHeightFloor + midpointT.position.y, cameraYHeightCeiling + midpointT.position.y, pitchPercent);
        Debug.Log(height);
        //apply
        //height
        //cameraHeightSetter = cameraRef.transform.position;
        //cameraHeightSetter.y = cameraYOffset;
        //cameraRef.transform.position = cameraHeightSetter;
        //returns the y value for the follow object
        return height;
    }

    void FindMidpoint()
    {
        furthestDistance = 0;
        for (int i = 0; i < GameManager.S.playerList.Count; ++i)
        {
            for (int j = 0; j < GameManager.S.playerList.Count; ++j)
            {
                //Debug.Log(i + ", " + j);
                float distance = Vector3.Distance(GameManager.S.playerList[i].transform.position, GameManager.S.playerList[j].transform.position);
                //Debug.Log(distance);
                if (distance > furthestDistance)
                {
                    furthestPlayer1 = GameManager.S.playerList[i].transform.position;
                    furthestPlayer2 = GameManager.S.playerList[j].transform.position;
                    furthestDistance = Vector3.Distance(GameManager.S.playerList[i].transform.position, GameManager.S.playerList[j].transform.position);
                }
            }
        }
        //Debug.Log(furthestPlayer1 + ", " + furthestPlayer2);
        midpoint = (furthestPlayer1 + furthestPlayer2) / 2;
        //Debug.Log(midpoint);

        //find the midpoint between the active players
        //find for 4 players
        /*if (GameManager.S.playerList.Count == 4)
        {
            float p1p4Dist = Vector3.Distance(GameManager.S.playerList[0].transform.position, GameManager.S.playerList[3].transform.position);
            float p2p4Dist = Vector3.Distance(GameManager.S.playerList[1].transform.position, GameManager.S.playerList[3].transform.position);
            float p3p4Dist = Vector3.Distance(GameManager.S.playerList[2].transform.position, GameManager.S.playerList[3].transform.position);

            if (p1p4Dist > furthestDistance)
            {
                furthestDistance = p1p4Dist;
                furthestPlayer1 = GameManager.S.playerList[0].gameObject.transform.position;
                furthestPlayer2 = GameManager.S.playerList[3].gameObject.transform.position;
            }
            if (p2p4Dist > furthestDistance)
            {
                furthestDistance = p2p4Dist;
                furthestPlayer1 = GameManager.S.playerList[1].gameObject.transform.position;
                furthestPlayer2 = GameManager.S.playerList[3].gameObject.transform.position;
            }
            if (p3p4Dist > furthestDistance)
            {
                furthestDistance = p3p4Dist;
                furthestPlayer1 = GameManager.S.playerList[2].gameObject.transform.position;
                furthestPlayer2 = GameManager.S.playerList[3].gameObject.transform.position;
            }

            //find for 3 players
            
            }
        if (GameManager.S.playerList.Count == 3)
        {
            float p1p3Dist = Vector3.Distance(GameManager.S.playerList[0].transform.position, GameManager.S.playerList[2].transform.position);
            float p2p3Dist = Vector3.Distance(GameManager.S.playerList[1].transform.position, GameManager.S.playerList[2].transform.position);

            if (p1p3Dist > furthestDistance)
            {
                furthestDistance = p1p3Dist;
                furthestPlayer1 = GameManager.S.playerList[0].gameObject.transform.position;
                furthestPlayer2 = GameManager.S.playerList[2].gameObject.transform.position;
            }
            if (p2p3Dist > furthestDistance)
            {
                furthestDistance = p2p3Dist;
                furthestPlayer1 = GameManager.S.playerList[1].gameObject.transform.position;
                furthestPlayer2 = GameManager.S.playerList[2].gameObject.transform.position;
            }
            
        }
        //find for 2 players
        if (GameManager.S.playerList.Count == 2)
        {
            float p1p2Dist = Vector3.Distance(GameManager.S.playerList[0].transform.position, GameManager.S.playerList[3].transform.position);

            furthestPlayer1 = GameManager.S.playerList[0].gameObject.transform.position;
            furthestPlayer2 = GameManager.S.playerList[1].gameObject.transform.position;


        }*/


    }
}
