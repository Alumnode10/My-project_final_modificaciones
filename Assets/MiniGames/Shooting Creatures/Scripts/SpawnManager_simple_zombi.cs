using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_simple_zombi : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float spawnInterval = 5.0f; // Intervalo de tiempo
    public bool status_position;    // Determina posición izq o der
    public Vector3 spawnPosition1; // Primera posición de spawn

    void Start()
    {
        // Iniciar aparición después de 30 segundos y luego cada 5 segundos
        InvokeRepeating("SpawnEnemy", 30.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Instanciar el enemigo en la posición seleccionada
        Instantiate(enemyPrefab, spawnPosition1, Quaternion.identity);
    }
}

