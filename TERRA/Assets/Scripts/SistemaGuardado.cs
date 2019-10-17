using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SistemaGuardado : MonoBehaviour
{
    public String nombrePartida = "";
    public String buscarNombre = "", prueba;
    public bool cargarInicio;
    public int basura;
    public bool guardaAutomatico;
    int contador = 1;
    public string nombre1 = "", nombre2 = "", nombre3 = "";
    public InputField name;
    public Text txt1, txt2, txt3;
    public Button borrar1, borrar2, borrar3;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            guardarContador();
        }
        guardaAutomatico = Input.GetKeyDown(KeyCode.Space);

        if (cargarInicio)
        {
            cargar();
        }
        if (guardaAutomatico)
        {
            guardar();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void guardar()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Daro es la variable de la clase que se serializa

        //Variables a guardar        
        dato.nombrePartida = nombrePartida;
        dato.basura = 4;

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
        Debug.Log("se creo" + name.text);
    }

    public void cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/" + buscarNombre + ".d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/" + buscarNombre + ".d");
            DatosJuego datos = new DatosJuego();

            datos = bf.Deserialize(expediente) as DatosJuego;

            prueba = datos.nombrePartida;
            basura = datos.basura;
        }
        else { Debug.Log("No se encontro el archivo"); }
    }

    public void borrar()
    {
        if (File.Exists(Application.persistentDataPath + "/" + nombrePartida + ".d"))
        {
            File.Delete(Application.persistentDataPath + "/" + nombrePartida + ".d");
        }
        else
        {
            Debug.Log("No hay para borrar");
        }
    }

    public void get()
    {
        if (File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Ayudante
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/contandoPartida.d");//Crea archivo datos.d
            DatosPartidas dato = new DatosPartidas(); //Dato es la variable de la clase que se serializa

            dato = bf.Deserialize(expediente) as DatosPartidas;

            contador = dato.contador;
            nombre1 = dato.nombre1;
            nombre2 = dato.nombre2;
            nombre3 = dato.nombre3;

            Debug.Log("Linea 100 dato.contador: " + dato.contador);

            name = GameObject.Find("InputField").GetComponent<InputField>();

            if (contador == 1)
            {
                nombre1 = name.text;
                nombrePartida = name.text;
                dato.nombre1 = nombre1;
                Debug.Log("Partida 1");
                contador += 1;
                guardar();
            }
            else if (contador == 2)
            {
                nombre2 = name.text;
                nombrePartida = name.text;
                dato.nombre2 = nombre2;
                Debug.Log("Partida 2");
                contador += 1;
                guardar();
            }
            else if (contador == 3)
            {
                nombre3 = name.text;
                nombrePartida = name.text;
                Debug.Log("Partida 3");
                dato.nombre3 = nombre3;
                contador += 1;
                guardar();
            }
            else if (contador == 4)
            {
                Debug.Log("No se pueden crear mas de 3 partidas");
            }
            dato.contador = contador;
            expediente.Close();
            guardarContador();
        }
    }

    public void guardarContador()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/contandoPartida.d");//Crea archivo datos.d
        DatosPartidas dato = new DatosPartidas(); //Daro es la variable de la clase que se serializa

        //Variables a guardar 

        dato.nombre1 = nombre1;
        dato.nombre2 = nombre2;
        dato.nombre3 = nombre3;
        dato.contador = contador;
        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
        Debug.Log("se guardo archivo contador partida");
    }

    public void mostrarPartida()
    {
        if (File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/contandoPartida.d");
            DatosPartidas datos = new DatosPartidas();

            datos = bf.Deserialize(expediente) as DatosPartidas;

            nombre1 = datos.nombre1;
            nombre2 = datos.nombre2;
            nombre3 = datos.nombre3;
            contador = datos.contador;

            txt1.text = nombre1;
            txt2.text = nombre2;
            txt3.text = nombre3;
            expediente.Close();
        }
        else { Debug.Log("No se encontro el archivo"); }
    }

    public void eliminarPartida1()
    {
        cargarPartida();
        nombrePartida = nombre1;
        nombre1 = nombre2;
        nombre2 = nombre3;
        nombre3 = " ";
        while(contador>1)
            contador--;
        
        guardarContador();
        borrar();
        Debug.Log("Se borro");
    }
    public void eliminarPartida2()
    {
        cargarPartida();
        nombrePartida = nombre2;
        nombre2 = nombre3;
        nombre3 = ".";
        while (contador > 1)
            contador--;
        guardarContador();
        borrar();
        Debug.Log("Se borro");
    }
    public void eliminarPartida3()
    {
        cargarPartida();
        nombrePartida = nombre3;
        nombre3 = " ";
        while (contador > 1)
            contador--;
        guardarContador();
        borrar();
        Debug.Log("Se borro");
    }
    public void cargarPartida()
    {
        if (File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/contandoPartida.d");
            DatosPartidas datos = new DatosPartidas();

            datos = bf.Deserialize(expediente) as DatosPartidas;

            nombre1 = datos.nombre1;
            nombre2 = datos.nombre2;
            nombre3 = datos.nombre3;
            contador = datos.contador;
            expediente.Close();
        }
        else { Debug.Log("No se encontro el archivo"); }
    }
}

[Serializable()]//Datos listos para serializar
class DatosJuego:System.Object
{
    public String nombrePartida;
    public int basura;
}

[Serializable()]
class DatosPartidas:System.Object
{
    public string nombre1, nombre2, nombre3;
    public int contador;
}
