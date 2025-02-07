using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiBehaviour : MonoBehaviour
{
    public float speed = 5f; // Kecepatan kunai
    public float destroyTime = 3f; // Waktu sebelum kunai dihancurkan
    private Vector2 direction; // Arah kunai

    void Start()
    {
        // Mencari player berdasarkan tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Cek arah player hanya sekali
            if (player.transform.position.x < transform.position.x)
            {
                direction = Vector2.left; // Player di kiri, kunai bergerak ke kiri
                transform.localScale = new Vector3(-1, 1, 1); // Hadap kiri
            }
            else
            {
                direction = Vector2.right; // Player di kanan, kunai bergerak ke kanan
                transform.localScale = new Vector3(1, 1, 1); // Hadap kanan
            }
        }
        else
        {
            direction = Vector2.right; // Default jika player tidak ditemukan
            transform.localScale = new Vector3(1, 1, 1); // Default hadap kanan
        }

        // Hancurkan kunai setelah beberapa detik
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // Gerakkan kunai ke arah yang sudah ditentukan
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Hancurkan kunai jika menyentuh player
        }
    }
}
