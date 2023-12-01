using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Control_Final_Boss : MonoBehaviour
{
    public GameObject minions;
    public GameObject meta;

    private int vida = 4;
    private bool vunerable = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disparo")) 
        {
            Destroy(collision.gameObject);
            if (vunerable)
            {
                vida--;
                if (vida == 0)
                {
                    meta.SetActive(true);
                    Destroy(gameObject);

                } else
                {
                    vunerable = false;
                    foreach (GameObject Puente in GameObject.FindGameObjectsWithTag("puente"))
                    {
                        Puente.SetActive(false);
                    }
                    Instantiate(minions, new Vector3(7, 0, transform.position.z), Quaternion.identity);
                    Instantiate(minions, new Vector3(3, 0, transform.position.z), Quaternion.identity);
                    Instantiate(minions, new Vector3(-1, 0, transform.position.z), Quaternion.identity);
                    Instantiate(minions, new Vector3(-4, 0, transform.position.z), Quaternion.identity);
                }
            }

        
        }
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Minion").Length == 0) {

            vunerable = true;
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        } else { 
            vunerable = false;
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        }
    }
}
