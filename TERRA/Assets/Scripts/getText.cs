using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getText : MonoBehaviour
{

    public InputField nombre;
    public Text setNombre;
    public void setGet()
    {
        
        setNombre.text ="Nombre: "+nombre.text;
        Debug.Log(nombre+"        "+nombre.text);

        Debug.Log("Nombre de partida: "+ EstadoJuego.estadoJuego.nombrePartida);
        EstadoJuego.estadoJuego.guardar();
        EstadoJuego.estadoJuego.nombrePartida = "Aleee";
        Debug.Log("Nombre de partida despues: " + EstadoJuego.estadoJuego.nombrePartida);
    }
}
