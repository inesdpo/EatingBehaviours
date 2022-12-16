using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGraph : MonoBehaviour
{
    public GameObject spawnPosition;
    public GameObject objectPrefab;
    public int spawnInterval;
    public float noiseAmount;

    public int numberOfObjects;

    private int objectsSpawned = 0;
    private int timer = 0;

    void Start()
    {
        // Make sure that we already start by spawning the first object.
        timer = spawnInterval;
    }

    void FixedUpdate()
    {
        if (objectsSpawned < numberOfObjects)
        {
            // Check if it's time to spawn a new object.
            if (timer == spawnInterval)
            {
                // Calculate a random position around our spawn position.
                Vector3 randomPosition = spawnPosition.transform.position;
                randomPosition.x += Random.Range(noiseAmount * -1, noiseAmount);
                randomPosition.z += Random.Range(noiseAmount * -1, noiseAmount);

                // Spawn a new object.
                Instantiate(objectPrefab, randomPosition,
                    Quaternion.identity, spawnPosition.transform);

                // Count the new object that was spawned.
                objectsSpawned++;

                // Reset the timer for the next object.
                timer = 0;
            }
            else
            {
                // Increment the timer.
                timer++;
            }
        }
    }
}
