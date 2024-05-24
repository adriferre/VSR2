using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Estadisticas : MonoBehaviour
{

    public TextMeshProUGUI usuario;
    public TextMeshProUGUI partidas;
    public TextMeshProUGUI victorias;
    public TextMeshProUGUI cuerpo;
    public TextMeshProUGUI cabeza;
    // Start is called before the first frame update
    void Start()
    {
        if (DBManager.usuario != null)
        {
            usuario.text = DBManager.usuario;
        } else
        {
            usuario.text = "___";
        }
        partidas.text = DBManager.partidas.ToString();
        victorias.text = DBManager.victorias.ToString();
        cuerpo.text = DBManager.cuerpo.ToString();
        cabeza.text = DBManager.cabeza.ToString();

        
    }
}
