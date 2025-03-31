using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("moving", false);
        Debug.Log("LA CAMARA VA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeMueve()
    {
        Debug.Log("se mueve camara");
        // Activar la animación "tiembla"
        gameObject.GetComponent<Animator>().SetBool("moving", true);
    }
    public void SePara()
    {
        // Desactivar la animación "tiembla"
        gameObject.GetComponent<Animator>().SetBool("moving", false);

    }
}
