using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public HealthBar healthBar; // Referencia al script HealthBar
    public Transform objeto, can;

    private void OnCollisionEnter(Collision other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "arma"
        if (other.gameObject.CompareTag("arma"))
        {
            int damage = 0;
            if (objeto.CompareTag("cabeza"))
            {
                damage = 100;
                if (can.CompareTag("host"))
                {
                    StatePartida.cabeza2++;
                }
                else if (can.CompareTag("invitado"))
                {
                    StatePartida.cabeza++;
                } else if (can.CompareTag("IA"))
                {
                    StatePartida.cabeza2++;
                } else if (can.CompareTag("Player"))
                {
                    StatePartida.cabeza++;
                }
            }
            else if (objeto.CompareTag("cuerpo"))
            {
                damage = 35;
                if (can.CompareTag("host"))
                {
                    StatePartida.cuerpo2++;
                }
                else if (can.CompareTag("invitado"))
                {
                    StatePartida.cuerpo++;
                } else if (can.CompareTag("IA"))
                {
                    StatePartida.cuerpo2++;
                }
                else if (can.CompareTag("Player"))
                {
                    StatePartida.cabeza++;
                }
            }

            // Llama al método SetHealth() del script HealthBar y le pasa la nueva salud
            healthBar.SetHealth(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "arma"
        if (other.gameObject.CompareTag("arma"))
        {
            int damage = 0;
            if (objeto.CompareTag("cabeza"))
            {
                damage = 100;
                if (can.CompareTag("host"))
                {
                    StatePartida.cabeza2++;
                }
                else if (can.CompareTag("invitado"))
                {
                    StatePartida.cabeza++;
                }
                else if (can.CompareTag("IA"))
                {
                    StatePartida.cuerpo2++;
                }
                else if (can.CompareTag("Player"))
                {
                    StatePartida.cabeza++;
                }
            }
            else if (objeto.CompareTag("cuerpo"))
            {
                damage = 35;
                if (can.CompareTag("host"))
                {
                    StatePartida.cuerpo2++;
                }
                else if (can.CompareTag("invitado"))
                {
                    StatePartida.cuerpo++;
                }
                else if (can.CompareTag("IA"))
                {
                    StatePartida.cuerpo2++;
                }
                else if (can.CompareTag("Player"))
                {
                    StatePartida.cabeza++;
                }
            }

            // Llama al método SetHealth() del script HealthBar y le pasa la nueva salud
            healthBar.SetHealth(damage);
        }
    }
}
