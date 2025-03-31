using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_simple : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float spawnInterval = 3.0f; // Intervalo de tiempo
    public bool status_position;    //determina posición izq o der
    public Vector3 spawnPosition1; // Primera posición de spawn

    void Start()
    {
        // Iniciar
        InvokeRepeating("SpawnEnemy", 28.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Instanciar el enemigo en la posición seleccionada
        Instantiate(enemyPrefab, spawnPosition1, Quaternion.identity);
    }
    
}
