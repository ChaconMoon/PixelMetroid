using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlFinNivel : MonoBehaviour
{
    public TextMeshProUGUI mensajeFinalTexto;
    public ControlDatosJuego controlDatosJuego;
    // Start is called before the first frame update
    void Start()
    {
        controlDatosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        string mensajeFinal = (controlDatosJuego.Ganador) ? "HAS GANADO" : "HAS PERDIDO";
        if (controlDatosJuego.Ganador)
        {
            mensajeFinal += "Puntuacion" + controlDatosJuego.Puntuacion;
        }
    }
}
