using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float timeBetweenWaves = 1f;
    private float countdown = 1f;
    private int waveIndex = 0;
    public GameObject spawnPoint;
    public GameObject[] spawnPoints = new GameObject[4];
    public GameObject[] turnTriggers = new GameObject[4];

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy()
    {
        int randSpawn = Random.Range(0, 3);
        spawnPoint = spawnPoints[randSpawn];
        GameObject newCar = (GameObject)Instantiate(carPrefab, spawnPoint.transform);

        CarMovement script = newCar.GetComponent<CarMovement>();
        script.spawnRoad = randSpawn;
        script.exitTrigger = turnTriggers[SetExitRoad(randSpawn)].name;
    }

    public int SetExitRoad(int entryRoad)
    {
        int exit = 0;
        List<int> roads = new List<int>();
       
        for (int i = 0; i < 4; i++)
        {
            if (i != entryRoad)
            {
                roads.Add(i);
            }
        }

        exit = roads[Random.Range(0, 3)];

        return exit;
    }
}
