using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour
{
    public Object nivelInicio;
    public Object Creditos;
    public Object Menu;
    public void OnButtonJugar()
    {
        SceneManager.LoadScene(nivelInicio.name);

    }
    public void OnButtonCreditos()
    {
        SceneManager.LoadScene(Creditos.name);
    }
    public void OnButtonClose()
    {
        Application.Quit();
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(Menu.name);
    }
}
