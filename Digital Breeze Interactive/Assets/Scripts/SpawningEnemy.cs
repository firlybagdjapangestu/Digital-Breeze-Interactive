using System.Collections;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public GameObject kunaiPrefab; // Prefab Kunai
    public Transform leftSpawnPoint; // Posisi Spawn 1
    public Transform rightSpawnPoint2; // Posisi Spawn 2
    public float spawnInterval = 2f; // Waktu antar spawn

    void Start()
    {
        // Mulai spawning dengan interval waktu
        StartCoroutine(SpawnKunaiRoutine());
    }

    IEnumerator SpawnKunaiRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnKunai();
        }
    }

    void SpawnKunai()
    {
        // Pilih spawn point secara random
        Transform selectedSpawn = Random.value > 0.5f ? leftSpawnPoint : rightSpawnPoint2;

        if (kunaiPrefab != null && selectedSpawn != null)
        {
            Instantiate(kunaiPrefab, selectedSpawn.position, selectedSpawn.rotation);
        }
    }
}
