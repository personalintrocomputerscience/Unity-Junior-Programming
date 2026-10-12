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

    // Start is called before the first frame update
    void Start()
    {
        // Use a single Invoke to kick off the custom random interval loop
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Safety check: ensure there are prefabs assigned in the inspector
        if (ballPrefabs.Length == 0) return;

        // FIX 1: Generate a random ball index instead of hardcoding 0
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // FIX 1: Instantiate the randomly selected ball
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        // FIX 2: Generate a random interval and schedule the next spawn dynamically
        float randomSpawnInterval = Random.Range(3.0f, 5.0f); // Adjust min/max values as needed
        Invoke("SpawnRandomBall", randomSpawnInterval);
    }
}