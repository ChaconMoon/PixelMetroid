using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efectoparadax : MonoBehaviour
{
    public float efectoParadax;
    private Transform cameraposicion;
    private Vector3 ultimaposicionCamera;
    // Start is called before the first frame update
    void Start()
    {
        cameraposicion = Camera.main.transform;
        ultimaposicionCamera = cameraposicion.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movinientoDeFondo = cameraposicion.position - ultimaposicionCamera;
        transform.position += new Vector3(movinientoDeFondo.x * efectoParadax,
            movinientoDeFondo.y * efectoParadax, 0);
        ultimaposicionCamera = cameraposicion.position;
    }
}
