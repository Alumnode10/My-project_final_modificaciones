using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_simple_mouse : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float spawnInterval = 3.0f; // Intervalo de tiempo
    public bool status_position;    //determina posición izq o der
    public Vector3 spawnPosition1; // Primera posición de spawn

    public Cronometro cronometro; // Referencia al script Cronometro

    public float duracion_spawn=34;
    private bool spawnDetenido = false;

    void Start()
    {
        // Iniciar
        InvokeRepeating("SpawnEnemy", 3.0f, spawnInterval);
    }

    void Update()
    {
        //Debug.Log(cronometro.time);

        if (cronometro.time <= duracion_spawn && spawnDetenido==false) // Variable time del cronometro
        {
            CancelInvoke("SpawnEnemy");
            spawnDetenido=true;
                
            Debug.Log("Spawn se detiene después de X segundos.");
        }
        else
        {
                //Debug.Log("Funcionando");
        }
        
    }

    void SpawnEnemy()
    {
        // Instanciar el enemigo en la posición seleccionada
        Instantiate(enemyPrefab, spawnPosition1, Quaternion.identity);
    }
}
