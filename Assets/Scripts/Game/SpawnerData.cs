using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SlotsIcon", order = 1)]
public class SpawnerData : ScriptableObject
{
    [SerializeField] private List<GameObject> prefabs;

    public List<GameObject> Prefabs { get => prefabs; private set => prefabs = value; }
}
