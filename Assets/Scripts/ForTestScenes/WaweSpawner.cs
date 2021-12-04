using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject wavePrefab;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            GameObject wave = Instantiate(wavePrefab, transform);
            Destroy(wave, 7f);
            yield return new WaitForSeconds(timeToSpawn);
        }       
    }
}
