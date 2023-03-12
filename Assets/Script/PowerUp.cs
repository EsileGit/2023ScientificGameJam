using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PowerUp 
{
    public string title;
    public string description;
    public string imagePath;
}

[System.Serializable]
public class PowerUpList
{
    public List<PowerUp> allPowerUps;

    public void Add(PowerUp item)
    {
        allPowerUps.Add(item);
    }
}
