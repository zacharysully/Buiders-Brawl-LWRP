using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlankArrayData", menuName = "Plank Array Data", order = 2)]
public class PlankArrayData : ScriptableObject
{
    public GameObject[] plankPrefabs;
    [Tooltip("All floats in this array must add up to 100. This array must be the same size as the plankPrefab.")]
    public float[] percentages;
}
