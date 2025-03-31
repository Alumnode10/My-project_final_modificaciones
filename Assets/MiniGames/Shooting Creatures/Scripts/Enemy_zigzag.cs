using UnityEngine;

public class Enemy_zigzag : MonoBehaviour
{
    public float velocidad;
    public float zigzagSpeed = 1.0f;
    public float zigzagFrequency = 3.0f;  // Aumentamos la frecuencia para un zigzag más largo
    private float zigzagTimer = 0.0f;

    private bool status_position;

    //para manejar las puntuaciones
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Determinar la dirección al inicio
        status_position = transform.position == FindObjectOfType<SpawnManager_red>().spawnPosition2;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status_position)
        {
            // Movimiento hacia la derecha
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            //Debug.Log("derecha");
        }
        else
        {
            // Movimiento hacia la izquierda
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            //Debug.Log("izq");
        }

        // Movimiento en zigzag
        zigzagTimer += Time.deltaTime;
        if (zigzagTimer >= zigzagFrequency)
        {
            zigzagSpeed = -zigzagSpeed;  // Cambia la dirección del movimiento en zigzag
            zigzagTimer = 0.0f;  // Reinicia el temporizador
        }

        // Aplicamos movimiento en zigzag
        transform.Translate(Vector2.up * zigzagSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bloque"))
        {
            Destroy(gameObject);
            
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("mato murciaelago");
        
        gameManager.SetScore_Up2();
        Destroy(gameObject);
    }
}
