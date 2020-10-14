using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;
    public Transform spawnPointBats;


    public float timeBetweenWaves;
    public float countdown;

    public Text waveCountdownText;
    public Text waveNumber;

    public int waveIndex = 0;
    GameManagerScript gameover;
    public int waveAmount;

    private bool isSpawning;

    public int przeciwniki;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        waveIndex = 0;
        countdown = 1.0f;
        enemiesAlive = 0;
        isSpawning = false;
        gameover = GameObject.Find("Game Master").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        przeciwniki = enemiesAlive;
        if (isSpawning == true)
        {
            return;
        }

        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameover.WinLevel();
        }

        if (BuildManager.instance.towersBuild <= 0)
        {
            return;
        }
        waveAmount = waveIndex + 1;

        if (countdown <= 0.1f)
        {
            
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            waveNumber.text = "Wave: " + waveAmount.ToString();
            waveCountdownText.text = "Next wave in: 0";
            return;          
        }
        

        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next wave in: " + Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        isSpawning = true;
        enemiesAlive = 0;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemiesCount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        isSpawning = false;
        waveIndex++;
    }

    void  SpawnEnemy(GameObject enemy)
    {
        enemiesAlive++;
        if (enemy.tag == "Bat")
        {
            Instantiate(enemy, spawnPointBats.position, spawnPointBats.rotation);
        }
        else
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
