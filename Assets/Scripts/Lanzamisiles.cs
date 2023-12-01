using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamisiles : MonoBehaviour
{
    public GameObject municion;

    private bool municionActive = true;
    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<control_jugador>().rotado==false)
        {
            transform.localPosition = new Vector2(0.775f,0.09f);
        }
        if (GetComponentInParent<control_jugador>().rotado == true) 
        {
            transform.localPosition = new Vector2(-0.775f, 0.09f);
        }
        if (Input.GetButton("Fire1") && municionActive)
        {
            Instantiate(municion, transform.position, Quaternion.identity);
            StartCoroutine(Cooldown());
        }
        IEnumerator Cooldown ()
        {
            municionActive = false;
            yield return new WaitForSeconds(0.3f);
            municionActive = true;
        }
    }
}
