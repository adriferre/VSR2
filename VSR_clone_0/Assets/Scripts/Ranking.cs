using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public TextMeshProUGUI usuario1;
    public TextMeshProUGUI usuarioJugador;
    public TextMeshProUGUI usuario2;
    public TextMeshProUGUI usuario3;
    public TextMeshProUGUI usuario4;
    public TextMeshProUGUI usuario5;

    private void Start()
    {
        CallRanking();
        usuarioJugador.text = DBManager.usuario;
    }
    public void CallRanking()
    {
        StartCoroutine(Rankings());
    }

    IEnumerator Rankings()
    {

        UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/ranking.php");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);

            if (www.downloadHandler.text.StartsWith("0"))
            {
                int auxLength = www.downloadHandler.text.Split('\t').Length;
                if (auxLength == 3)
                {
                    usuario1.SetText(www.downloadHandler.text.Split('\t')[1]);
                    usuario2.SetText("___");
                    usuario3.SetText("___");
                    usuario4.SetText("___");
                    usuario5.SetText("___");
                } else if (auxLength == 5)
                {
                    usuario1.SetText(www.downloadHandler.text.Split('\t')[1]);
                    usuario2.SetText(www.downloadHandler.text.Split('\t')[3]);
                    usuario3.SetText("___");
                    usuario4.SetText("___");
                    usuario5.SetText("___");
                }
                else if (auxLength == 7)
                {
                    usuario1.SetText(www.downloadHandler.text.Split('\t')[1]);
                    usuario2.SetText(www.downloadHandler.text.Split('\t')[3]);
                    usuario3.SetText(www.downloadHandler.text.Split('\t')[5]);
                    usuario4.SetText("___");
                    usuario5.SetText("___");
                }
                else if (auxLength == 9)
                {
                    usuario1.SetText(www.downloadHandler.text.Split('\t')[1]);
                    usuario2.SetText(www.downloadHandler.text.Split('\t')[3]);
                    usuario3.SetText(www.downloadHandler.text.Split('\t')[5]);
                    usuario4.SetText(www.downloadHandler.text.Split('\t')[7]);
                    usuario5.SetText("___");
                }
                else if (auxLength == 11)
                {
                    usuario1.SetText(www.downloadHandler.text.Split('\t')[1]);
                    usuario2.SetText(www.downloadHandler.text.Split('\t')[3]);
                    usuario3.SetText(www.downloadHandler.text.Split('\t')[5]);
                    usuario4.SetText(www.downloadHandler.text.Split('\t')[7]);
                    usuario5.SetText(www.downloadHandler.text.Split('\t')[9]);
                } else
                {
                    usuario1.SetText("___");
                    usuario2.SetText("___");
                    usuario3.SetText("___");
                    usuario4.SetText("___");
                    usuario5.SetText("___");
                }
                Debug.Log("Ranking obtenido Correctamente");
                
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
    }
}
