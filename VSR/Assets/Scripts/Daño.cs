using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public HealthBar healthBar; // Referencia al script HealthBar

    private void OnCollisionEnter(Collision other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "arma"
        if (other.gameObject.CompareTag("arma"))
        {
            // Aquí puedes establecer la cantidad de salud que quieres asignar al personaje
            int damage = 35; // Por ejemplo, 100 de salud

            // Llama al método SetHealth() del script HealthBar y le pasa la nueva salud
            healthBar.SetHealth(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "arma"
        if (other.gameObject.CompareTag("arma"))
        {
            // Aquí puedes establecer la cantidad de salud que quieres asignar al personaje
            int damage = 35; // Por ejemplo, 100 de salud

            // Llama al método SetHealth() del script HealthBar y le pasa la nueva salud
            healthBar.SetHealth(damage);
        }
    }
}
