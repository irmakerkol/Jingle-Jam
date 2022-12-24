using UnityEngine;

public class GrinchSpawner : MonoBehaviour
{
    // The Grinch prefab
    public GameObject grinchPrefab;

    // The time between Grinch spawns
    public float grinchSpawnInterval;

    // The time when the next Grinch will be spawned
    private float nextGrinchSpawnTime;

    private void Start()
    {
        // Set the initial time for the next Grinch spawn
        nextGrinchSpawnTime = Time.time + grinchSpawnInterval;
    }

    private void Update()
    {
        // Check if it is time to spawn the next Grinch
        if (Time.time >= nextGrinchSpawnTime)
        {
            // Instantiate a new Grinch object at the spawn position
            Instantiate(grinchPrefab, Vector3.zero, Quaternion.identity);

            // Set the time for the next Grinch spawn
            nextGrinchSpawnTime = Time.time + grinchSpawnInterval;
        }
    }
}
