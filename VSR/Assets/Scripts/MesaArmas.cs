using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaArmas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("arma");
        if (other.CompareTag("arma"))
        {
            print("armaEntra");
            if (other.gameObject.name.Equals("Dragon Slayer")) {
                print("arma1");
                StatePartida.arma = 1;
            }    
        } else if (other.CompareTag("escudo"))
        {

        }
    }
}
