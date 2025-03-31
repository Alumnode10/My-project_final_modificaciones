using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Translate_background : MonoBehaviour
{
    public float velocidad;
    public bool moviendo = true;
    public Cronometro cronometro; // Referencia al script Cronometro

    // Update is called once per frame
    void Update()
    {
            //Debug.Log(cronometro.time);

            
            if (cronometro.time <= 16 && cronometro.time >= 15.35) // Usa la variable time del cronometro
            {
                nextscreen();
                
                Debug.Log("El fondo se detiene después de 26 segundos.");
            }
            else
            {
                //Debug.Log("El fondo no se mueve.");
            }
    }

    public void nextscreen(){
        transform.Translate(Vector2.left * 0.63f);
    }
}
