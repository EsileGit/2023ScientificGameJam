using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsSpawner : MonoBehaviour
{
    SaveData saveDataComponent;
    public GameObject viralRNAPrefab;
    public GameObject cellRNAPrefab;
    public GameObject SKIPrefab;
    public float maxRadiusSpawn;

    private float timeSinceLastViralSpawn = 0;
    private float timeSinceLastCellSpawn = 0;
    private float timeSinceLastSkiSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        saveDataComponent = GetComponent<SaveData>();
        saveDataComponent.LoadFromJson();

        SpawnViralRNA(saveDataComponent.elementsSpawning.viralRNAInitCount);
        SpawnCellRNA(saveDataComponent.elementsSpawning.cellRNAInitCount);
        SpawnSKI(saveDataComponent.elementsSpawning.skiInitCount);
    }

    // Update is called once per frame
    void Update()
    {
        _CheckSpawnNeeds();
    }


    public void SpawnSKI(int numberToSpawn)
    {
        timeSinceLastSkiSpawn = 0;
        Debug.Log("SpawnSKI " + numberToSpawn);
        for (int i = 0; i < numberToSpawn; i++)
        {
            _InstantiateWithinCell(SKIPrefab);
        }
    }
    public void SpawnCellRNA(int numberToSpawn)
    {
        timeSinceLastCellSpawn = 0;
        Debug.Log("SpawnCellRNA " + numberToSpawn);
        for (int i = 0; i < numberToSpawn; i++)
        {
            _InstantiateWithinCell(cellRNAPrefab);
        }
    }
    public void SpawnViralRNA(int numberToSpawn)
    {
        timeSinceLastViralSpawn = 0;
        Debug.Log("SpawnViralRNA " + numberToSpawn);
        for (int i = 0; i < numberToSpawn; i++)
        {
            _InstantiateWithinCell(viralRNAPrefab);
        }
    }

    private void _InstantiateWithinCell(GameObject objectToInstantiate)
    {
        Vector2 randomPosition = new Vector2(_GetRandNegative(), _GetRandNegative());
        randomPosition.Normalize();
        Vector2 spawnPosition = randomPosition* maxRadiusSpawn *_GetRand();

        Debug.Log("Trying to spawn at  " + randomPosition);
        GameObject gameobj = Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
        Debug.Log(gameobj.name + " has been spawned at " + randomPosition);
    }
    private float _GetRand()
    {
        return UnityEngine.Random.Range(0.0f, 1.0f);
    }
    private float _GetRandNegative()
    {
        return UnityEngine.Random.Range(-1.0f, 1.0f);
    }
    private void _CheckSpawnNeeds()
    {
        // Update timers
        timeSinceLastViralSpawn += Time.deltaTime;
        timeSinceLastCellSpawn += Time.deltaTime;
        timeSinceLastSkiSpawn += Time.deltaTime;

        if (saveDataComponent.elementsSpawning.skiSpawnRatePerSec * timeSinceLastSkiSpawn > 1)
        {
            SpawnSKI(1);
        }
        if (saveDataComponent.elementsSpawning.cellRNASpawnRatePerSec * timeSinceLastCellSpawn > 1)
        {
            SpawnCellRNA(1);
        }
        if (saveDataComponent.elementsSpawning.viralRNASpawnRatePerSec * timeSinceLastViralSpawn > 1)
        {
            SpawnViralRNA(1);
        }
    }
}
