using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ActualizarDatos : MonoBehaviour
{
    private string nombre2;
    private int partidas2;
    private int victorias2;
    private int cuerpo2;
    private int cabeza2;
    private float puntuacion_maxima2;

    public ActualizarDatos(string nombre2, int partidas2, int victorias2, int cuerpo2, int cabeza2, float puntuacion_maxima2)
    {
        this.nombre2 = nombre2;
        this.partidas2 = partidas2;
        this.victorias2 = victorias2;
        this.cuerpo2 = cuerpo2;
        this.cabeza2 = cabeza2;
        this.puntuacion_maxima2 = puntuacion_maxima2;
    }

    public void CallLogin()
    {
        StartCoroutine(iniciarSesion());
    }

    IEnumerator iniciarSesion()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", nombre2);
        form.AddField("Cabeza", cabeza2);
        form.AddField("Puntuacion_maxima", puntuacion_maxima2.ToString());
        form.AddField("Cuerpo", cuerpo2);
        form.AddField("Partidas", partidas2);
        form.AddField("Victorias", victorias2);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/update.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);

            if (www.downloadHandler.text.StartsWith("0"))
            {
                Debug.Log("Usuario actualizado correctamente");
                
            }
            else
            {
                Debug.Log("Fallo al iniciar sesion. Error #" + www.downloadHandler.text);
            }
        }
        else
        {
            Debug.Log("Error de red: " + www.error);
        }
    }
}
