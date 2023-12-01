using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMeta : MonoBehaviour
{
    public Object nivelSiguiente;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(cambiarNivel());
        }
    }
    IEnumerator cambiarNivel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nivelSiguiente.name);
    }
}
