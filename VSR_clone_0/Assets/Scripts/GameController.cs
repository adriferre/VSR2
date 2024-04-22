using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public string modeServidor;
    public NetworkConnect networkManager;
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
        
    }

    void GoBack()
    {
        SceneManager.LoadScene("SalaEspera");
    }
}
