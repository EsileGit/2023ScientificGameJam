using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static string GameManagerTag = "GameManager";

    [SerializeField] public ScoringEvaluation scoring = new ScoringEvaluation();
    [SerializeField] public SpawningData elementsSpawning = new SpawningData();

    public static GameObject gameManager() { return GameObject.FindWithTag(SaveData.GameManagerTag); }
    public void SaveIntoJson()
    {
        //Debug.Log("SAVE Application.streamingAssetsPath : " + Application.streamingAssetsPath);
        string scoringStr = JsonUtility.ToJson(scoring);
        File.WriteAllText(Application.streamingAssetsPath + "/ScoringEvaluation.json", scoringStr);

        File.WriteAllText(Application.streamingAssetsPath + "/ElementsSpawning.json", JsonUtility.ToJson(elementsSpawning));
    }
    public void LoadFromJson()
    {
        //Debug.Log("LOAD Application.streamingAssetsPath : " + Application.streamingAssetsPath);
        string jsonContent = File.ReadAllText(Application.streamingAssetsPath + "/ScoringEvaluation.json");
        scoring = JsonUtility.FromJson<ScoringEvaluation>(jsonContent);

        jsonContent = File.ReadAllText(Application.streamingAssetsPath + "/ElementsSpawning.json");
        elementsSpawning = JsonUtility.FromJson<SpawningData>(jsonContent);
    }
}


[System.Serializable]
public class ScoringEvaluation
{
    public int pointsPerViralRNAPerSec;
}

[System.Serializable]
public class SpawningData
{
    public int viralRNAInitCount;
    public int cellRNAInitCount;
    public int skiInitCount;

    public int viralRNASpawnRatePerSec;
    public int cellRNASpawnRatePerSec;
    public int skiSpawnRatePerSec;

    public float nbSkiImmunitySec;
}
