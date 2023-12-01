using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPowerUP : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip powerUpClip;
    public int cantidad;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(powerUpClip);
            StartCoroutine(Destruir());
        }

        IEnumerator Destruir()
        {
            yield return new WaitForSeconds(0.25f);
            collision.gameObject.GetComponent<control_jugador>().AumentarPuntos(cantidad);
            Destroy(gameObject);
        }
    }
}
