using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject powerUpPrefab;
    public GameObject[] powerUps;
    public static GameObject gameManager() { return GameObject.FindWithTag(SaveData.GameManagerTag); }
    public int nbSecBetweenPowerUps = 5;

    [SerializeField] private PowerUpList allPowerUps = new PowerUpList();
    private float timeSinceLastPowerUpSpawn = 0;
    private int lastSpawned = 0;
    private GameObject choiceOne;
    private GameObject choiceTwo;

    void Start()
    {
        LoadFromJson();
        powerUps = GameObject.FindGameObjectsWithTag("PowerUpUi");
        foreach(var obj in powerUps)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        timeSinceLastPowerUpSpawn += Time.deltaTime;
        if (timeSinceLastPowerUpSpawn > nbSecBetweenPowerUps)
        {
            SpawnFirstPowerUp();
            SpawnSecondPowerUp();
            lastSpawned++;
        }
    }

    public void LoadFromJson()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("PowerUpList");
        allPowerUps = JsonUtility.FromJson<PowerUpList>(jsonTextFile.ToString());
    }

    private void SpawnFirstPowerUp()
    {
        SpawnPowerUp(powerUps[0], 0);
    }
    private void SpawnSecondPowerUp()
    {
        SpawnPowerUp(powerUps[1], 1);
    }

    public void SpawnPowerUp(GameObject objUI, int index)
    {
        timeSinceLastPowerUpSpawn = 0;
        if (index >= allPowerUps.Count())
            return;
        PowerUp powerUpData = allPowerUps.GetElement(index);
        if (powerUpData == null)
            return;

        objUI.SetActive(true);
        GameObject powerUpUi = objUI;//Instantiate(powerUpPrefab, new Vector2(500, 344), Quaternion.identity, canvas.transform);

        // Image
        int rootIndex = 0;
        Transform childTransform = powerUpUi.transform.GetChild(0 + rootIndex);
        Image image = childTransform.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>(powerUpData.imagePath);
        // DEscription
        Transform descriptionTransform = powerUpUi.transform.GetChild(1 + rootIndex);
        TMPro.TextMeshProUGUI textDescription = descriptionTransform.GetComponent<TMPro.TextMeshProUGUI>();
        textDescription.text = powerUpData.description;
        // Title
        Transform titleTransform = powerUpUi.transform.GetChild(2 + rootIndex);
        TMPro.TextMeshProUGUI textTitle = titleTransform.GetComponent<TMPro.TextMeshProUGUI>();
        textTitle.text = powerUpData.title;

        choiceOne = powerUpUi;
    }

    public void OnFirstPowerUpClicked()
    {
        PowerUp powerUpData = allPowerUps.GetElement(lastSpawned - 1);
        powerUps[0].SetActive(false);
    }
    public void OnSecondPowerUpClicked()
    {
        PowerUp powerUpData = allPowerUps.GetElement(lastSpawned - 1);
        powerUps[1].SetActive(false);
    }
}
