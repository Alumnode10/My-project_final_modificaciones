using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_comiendo : MonoBehaviour
{
    //para manejar las puntuaciones
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Destruir objeto después X seg
        Destroy(gameObject, 23.5f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnMouseDown()
    {
        //scoreControl.SetScore();
        gameManager.SetScore();
        Destroy(gameObject);
    }
}
