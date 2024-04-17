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
        
    }

    void GoBack()
    {
        SceneManager.LoadScene("SalaEspera");
    }

    void SpawnPrefab(GameObject prefabToSpawn)
    {
        // Instanciar el prefab en la posición y rotación deseada
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
