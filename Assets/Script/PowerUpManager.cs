using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject powerUpPrefab;
    public uint gapBetweenPowerUpsPix = 10;

    public GameObject[] powerUps;   // To delete
    public static GameObject gameManager() { return GameObject.FindWithTag(SaveData.GameManagerTag); }
    public int nbSecBetweenPowerUps = 5;
    public int numberOfPowerUps = 2;

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
            SpawnPowerUps();
            lastSpawned++;
        }
    }

    public void LoadFromJson()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("PowerUpList");
        allPowerUps = JsonUtility.FromJson<PowerUpList>(jsonTextFile.ToString());
    }
    private void SpawnPowerUps()
    {
        float N = numberOfPowerUps;
        float W = powerUpPrefab.GetComponent<RectTransform>().rect.width;
        float G = gapBetweenPowerUpsPix;
        float nextX = -((N / 2.0f)*W + G*(N - 1)/2.0f);
        PowerUp powerUpData;
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            if (i >= allPowerUps.Count())
                return;
            powerUpData = allPowerUps.GetElement(i);
            SpawnPowerUp(nextX, powerUpData);
            nextX += W + G;
        }
    }


    public void SpawnPowerUp(float x, PowerUp powerUpData)
    {
        timeSinceLastPowerUpSpawn = 0;
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
        center.x += x;
        GameObject powerUpUi = Instantiate(powerUpPrefab, center, Quaternion.identity, canvas.transform);

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
    }

    public void OnFirstPowerUpClicked()
    {
        PowerUp powerUpData = allPowerUps.GetElement(lastSpawned - 1);
        powerUps[0].SetActive(false);
        powerUps[1].SetActive(false);

        SaveData.gameManager().GetComponent<SaveData>().elementsSpawning.viralRNASpawnRatePerSec += 0.2f;
    }
    public void OnSecondPowerUpClicked()
    {
        PowerUp powerUpData = allPowerUps.GetElement(lastSpawned - 1);
        powerUps[0].SetActive(false);
        powerUps[1].SetActive(false);

        SaveData.gameManager().GetComponent<SaveData>().elementsSpawning.cellRNASpawnRatePerSec += 0.2f;
    }
}
