using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    public int velocidad = 0;
    private GameObject jugador;

    private void Start()
    {
        StartCoroutine(destruir());
        jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador.GetComponent<control_jugador>().rotado)
        {
            velocidad = velocidad * -1;
        }
    }
    // Update is called once per frame
    void Update()
    { 
            transform.position = new Vector2(transform.position.x + velocidad * Time.deltaTime, transform.position.y);
    }
    IEnumerator destruir()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
