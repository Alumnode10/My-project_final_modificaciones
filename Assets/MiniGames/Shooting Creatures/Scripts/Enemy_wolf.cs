using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Enemy_wolf : MonoBehaviour
{
    public float velocidad;

    private float tiempoTranscurrido = 0f;
    public float duracionMovimiento = 2.0f; // Duración en segundos

    //mover camara
    //public Animator cameraAnimator;

    //para manejar las puntuaciones
    private GameManager gameManager;
    private CameraMovement cameraMovement;

    public int pulsaciones=0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraMovement = GameObject.Find("CamaraNueva").GetComponent<CameraMovement>();
        cameraMovement.SeMueve();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoTranscurrido < duracionMovimiento)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            tiempoTranscurrido += Time.deltaTime;
        }
        else
        {
            // Movimiento finalizado
            //Debug.Log("Movimiento del enemigo completado");
        }
        
    }

    private void OnMouseDown() {
        //scoreControl.SetScore();
        //si pulsas 3 veces desaparece
        
        Debug.Log("mato wolf");
        gameManager.SetScore_Up5();
        
        matar(); 

    }

    public void matar() 
    {
        //PlayCameraAnimation();
        pulsaciones+=1;
        cameraMovement.SePara();
        if(pulsaciones>=3){
            
            Destroy(gameObject);
        }else{
            Debug.Log("malote pulsado"+ pulsaciones);
        }
        
    }

    /*public void PlayCameraAnimation()
    {
        
        cameraAnimator.Play("Animation_CamaraTiembla");
 
    }*/
    


}
