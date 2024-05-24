using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void CrearPartida(string sceneName)
    {
        StateNameController.servidor = "Host";
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void EntrarPartida(string sceneName)
    {
        StatePartida.arma2 = StatePartida.arma;
        StateNameController.servidor = "Client";
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void PartidaIA(string sceneName)
    {
        StatePartida.partida = "IA";
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void UIRegistro()
    {

    }
}
