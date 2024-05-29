using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI contrasenyaText;

    public Button botonIniciarSesion;

    public MenuManager menuManager;

    public void CallLogin()
    {
        StartCoroutine(iniciarSesion());
    }

    /*
     IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nombreText.text);
        form.AddField("password", contrasenyaText.text);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/registro.php", form);
        yield return www;
        print("Result " + www.result);
        print("Result succes " + UnityWebRequest.Result.Success);
        print("Respuesta del servidor " + www.downloadHandler.text);
        
        if(www.downloadHandler.text == "0")
        {
            Debug.Log("Usuario creado correctamente");
        }
        else
        {
            Debug.Log("Creacion de usuario fallida. Error #" + www.downloadHandler.text);
        }
    }
     */

    IEnumerator iniciarSesion()
    {

        if (nombreText != null)
        {
            print("Valido");
        }
        else
        {
            print("Nulo");
        }
        print(nombreText.text + "---" + contrasenyaText.text);

        WWWForm form = new WWWForm();
        form.AddField("name", nombreText.text);
        form.AddField("password", contrasenyaText.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);

            if (www.downloadHandler.text.StartsWith("0"))
            {
                Debug.Log("Usuario iniciado sesion correctamente");
                DBManager.usuario = nombreText.text;
                DBManager.puntuacion = int.Parse(www.downloadHandler.text.Split('\t')[1]);
                DBManager.cabeza = int.Parse(www.downloadHandler.text.Split('\t')[2]);
                DBManager.cuerpo = int.Parse(www.downloadHandler.text.Split('\t')[3]);
                DBManager.partidas = int.Parse(www.downloadHandler.text.Split('\t')[4]);
                DBManager.victorias = int.Parse(www.downloadHandler.text.Split('\t')[5]);
                menuManager.UISiLogin();
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



    public void VerifyInputs()
    {
        botonIniciarSesion.interactable = (nombreText.text.Length >= 8 && contrasenyaText.text.Length >= 8);
    }
}
