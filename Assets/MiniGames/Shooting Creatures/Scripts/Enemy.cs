using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad;
    public float movimientoDuracion = 3.0f; // Duración del movimiento en segundos
    public float paradaDuracion = 2.0f; // Duración de la parada en segundos
    private bool isMoving = true;   
    private bool status_position;

    //para manejar las puntuaciones
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Iniciar el movimiento
        Invoke("Parar", movimientoDuracion);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.GetComponent<Animator>().SetBool("moving", true);


    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {


            // Movimiento hacia la derecha
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
    }

    void Parar()
    {
        isMoving = false; // Cambiar a detenido
        // Animacion no moviendose
        gameObject.GetComponent<Animator>().SetBool("moving", false);
        //detenido
        Invoke("Mover", paradaDuracion); // Reanudar el movimiento después de la duración de la parada
    }

    void Mover()
    {
        isMoving = true; // Cambiar a movimiento
        // Animacion moviendose
        gameObject.GetComponent<Animator>().SetBool("moving", true);
        //moviendo
        Invoke("Parar", movimientoDuracion); // Parar el movimiento después de la duración del movimiento

        

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
        //scoreControl.SetScore();
        gameManager.SetScore();
        Destroy(gameObject);
    }
}
