using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuente : MonoBehaviour
{
    public GameObject activador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disparo"))
        {
            activador.SetActive(true);
            foreach (GameObject trozoPuente in GameObject.FindGameObjectsWithTag("puente"))
            {
                Destroy(trozoPuente);
            }
        }
    }
}
