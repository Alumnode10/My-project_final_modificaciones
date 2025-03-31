using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public PlayerInput playerInput;    //PlayerInput
    public float velocidad = 10.0f;     //Velocidad del puntero
    public Vector2 limitesX = new Vector2(-8f, 8f); //Limites horizontales
    public Vector2 limitesY = new Vector2(-4f, 4f); //Limites verticales

    private Vector2 movimiento;        //Vector del input para el movimiento
    private GameObject objetoActual;   //Objeto que el puntero está tocando
    //para manejar las puntuaciones
    private GameManager gameManager;

    //Manejar audios
    public AudioClip[] audioClips; // Lista de AudioSources

    private AudioSource audioSource;

    //particulas
    [SerializeField] private GameObject particle_sys;   //particulas para cuando son destruidos los enemigos

    private CameraMovement cameraMovement;  //manejos de camara

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraMovement = GameObject.Find("CamaraNueva").GetComponent<CameraMovement>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Cargo acciones de movimiento del Input System
        movimiento = playerInput.actions["movimiento"].ReadValue<Vector2>();

        // Calculo nueva pos basada en el movimiento
        Vector3 nuevaPosicion = transform.position + new Vector3(movimiento.x, movimiento.y, 0) * velocidad * Time.deltaTime;

        // Limito la posición dentro de los límites definidos
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limitesX.x, limitesX.y);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, limitesY.x, limitesY.y);

        // Asigno nueva posición del puntero
        transform.position = nuevaPosicion;

        if (movimiento.x>0f){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400.0f*Time.deltaTime,0.0f));
        }

        // Detecto el botón de interacción
        if (playerInput.actions["salto"].WasPressedThisFrame() || Input.GetKeyDown(KeyCode.Space))//&& objetoActual != null
        {
            /*Debug.Log("destruido");
            Destroy(objetoActual); // Destruir objeto tocado
            //Debug.Log($"{objetoActual.name} destruido por el puntero.");
            //objetoActual = null; // Limpiar la referencia
            */

            //Matar al enemigo y sumar puntos al Score
            if (objetoActual.gameObject.CompareTag("bat"))
            {
                gameManager.SetScore_Up2();
                audioSource.clip = audioClips[0];
                audioSource.Play();

                // Acceder al sistema de partículas hijo y activarlo
                /*Transform sistemaParticulas = objetoActual.transform.Find("Particle_System"); // Reemplaza "NombreDelHijo" con el nombre del objeto hijo
                sistemaParticulas.gameObject.SetActive(true); // Activa el sistema de partículas
                */

                InstanciarParticulas(); //Instanciar partículas
                Destroy(objetoActual); //destruye enemigo

            }else if (objetoActual.gameObject.CompareTag("ghost"))
            {
                gameManager.SetScore_Up2();
                audioSource.clip = audioClips[4];
                audioSource.Play();

                InstanciarParticulas(); //Instanciar partículas
                Destroy(objetoActual); //destruye enemigo
                
            }else if(objetoActual.gameObject.CompareTag("mouse")){
                gameManager.SetScore();
                audioSource.clip = audioClips[2];
                audioSource.Play();

                InstanciarParticulas(); //Instanciar partículas
                Destroy(objetoActual); //destruye enemigo

            }else if(objetoActual.gameObject.CompareTag("zombi")){
                gameManager.SetScore();
                audioSource.clip = audioClips[3];

                InstanciarParticulas(); //Instanciar partículas
                Destroy(objetoActual); //destruye enemigo

            }else if(objetoActual.gameObject.CompareTag("daemon")){
                gameManager.SetScore_Up5();
                audioSource.clip = audioClips[1];
                audioSource.Play();

                InstanciarParticulas(); //Instanciar partículas
                cameraMovement.SePara();
                Destroy(objetoActual); //destruye enemigo

            }else{
                audioSource.clip = audioClips[5];
                audioSource.Play();
                Debug.Log("have a good time");

            }
        }

    }

        // Detectar colisiones con otros objetos
    void OnTriggerEnter2D(Collider2D other)
    {
        // Registrar objeto con el que se entra en contacto
        objetoActual = other.gameObject;
        Debug.Log($"El puntero está tocando: {objetoActual.name}");
    }

    public void InstanciarParticulas(){
        GameObject particulas = Instantiate(particle_sys, objetoActual.transform.position, objetoActual.transform.rotation);
    }


}

