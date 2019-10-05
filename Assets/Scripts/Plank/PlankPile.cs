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

        _amountOfBoardsAllowed.Value = GameManager.S.playerList.Count - 1;
    }

    private void Update()
    {
        if (_usedPlanks.Value >= _amountOfBoardsAllowed.Value)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    //[SerializeField]
    //private PlankArrayData plankArray;
    private float previousPercentage = 0;
    private float randomNum;

    private void Update()
    {
        if (_usedPlanks.Value >= _amountOfBoardsAllowed.Value)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }
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
        //newlyBirthedPlank = Instantiate(DeterminePlankToSpawn(), newPlankSpawnPosition, newPlankSpawnRotation);
        
        newlyBirthedPlank.GetComponent<PlankManager>().PickUpSpawn();

            _usedPlanks.Value++;

            return newlyBirthedPlank;
        }
    }

    /*
    private GameObject DeterminePlankToSpawn()
    {
        previousPercentage = 0;
        randomNum = Random.Range(0, 100);
        Debug.Log(randomNum);

        for (int i = 0; i < plankPrefab.Length; i++)
        {
            if (randomNum < previousPercentage + plankArray.percentages[i])
            {
                //Spawn this board
                return plankArray.plankPrefabs[i];
            }
            previousPercentage += plankArray.percentages[i];
        }

        return plankArray.plankPrefabs[0];
    }
    */

}
