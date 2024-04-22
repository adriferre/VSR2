using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public string modeServidor;
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

        if (StatePartida.arma == 1)
        {
            print("arma2");
            SpawnPrefab(dragonSlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatePartida.victoria != 0)
        {
            GoBack();
        }
    }

    void GoBack()
    {
        SceneManager.LoadScene("SalaEspera");
    }

    void SpawnPrefab(GameObject prefabToSpawn)
    {
        // Instanciar el prefab en la posici�n y rotaci�n deseada
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
