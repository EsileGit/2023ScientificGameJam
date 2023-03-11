using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsSpawner : MonoBehaviour
{
    SaveData saveDataComponent;
    public GameObject viralRNAPrefab;
    public GameObject cellRNAPrefab;
    public GameObject SKIPrefab;
    public int maxRadiusSpawn;
    // Start is called before the first frame update
    void Start()
    {
        saveDataComponent = GetComponent<SaveData>();
        saveDataComponent.LoadFromJson();

        SpawnSKI(saveDataComponent.elementsSpawning.skiInitCount);
        SpawnViralRNA(saveDataComponent.elementsSpawning.viralRNAInitCount);
        SpawnCellRNA(saveDataComponent.elementsSpawning.cellRNAInitCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSKI(int numberToSpawn)
    {
        Debug.Log("SpawnSKI " + numberToSpawn);
        for (int i = 0; i < numberToSpawn; i++)
        {
            _InstantiateWithinCell(SKIPrefab);
        }
    }
    public void SpawnCellRNA(int numberToSpawn)
    {
        Debug.Log("SpawnCellRNA " + numberToSpawn);
        for (int i = 0; i < numberToSpawn; i++)
        {
            _InstantiateWithinCell(cellRNAPrefab);
        }
    }
    public void SpawnViralRNA(int numberToSpawn)
    {
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
        randomPosition = randomPosition* maxRadiusSpawn *_GetRand();

        GameObject newObject = Instantiate(objectToInstantiate, randomPosition, Quaternion.identity);
    }
    private float _GetRand()
    {
        return UnityEngine.Random.Range(0.0f, 1.0f);
    }
    private float _GetRandNegative()
    {
        return UnityEngine.Random.Range(-1.0f, 1.0f);
    }
}
