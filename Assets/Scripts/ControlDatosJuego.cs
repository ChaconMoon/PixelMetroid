using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlDatosJuego : MonoBehaviour
{
    private int puntuacion;
    private bool ganador;
    private int vidas = 5;

    public int Puntuacion { get =>  puntuacion; set => puntuacion = value; }
    public bool Ganador { get => ganador; set => ganador = value; }
    public int Vidas { get => vidas; set => vidas = value; }

    private void Awake()
    {
        int numIntancias = FindObjectsOfType<ControlDatosJuego>().Length;
        if (numIntancias != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
