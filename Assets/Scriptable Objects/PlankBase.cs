using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlankBase", menuName = "Plank Base", order = 1)]
public class PlankBase : ScriptableObject
{
    [Tooltip("The movement of the player while holding this plank")]
    [SerializeField]
    private float playerMovementSpeed;

    public float PlayerMovementSpeed
    {
        get
        {
            return playerMovementSpeed;
        }
    }

    [Tooltip("The amount of points earned for placing this plank type")]
    [SerializeField]
    private int pointsForPlace;

    public int PointsForPlace
    {
        get
        {
            return pointsForPlace;
        }
    }
}
