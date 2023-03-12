using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpList allPowerUps = new PowerUpList();
    void Start()
    {
        LoadFromJson();
    }

    public void LoadFromJson()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("PowerUpList");
        allPowerUps = JsonUtility.FromJson<PowerUpList>(jsonTextFile.ToString());
    }
}
