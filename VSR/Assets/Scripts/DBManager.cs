using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string usuario;
    public static int puntuacion;
    public static int partidas;
    public static int cabeza;
    public static int cuerpo;
    public static int victorias;

    public static bool sesionIniciada
    {
        get { return usuario != null; }
    }

    public static void salirSesion(){

        usuario = null;
    }
}
