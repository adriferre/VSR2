using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public string modeServidor;
    public GameObject jugadorPrefab;
    public Transform arma1Posicion;
    public Transform arma2Posicion;
    public Transform Player1Posicion;
    public Transform Player2Posicion;
    public NetworkConnect networkManager;
    public Transform posicionJugador1;
    public GameObject dragonSlayer, frostmourne, axe, scythe, scepter, dagger, swordfish;
    public GameObject IAEnemigo;
    bool victoria = false;
    // Start is called before the first frame update
    void Start()
    {
        modeServidor = StateNameController.servidor;
        StatePartida.partida = "Prueba";
        modeServidor = "Prueba";
        if (!StatePartida.partida.Equals("IA"))
        {
            IAEnemigo.SetActive(false);
            if (modeServidor.Equals("Host"))
            {

                networkManager.Create();
            }
            else if (modeServidor.Equals("Client"))
            {

                networkManager.Join();
            }
        } else
        {
            //Spawnear enemigo
            SpawnPrefab(jugadorPrefab, Player1Posicion);
            //SpawnPrefab(IAEnemigo, Player2Posicion);
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
        else if(StatePartida.arma == 2) 
        {
            print("frostmourne");
            SpawnPrefab(frostmourne, arma1Posicion);
            StatePartida.arma = 0;
        }
        else if (StatePartida.arma == 3)
        {
            print("axe");
            SpawnPrefab(axe, arma1Posicion);
            StatePartida.arma = 0;
        }
        else if (StatePartida.arma == 4)
        {
            print("scythe");
            SpawnPrefab(scythe, arma1Posicion);
            StatePartida.arma = 0;
        }
        else if (StatePartida.arma == 5)
        {
            print("scepter");
            SpawnPrefab(scepter, arma1Posicion);
            StatePartida.arma = 0;
        }
        else if (StatePartida.arma == 6)
        {
            print("dagger");
            SpawnPrefab(dagger, arma1Posicion);
            StatePartida.arma = 0;
        }
        else if (StatePartida.arma == 7)
        {
            print("swordfish");
            SpawnPrefab(swordfish, arma1Posicion);
            StatePartida.arma = 0;
        }

        if (StatePartida.arma2 == 1)
        {
            print("Dragon slayer2");
            SpawnPrefab(dragonSlayer, arma2Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }
        else if (StatePartida.arma2 == 2)
        {
            print("frostmourne");
            SpawnPrefab(frostmourne, arma1Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }
        else if (StatePartida.arma2 == 3)
        {
            print("axe");
            SpawnPrefab(axe, arma1Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }
        else if (StatePartida.arma2 == 4)
        {
            print("scythe");
            SpawnPrefab(scythe, arma1Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }
        else if (StatePartida.arma2 == 5)
        {
            print("scepter");
            SpawnPrefab(scepter, arma1Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }
        else if (StatePartida.arma2 == 6)
        {
            print("dagger");
            SpawnPrefab(dagger, arma1Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }
        else if (StatePartida.arma2 == 7)
        {
            print("swordfish");
            SpawnPrefab(swordfish, arma1Posicion);
            StatePartida.arma2 = 0;
            InfoPartida.tiempoInicio = Time.time;
        }

        if (StatePartida.victoria != 0)
        {
            InfoPartida.tiempoFinal = Time.time;
            StatePartida.partidas++;
            StatePartida.partidas2++;
            if(StatePartida.victoria == 1)
            {
                StatePartida.victorias++;
            }
            else if(StatePartida.victoria == 2)
            {
                StatePartida.victorias2++;
            }
            
            
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
