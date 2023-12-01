using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control_jugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
    public int puntuacion = 0;
    public int numVidas = 0;
    public int tiempo = 0;
    public Canvas canvas;
    public AudioClip saltoAudio;
    public AudioClip vidaAudio;
    public bool rotado;





    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private Animator animacion;
    private bool vunerable = true;
    private ControlHUD hub;
    private int tiempoNivel =1000000;
    private int tiempoEmpleado;
    private int tiempoInicio;
    private bool isRun;
    private bool isShotting;
    private float ultimaPosX;
    private ControlDatosJuego controlDatosJuego;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();

        hub = canvas.GetComponent<ControlHUD>();
        controlDatosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        ultimaPosX = transform.position.x;
        numVidas = controlDatosJuego.Vidas;
        hub.SetVidasTXT(numVidas);

    }
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX*velocidad, fisica.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& TocarSuelo() /**Mathf.Abs (fisica.velocity.y) < 0.01f**/) 
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            audioSource.PlayOneShot(saltoAudio);
        }
        if (fisica.velocity.x > 0) { sprite.flipX = false; }
        else if (fisica.velocity.x < 0) { sprite.flipX = true; }
        tiempoEmpleado = (int)Time.timeSinceLevelLoad;
        if (tiempoNivel - tiempoEmpleado < 0) FinJuego();
        hub.SetObjetoTXT(GameObject.FindGameObjectsWithTag("PowerUp").Length);
        hub.SetTiempo(tiempoEmpleado);
        isRun = Input.GetAxis("Horizontal") != 0;
        isShotting = Input.GetButton("Fire1");
        rotado = sprite.flipX;

        AnimarJugador();

    }
    private void OnGUI()
    {
        GUILayout.TextArea(Input.GetButton("Fire1") + "");
    }
    private bool TocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.01f);
        return toca.collider !=null;
    }
    public void FinJuego()
    {
        controlDatosJuego.Ganador = false;
        SceneManager.LoadScene("FinJuego");
    }
    private void AnimarJugador()
    {
        animacion.SetBool("salto", !TocarSuelo());
        animacion.SetBool("correr", isRun);
        animacion.SetBool("Disparar", isShotting);
   
    }
    public void AumentarPuntos(int cantidad) 
    {
        puntuacion += cantidad;
        hub.SetObjetoTXT(cantidad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            QuitarVidar();
        }
        if (collision.CompareTag("KillPlayer"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void QuitarVidar() 
    {
        if (vunerable)
        {
            vunerable = false;
            numVidas--;
            hub.SetVidasTXT(numVidas);
            audioSource.PlayOneShot(vidaAudio);
            if (numVidas == 0)
                FinJuego();
            Invoke("HacerVunerable", 1f);
            sprite.color = Color.red;

        }    
    }
    private void HacerVunerable()
    {
        vunerable = true;
        sprite.color = Color.white;
    }
    private void GanarJuego()
    {
        puntuacion += (numVidas * 100) + (tiempoNivel - tiempoEmpleado);
        controlDatosJuego.Puntuacion = puntuacion;
        controlDatosJuego.Ganador = true;
        SceneManager.LoadScene("FinJuego");
    }
}
