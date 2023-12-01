using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    public int desplazamiento;
    public string TipoMovinieto;

    private Vector3 posicionInicio;
    private bool direccionDestino;
    private int vidas = 4;
    private Vector3 posicionFinal;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        if (TipoMovinieto == "Cangrejo")
        {
            posicionFinal = new Vector2(posicionInicio.x + desplazamiento, posicionInicio.y);
        } else if (TipoMovinieto == "Pulpo"){
            posicionFinal = new Vector2(posicionInicio.x + desplazamiento, posicionInicio.y + (desplazamiento/2));
        }
        direccionDestino = true;
        Debug.Log(posicionInicio);
    }

    // Update is called once per frame
    void Update()
    {
        DesplazarEnemigo();
    }

    private void DesplazarEnemigo()
    {
        Vector3 posicionDestino = (direccionDestino) ? posicionFinal : posicionInicio;
        transform.position = Vector2.MoveTowards(transform.position,posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicionFinal)
        {
            direccionDestino = false;
        }
        if (transform.position == posicionInicio)
        {
            direccionDestino= true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<control_jugador>().QuitarVidar();
        }

        if (collision.gameObject.CompareTag("Disparo") && gameObject.name!= "Cangrejo Gigante")
        {
            Quitarvida();
            Destroy(collision.gameObject);
        }
    }
    private void Quitarvida()
    {
        vidas--;
        StartCoroutine(CambiarColor());
        if (vidas == 0) 
        {
            Destroy(gameObject);
        }
    }
    IEnumerator  CambiarColor()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.25f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
