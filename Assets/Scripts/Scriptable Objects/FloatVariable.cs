using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    float _value;

    public float Value { get => _value; set => _value = value; }
}
