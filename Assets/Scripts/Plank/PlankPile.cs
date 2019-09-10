using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankPile : MonoBehaviour
{
    //when player walks up and activates pick up plank if hits this

    //generates plank

    //gives plank to player

    public GameObject[] plankPrefab;

    [Header("Limited Number of Boards Variables")]
    [SerializeField]
    FloatVariable _amountOfBoardsAllowed;
    [SerializeField]
    FloatVariable _usedPlanks;

    public FloatVariable UsedPlanks { get => _usedPlanks; set => _usedPlanks = value; }

    private void Start()
    {
        _usedPlanks.Value = 0;
    }

    public GameObject GeneratePlank(Vector3 newPlankSpawnPosition, Quaternion newPlankSpawnRotation)
    {
        if (_usedPlanks.Value >= _amountOfBoardsAllowed.Value)
        {
            return null;
        }
        else
        {
            GameObject newlyBirthedPlank;

            newlyBirthedPlank = Instantiate(plankPrefab[Random.Range(0, plankPrefab.Length)], newPlankSpawnPosition, newPlankSpawnRotation);

            newlyBirthedPlank.GetComponent<PlankManager>().PickUpSpawn();

            _usedPlanks.Value++;

            return newlyBirthedPlank;
        }
    }

}
