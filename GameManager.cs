using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI carrotText;
    public float carrots;

    Vector3 farmCenter = new Vector3(8.65999985f, 0.192000002f, 4.44000006f);
    public GameObject bunny;
    public GameObject bossBunny;
    private GameObject instantiatedBoss;
    public int totalBunniesSpawned;
    public int bunniesFed;
    public TextMeshProUGUI bunniesFedUI;
    public int missedBunnies =0;
    public TextMeshProUGUI missedBunniesUI;

    public float timeRemaining = 0.0f;

    public int wave = 1;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCarrots(0);
        StartWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        bunniesFedUI.text = bunniesFed + "/" + totalBunniesSpawned;
        //SpawnBunnies(1);

        NextWave();
    }
    public void UpdateCarrots(float carrotsToAdd)
    {
        carrots += carrotsToAdd;
        carrotText.text = "" + carrots;
    }
    IEnumerator SpawnBunnies(int numberOfBunnies)
    {
        for (int i = 0; i < numberOfBunnies; i++)
        {


            float circumference = 2 * Mathf.PI * Random.Range(0f, 10f);

            float vertical = Mathf.Sin(circumference);
            float horizontal = Mathf.Cos(circumference);

            Vector3 spawnDir = new Vector3(horizontal, 0, vertical);

            Vector3 spawnPos = farmCenter + spawnDir * 30;

            Instantiate(bunny, spawnPos, Quaternion.identity);
            totalBunniesSpawned++;

            yield return new WaitForSeconds(10);
        }

    }
    void StartWave(int wave)
    {
        waveText.text = "Wave: " + wave;
        for (int i = 0; i < wave; i++)
        {


            StartCoroutine(SpawnBunnies(2*wave));
        }
        
        
    }
    void NextWave()
    {
        if (totalBunniesSpawned == 2)
        {
            wave++;
            StartWave(wave);
        }
        if (totalBunniesSpawned == 10)
        {
            wave++;
            StartWave(wave);
        }
        if (totalBunniesSpawned == 28)
        {
            wave++;
            StartWave(wave);
        }
        if (totalBunniesSpawned == 60)
        {
            wave++;
            StartWave(wave);
        }
        if (totalBunniesSpawned == 110)
        {
            
            SpawnBoss();
            waveText.text = "Wave: BOSS!";
        }
        if (totalBunniesSpawned == 111 && instantiatedBoss == null)
        {
            
            gameOverUI.gameObject.SetActive(true);
            missedBunniesUI.text = "You missed " + missedBunnies + " bunnies!";
            missedBunniesUI.gameObject.SetActive(true);
        }
    }
    void SpawnBoss()
    {
        


            float circumference = 2 * Mathf.PI * Random.Range(0f, 10f);

            float vertical = Mathf.Sin(circumference);
            float horizontal = Mathf.Cos(circumference);

            Vector3 spawnDir = new Vector3(horizontal, 0, vertical);

            Vector3 spawnPos = farmCenter + spawnDir * 30;

            instantiatedBoss = Instantiate(bossBunny, spawnPos, Quaternion.identity);
            totalBunniesSpawned++;

            
        

    }

}
