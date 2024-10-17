using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    public float minSpawnTime = 3f;   // Minimum time between spawns (in seconds)
    public float maxSpawnTime = 5f;   // Maximum time between spawns (in seconds)

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning coroutine after a short delay
        Invoke("StartSpawning", startDelay);
    }

    void StartSpawning()
    {
        // Start the coroutine that spawns balls randomly
        StartCoroutine(SpawnRandomBall());
    }

    // Coroutine to spawn balls at random intervals
    IEnumerator SpawnRandomBall()
    {
        while (true)  // Continue to spawn indefinitely
        {
            // Generate random spawn position and random ball index
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            int ballIndex = Random.Range(0, ballPrefabs.Length);

            // Instantiate ball at random spawn location
            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

            // Wait for a random time between minSpawnTime and maxSpawnTime before spawning again
            float timeToWait = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
