using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public string modeServidor;
    public Transform arma1Posicion;
    public Transform arma2Posicion;
    public Transform Player1Posicion;
    public Transform Player2Posicion;
    public NetworkConnect networkManager;
    public Transform posicionJugador1;
    public GameObject dragonSlayer;
    bool victoria = false;
    // Start is called before the first frame update
    void Start()
    {
        modeServidor = StateNameController.servidor;
        if (modeServidor.Equals("Host"))
        {
           
            networkManager.Create();
        } else if (modeServidor.Equals("Client"))
        {

            networkManager.Join();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatePartida.arma == 1)
        {
            print("Dragon slayer1");
            SpawnPrefab(dragonSlayer, arma1Posicion);
            StatePartida.arma = 0;
        }
        if (StatePartida.arma2 == 1)
        {
            print("Dragon slayer2");
            SpawnPrefab(dragonSlayer, arma2Posicion);
            StatePartida.arma2 = 0;
        }
        if (StatePartida.victoria != 0)
        {
            GoBack();
        }
    }

    void GoBack()
    {
        SceneManager.LoadScene("SalaEspera");
    }

    void SpawnPrefab(GameObject prefabToSpawn, Transform posicion)
    {
        // Instanciar el prefab en la posición y rotación deseada
        Instantiate(prefabToSpawn, posicion.position, Quaternion.identity);
    }
}
