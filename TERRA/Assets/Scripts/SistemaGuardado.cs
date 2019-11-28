using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SistemaGuardado : MonoBehaviour
{
    public String buscarNombre = "", prueba;
    public bool cargarInicio;
    public int basura;
    public bool guardaAutomatico;
    int contador = 1;
    public string nombre1 = "", nombre2 = "", nombre3 = "";
    public InputField name;
    public Text txt1, txt2, txt3;
    public Button borrar1, borrar2, borrar3;
    public string next;

    //Variables que guardaran los datos de las partidas
    public String nombreEscena, nombrePartida;

    void Start()
    {
        //La primera vez que se abre laescena, se crea el archivo donde se iran contadno las partidas
        if (!File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            guardarContador();
        }
    }
    
    // Este método se llama al momento de crear un archivo y también cada vez que se actualizan los datos para guardar
    public void guardar()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Dato es la variable de la clase que se serializa

        //Variables a guardar        
        dato.nombrePartida = nombrePartida;
        dato.basura = 4;
        dato.nombreEscena = nombreEscena;

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }

    //Este método nos carga el progreso de un archivo
    public void cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/" + buscarNombre + ".d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/" + buscarNombre + ".d");
            DatosJuego datos = new DatosJuego();

            datos = bf.Deserialize(expediente) as DatosJuego;

            nombrePartida = datos.nombrePartida;
            nombreEscena = datos.nombreEscena;
            basura = datos.basura;
            SceneManager.LoadScene(nombreEscena);
            Debug.Log("Nombre partida " + nombrePartida);
            Debug.Log("Nombre escena " + nombreEscena);

        }
        else { Debug.Log("No se encontro el archivo"); }
    }

    //Este método borra un archivo
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

    /*Este método es llamado para crear una partida, se toma el nombre del archivo y de la partida,
    asi como asignar y guardas los nombres en el archivo contador Partida, además nos indica si ya se han creado las tres partidas*/
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

    //Este método solamente nos indica para guarcar los datos del archivo contador partida
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

    //El método nos manda los nombres de las partidas creadas
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

    //El método nos ayuda a eliminar la partida 1
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
    //El método nos ayuda a eliminar la partida 2
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
    //El método nos ayuda a eliminar la partida 3
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
    //El método nos carga los nombres y el contador del archivo contando partida
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

    public void escena1()
    {
        if (nombre1 != "")
        {
            buscarNombre = nombre1;
            nombrePartida = buscarNombre;
            Debug.Log("Nombre partida antes de cargar" + nombrePartida);
            cargar();
            Debug.Log("Nombre partida despues de cargar" + nombrePartida);
        }
        else
        {
            Debug.Log("No hay partida");
        }
    }
    public void escena2()
    {
        if(nombre2!="")
        {
            buscarNombre = nombre2;
            nombrePartida = buscarNombre;
            cargar();
        }
        else
        {
            Debug.Log("No hay partida");
        }
    }
    public void escena3()
    {
        if (nombre3 != "")
        {
            
            buscarNombre = nombre3;
            nombrePartida = buscarNombre;
            cargar();
        }
        else
        {
            Debug.Log("No hay partida");
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Next")
        {
            //mensaje1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                nombreEscena = next;
                buscarNombre = nombreEscena;
                guardar();
                SceneManager.LoadScene(nombreEscena);
                cargar();

            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            Debug.Log("Nombre partida " + SceneManager.GetActiveScene().name);
            Debug.Log("Nombre partida antes " + nombrePartida);
            nombreEscena = SceneManager.GetActiveScene().name;
            Debug.Log("Nombre escena antes " + nombreEscena);
            guardar();
            Debug.Log("Nombre partida despues " + nombrePartida);
            Debug.Log("Nombre escena despues " + nombreEscena);

        }
        
    }
}

//Esta clase nos serializa los datos de las partidas
[Serializable()]//Datos listos para serializar
class DatosJuego:System.Object
{
    public String nombrePartida, nombreEscena;
    public int basura;
}


//Esta clase serializa el archivo contando partida
[Serializable()]
class DatosPartidas:System.Object
{
    public string nombre1, nombre2, nombre3;
    public int contador;
}
