using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;

    [Range(0, 20), SerializeField] private int minNumberOfSpawns = 0;
    [Range(0, 20), SerializeField] private int maxNumberOfSpawns = 0;
    [Range(0, 20), SerializeField] private float minDelayÂetweenSpawns = 0;
    [Range(0, 20), SerializeField] private float maxDelayÂetweenSpawns = 5;

    private void Start()
    {
        StartCoroutine(startSpawnCor());
    }

    public IEnumerator startSpawnCor()
    {
        for (int i = 0; i < Random.Range(minNumberOfSpawns, maxNumberOfSpawns); i++)
        {
            yield return new WaitForSeconds(Random.Range(minDelayÂetweenSpawns, maxDelayÂetweenSpawns));
            Instantiate(spawnerData.Prefabs[Random.Range(0, spawnerData.Prefabs.Count)], transform).transform.localPosition = Vector3.zero;
        }

        yield break;
    }
}
