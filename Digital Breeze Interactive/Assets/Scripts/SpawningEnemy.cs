using System.Collections;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public GameObject kunaiPrefab; // Prefab Kunai
    public GameObject zombiePrefab; // Prefab Zombie
    public Transform leftSpawnPoint; // Posisi Spawn 1
    public Transform rightSpawnPoint2; // Posisi Spawn 2
    public float spawnInterval = 2f; // Waktu antar spawn
    public float kunaiYOffset = -1f; // Offset Y untuk Kunai

    void Start()
    {
        // Mulai spawning dengan interval waktu
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Pilih spawn point secara random
        Transform selectedSpawn = Random.value > 0.5f ? leftSpawnPoint : rightSpawnPoint2;

        if (selectedSpawn != null)
        {
            // Pilih objek yang akan di-spawn secara random
            GameObject prefabToSpawn = Random.value > 0.5f ? kunaiPrefab : zombiePrefab;

            if (prefabToSpawn != null)
            {
                Vector3 spawnPosition = selectedSpawn.position;
                if (prefabToSpawn == kunaiPrefab)
                {
                    spawnPosition.y += kunaiYOffset;
                }
                Instantiate(prefabToSpawn, spawnPosition, selectedSpawn.rotation);
            }
        }
    }
}
