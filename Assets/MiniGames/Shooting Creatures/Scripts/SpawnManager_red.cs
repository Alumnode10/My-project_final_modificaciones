using UnityEngine;

public class SpawnManager_red : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public float spawnInterval = 3.0f; // Intervalo de tiempo

    public bool status_position;    //determina posición izq o der
    public Vector3 spawnPosition1; // Primera posición de spawn
    public Vector3 spawnPosition2; // Segunda posición de spawn

    void Start()
    {
        // Iniciar
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        status_position = (Random.Range(0, 2) == 0);
        Debug.Log(status_position);
        Vector3 spawnPosition;

        if (status_position)
        {
            // Obtener posición SpawnManager
            spawnPosition = spawnPosition2;
        }
        else
        {
            // Obtener posición SpawnManager
            spawnPosition = spawnPosition1;
        }

        // Instanciar el enemigo en la posición seleccionada
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
