using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Registro : MonoBehaviour
{

    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI contrasenyaText;

    public Button botonRegistrar;

    public MenuManager menuManager;
    public void CallRegister()
    {
        StartCoroutine(Register());
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

    IEnumerator Register()
    {

        if (nombreText != null)
        {
            print("Valido");
        }
        else
        {
            print("Nulo");
        }

        WWWForm form = new WWWForm();
        form.AddField("name", nombreText.text);
        form.AddField("password", contrasenyaText.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/registro.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);

            if (www.downloadHandler.text == "0")
            {
                Debug.Log("Usuario creado correctamente");
            }
            else
            {
                Debug.Log("Creacion de usuario fallida. Error #" + www.downloadHandler.text);
            }
        }
        else
        {
            Debug.Log("Error de red: " + www.error);
        }
    }



    public void VerifyInputs()
    {
        botonRegistrar.interactable = (nombreText.text.Length >= 8 && contrasenyaText.text.Length >= 8);
    }
}
