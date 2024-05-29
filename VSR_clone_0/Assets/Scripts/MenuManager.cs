using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject CasoNoLogin;
    public GameObject CasoLogin;
    public GameObject CasoRegistro;
    public GameObject CasoEstadisticas;
    public GameObject CasoSiLogin;
    public GameObject botonCrearPartida;
    public GameObject botonUnirsePartida;

    public void UICasoRegistro()
    {
        CasoEstadisticas.SetActive(false);
        CasoSiLogin.SetActive(false);
        CasoLogin.SetActive(false);
        CasoNoLogin.SetActive(false);
        CasoRegistro.SetActive(true);
    }

    public void UICasoNoLogin()
    {   
        CasoEstadisticas.SetActive(false);
        CasoSiLogin.SetActive(false);
        CasoRegistro.SetActive(false);
        CasoLogin.SetActive(false);
        CasoNoLogin.SetActive(true);
        botonCrearPartida.SetActive(false);
        botonUnirsePartida.SetActive(false);
    }

    public void UISiLogin()
    {
        CasoEstadisticas.SetActive(false);
        CasoLogin.SetActive(false);
        CasoNoLogin.SetActive(false);
        CasoRegistro.SetActive(false);
        CasoSiLogin.SetActive(true);
        botonCrearPartida.SetActive(true);
        botonUnirsePartida.SetActive(true);
    }

    public void UICasoLogin()
    {
        CasoEstadisticas.SetActive(false);
        CasoNoLogin.SetActive(false);
        CasoRegistro.SetActive(false);
        CasoSiLogin.SetActive(false);
        CasoLogin.SetActive(true);
    }

    public void UICasoEstadisticas()
    {
        CasoNoLogin.SetActive(false);
        CasoRegistro.SetActive(false);
        CasoSiLogin.SetActive(false);
        CasoLogin.SetActive(false);
        CasoEstadisticas.SetActive(true);
        botonCrearPartida.SetActive(true);
        botonUnirsePartida.SetActive(true);
    }
}

