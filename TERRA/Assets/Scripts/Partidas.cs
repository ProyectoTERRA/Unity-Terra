using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partidas : MonoBehaviour
{

    NombrePartidas nombrePartidas;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pasara()
    {
        nombrePartidas = new NombrePartidas();
        List<string> x = nombrePartidas.nombres;
        if (x == null)
        {
            Debug.Log("Lista Vacia");
        }
        else
        {
            foreach (string color in x)
            {
                Debug.Log("Guardado en partida" + color);
            }
        }
    }
}

public class NombrePartidas
{
    public List<string> nombres;
    public NombrePartidas()
    {
        nombres = new List<string>();    
    }
    public void agregar(string name)
    {
        nombres.Add(name);
    }
}
