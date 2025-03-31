using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Enemy2_updown : MonoBehaviour
{
    public float zigzagSpeed = 2.0f;
    public float zigzagFrequency = 2.0f;
    private float zigzagTimer = 0.0f;       //para reiniciar luego el temporizador

    //public TextMeshProUGUI texto;




    private int vidas=3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // movimiento en zigzag
        zigzagTimer += Time.deltaTime;
        if (zigzagTimer >= zigzagFrequency)
        {
            zigzagSpeed = -zigzagSpeed; // Cambia la dirección del movimiento en zigzag
            zigzagTimer = 0.0f; // Reinicia el temporizador
        }

        // aplicamos movimiento en zigzag
        transform.Translate(Vector2.up * zigzagSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bloque"))
        {
            Destroy(gameObject);
            
        }
    }
}
