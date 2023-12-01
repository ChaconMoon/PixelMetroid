using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI tiempoTxt;
    public TextMeshProUGUI objetosTxt;

    public void SetVidasTXT(int vidas)
    {
        vidasTxt.text = "Vidas: " + vidas;
    }
    public void SetTiempo(int tiempo)
    {
        int segundos = tiempo % 60;
        int minutos = tiempo / 60;
        tiempoTxt.text = "Tiempo:" + minutos.ToString("00") + ":" + segundos.ToString("00");
    }
    public void SetObjetoTXT(int cuantos)
    {
        objetosTxt.text = "Objetos:" + cuantos.ToString();
    }
    void Update()
    {

    }
}
