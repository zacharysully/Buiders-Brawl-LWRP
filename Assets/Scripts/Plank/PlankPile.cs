using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankPile : MonoBehaviour
{
    //when player walks up and activates pick up plank if hits this

    //generates plank

    //gives plank to player
    [SerializeField]
    private GameObject[] plankPrefab;
    [Tooltip("All floats in this array must add up to 100. This array must be the same size as the plankPrefab.")]
    [SerializeField]
    private float[] percentages;
    private float previousPercentage = 0;

    public GameObject GeneratePlank(Vector3 newPlankSpawnPosition, Quaternion newPlankSpawnRotation)
    {
        GameObject newlyBirthedPlank;

        newlyBirthedPlank = Instantiate(plankPrefab[Random.Range(0, plankPrefab.Length)], newPlankSpawnPosition, newPlankSpawnRotation);

        newlyBirthedPlank.GetComponent<PlankManager>().PickUpSpawn();

        return newlyBirthedPlank;
    }

    private void DeterminePlankToSpawn()
    {
        /*
         * small: 40, medium: 30, large: 30
         * 
         * num < 40 = small
         * else if
         * num < 40 + 30 = Medium
         * else if
         * num < 40 + 30 + 30 = Large
         * 
         * previousPercentage = 0
         * 
         * for(i - 0; i < boards.length; i++)
         * {
         * if (num < previousPercentage + percentages[i]
         * {
         * SpawnBoard(_boards[i]);
         * previousPercentage += percentages[i];
         * }
         * }
         * 
         * Gameobject boards [9]
         * float[9] percentages = 100;
         */
    }

}
