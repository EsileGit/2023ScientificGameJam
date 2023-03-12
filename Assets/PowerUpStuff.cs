using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStuff : MonoBehaviour
{
    public void OnFirstImgeClicked()
    {
        SaveData.gameManager().GetComponent<PowerUpManager>().OnFirstPowerUpClicked();
    }
    public void OnSecondImgeClicked()
    {
        SaveData.gameManager().GetComponent<PowerUpManager>().OnSecondPowerUpClicked();
    }
}
