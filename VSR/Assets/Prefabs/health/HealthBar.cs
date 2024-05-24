using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
    public GameObject player;
    public Transform can;

    public void Update()
    {
        if(StatePartida.victoria != 0)
        {
            if (can.CompareTag("host"))
            {
                StatePartida.puntuacion_maxima2 += slider.value;
            }
            else if (can.CompareTag("invitado"))
            {
                StatePartida.puntuacion_maxima += slider.value;
            }
            SceneManager.LoadSceneAsync("SalaEspera");
        }
    }
    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(int damage)
	{
		slider.value -= damage;

        fill.color = slider.value == slider.maxValue ? Color.green : Color.red;

        if (slider.value <= 0)
        {
            if (player.CompareTag("Player"))
            {
                
                if (can.CompareTag("host"))
                {
                    StatePartida.victorias2++;
                    StatePartida.victoria = 2;
                }
                else if (can.CompareTag("invitado"))
                {
                    StatePartida.victorias++;
                    StatePartida.victoria = 1;
                }
                SceneManager.LoadSceneAsync("SalaEspera");
                //GameController.contadorActivo = false;
            }
            else
            {
                // Si es así, destruye el objeto del jugador
                Destroy(player);
            }
            
        }
    }

}
