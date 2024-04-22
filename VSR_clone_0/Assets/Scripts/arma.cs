using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma : MonoBehaviour
{
    public Transform Arma;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("escudo"))
        {
            
            
            // Si entra en contacto con el escudo, cambia el tag a "escudo"
            Arma.tag = "escudo";

            // Establece un temporizador para revertir el cambio de tag después de 10 segundos
            StartCoroutine(RestoreOriginalTagAfterDelay(0.5f));
        }
    }
    private IEnumerator RestoreOriginalTagAfterDelay(float delay)
    {
        // Espera durante el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Revierte el tag al original
        Arma.tag = "arma";
    }
}
