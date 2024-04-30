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
                SceneManager.LoadSceneAsync("SalaEspera");
                StatePartida.victoria = 1;
            }
            else
            {
                // Si es así, destruye el objeto del jugador
                Destroy(player);
            }
            
        }
    }

}
