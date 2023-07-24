using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int round;
    public int startRound;
    public int zombiesInRound;
    public int zombToRoundRatio = 5;
    public int zombiesSpawned;
    public int zombiesKilledThisRound;
    public int randomSpawnPoint;
    public float spawnWait = 5;

    public GameObject[] spawnLocations;
    public GameObject zombieObject;
    public UIManager uiManage;
    public CustomGame customGame;

    [SerializeField]
    float counter = 0;

    void Awake()
    {
        try
        {
            customGame = GameObject.Find("CustomGameSettings").GetComponent<CustomGame>();
        }
        catch (System.Exception)
        {
            customGame = new CustomGame();
        }

        if (customGame.isCustom && customGame.customStartRound > 1)
        {
            startRound = customGame.customStartRound;
        }
        else
        {
            startRound = 1;
        }

        if (customGame.isCustom && customGame.customZombRatio > 0)
        {
            zombToRoundRatio = customGame.customZombRatio;
        }
        else
        {
            zombToRoundRatio = 5;
        }
    }

    void Start()
    {
        uiManage = GetComponent<UIManager>();

        round = startRound - 1;
        zombiesSpawned = 0;
        zombiesKilledThisRound = 0;

        NewRound();
        Time.timeScale = 1f;
    }

    void Update()
    {
        ZombieManager();
    }

    public void ZombieManager()
    {
        if(zombiesSpawned < 25 && zombiesSpawned < zombiesInRound - zombiesKilledThisRound)
        {
            SpawnZombie();
        }

        if(zombiesKilledThisRound == zombiesInRound)
        {
            NewRound();
        }
    }

    void SpawnZombie()
    {
        if (counter < spawnWait)
        {
            counter += Time.deltaTime;
        }

        if(counter >= spawnWait)
        {
            randomSpawnPoint = Random.Range(0, spawnLocations.Length);

            if (spawnLocations[randomSpawnPoint].activeInHierarchy == false)
            {
                return;
            }
            else
            {
                zombiesSpawned++;
                Instantiate(zombieObject, spawnLocations[randomSpawnPoint].transform.position, Quaternion.identity);
            }

            counter = 0;
        }        
    }

    void NewRound()
    {
        round++;
        zombiesInRound = round * zombToRoundRatio;
        zombiesKilledThisRound = 0;
        uiManage.RoundUpdate();
        uiManage.ZombieUpdate();
    }
}
