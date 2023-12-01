using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TirarCangejo : MonoBehaviour
{
    public Object siguientenivel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            Collider2D collider2D = collision.GetComponent<Collider2D>();
            collider2D.isTrigger = true;
            StartCoroutine(siguienteNivel());
        }
    }
    IEnumerator siguienteNivel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(siguientenivel.name);
    }
}
