using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    private Main _main;
    private float nextSpawnTime;
    private float spawnDelay = 7.0f;
    public GameObject[] SpawnObjects;

    private void Start()
    {
        _main = GameObject.FindObjectOfType<Main>();
    }

    // This script will simply instantiate the Prefab when the game starts.
    void Update()
    {
        if (ShouldSpawn() && !Main.isGameOver)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        nextSpawnTime = Time.time + spawnDelay / Main.movementSpeed;
        int RandomOption = Random.Range(0, Main.itemsSpawnRange);

        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(SpawnObjects[RandomOption], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
