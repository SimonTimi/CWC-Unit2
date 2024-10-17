using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnCooldown = 3f;  // Time in seconds between spawns

    private float lastSpawnTime;      // Tracks the last time a dog was spawned

    void Start(){
        lastSpawnTime = -spawnCooldown; //player can spawn straight away
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastSpawnTime >= spawnCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSpawnTime = Time.time;  // Update the last spawn time to the current time
        }
    }
}
