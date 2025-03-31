using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{

    public float time = 50f;
    public TextMeshProUGUI time_text;

    private float font_size = 48f; // Tamaño inicial de la fuente
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60; 

        time=50;
    }

    // Update is called once per frame
    void Update()
    {

        time_text.fontSize = font_size;

        // Controlamos el contador
        time-= Time.deltaTime;
        time_text.text=Mathf.FloorToInt(time).ToString();

        // Controlamos el color
        if(time<10){
            time_text.color = Color.red;
        }
        
        // Controlamos el tamaño
        

        if(time_text.fontSize==font_size){
            InvokeRepeating("ReduceFontSize", 0f, 0.02f); // Llama al método ReduceFontSize cada 20 milisegundos

        }
        /*
        if (time <= 0)
        {
            CancelInvoke("ReduceFontSize"); // Detener la invocación repetida cuando el tiempo llegue a 0
            fontSize = originalFontSize; // Restablecer el tamaño de la fuente al valor original
            timeText.fontSize = fontSize; // Actualizar el tamaño de la fuente
        }
        
        InvokeRepeating("ReduceFontSize", 0f, 0.01f); // Llama al método ReduceFontSize cada 10 milisegundos
        */
    }

    public void ReduceFontSize()
    {
            time_text.fontSize -= 1f; // Actualizar el tamaño de la fuente
        
    }
}
