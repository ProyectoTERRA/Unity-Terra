using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public string next, before;
    //Variables que guardaran los datos de las partidas
    public String nombreEscena, nombrePartida, nombrePartida1;

    void Start()
    {
        contador = 1;
        //La primera vez que se abre laescena, se crea el archivo donde se iran contadno las partidas
        if (!File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            guardarContador();
        }
    }
    public void Update()
    {
        cargarContador();
        //Debug.Log("Nombre actual " + nombrePartida);
    }
    public void crearPartida()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida1 + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Dato es la variable de la clase que se serializa

        //Variables a guardar        
        dato.nombrePartida = nombrePartida1;
        dato.nombreEscena = "edificio";
        dato.pila = 0;
        dato.bolsa = 0;
        dato.carton = 0;
        dato.manzana = 0;
        dato.platano = 0;
        dato.lata = 0;
        Debug.Log("Nueva partida");

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }

    // Este método se llama al momento de crear un archivo y también cada vez que se actualizan los datos para guardar
    public void guardar()
    {

        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Dato es la variable de la clase que se serializa

        //Variables a guardar        
        dato.nombrePartida = nombrePartida;
        dato.nombreEscena = nombreEscena;
        dato.pila = radial.basura[0];
        dato.bolsa = radial.basura[1];
        dato.carton = radial.basura[2];
        dato.manzana = radial.basura[3];
        dato.platano = radial.basura[4];
        dato.lata = radial.basura[5];
        Debug.Log("ACTUALIZAR PARTIDA");
        Debug.Log("Pila " + radial.basura[0]);
        Debug.Log("Bolsa " + radial.basura[1]);
        Debug.Log("Carton " + radial.basura[2]);
        Debug.Log("Manzana " + radial.basura[3]);
        Debug.Log("Platano " + radial.basura[4]);
        Debug.Log("Lata " + radial.basura[5]);
        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }

    //Este método nos carga el progreso de un archivo
    public void cargar()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();
        if (File.Exists(Application.persistentDataPath + "/" + buscarNombre + ".d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/" + buscarNombre + ".d");
            DatosJuego datos = new DatosJuego();

            datos = bf.Deserialize(expediente) as DatosJuego;
            Debug.Log("Nombre al cargar " + nombrePartida);
            nombrePartida = datos.nombrePartida;
            nombreEscena = datos.nombreEscena;
            radial.basura[0] = datos.pila;
            radial.basura[1] = datos.bolsa;
            radial.basura[2] = datos.carton;
            radial.basura[3] = datos.manzana;
            radial.basura[4] = datos.platano;
            radial.basura[5] = datos.lata;
            GameController.lata = datos.lata;
            GameController.pila = datos.pila;
            GameController.bolsa = datos.bolsa;
            GameController.manzana = datos.manzana;
            GameController.platano = datos.platano;
            GameController.carton = datos.carton;
            guardarContador();
            SceneManager.LoadScene(nombreEscena);
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
            Debug.Log("Contador " + contador);
            name = GameObject.Find("InputField").GetComponent<InputField>();

            if (contador == 1)
            {
                nombre1 = name.text;
                nombrePartida1 = name.text;
                dato.nombre1 = nombre1;
                Debug.Log("Partida 1");
                contador += 1;
                crearPartida();
            }
            else if (contador == 2)
            {
                nombre2 = name.text;
                nombrePartida1 = name.text;
                dato.nombre2 = nombre2;
                Debug.Log("Partida 2");
                contador += 1;
                crearPartida();
            }
            else if (contador == 3)
            {
                nombre3 = name.text;
                nombrePartida1 = name.text;
                Debug.Log("Partida 3");
                dato.nombre3 = nombre3;
                contador += 1;
                crearPartida();
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

        dato.nombreActual = nombrePartida;
        dato.nombre1 = nombre1;
        dato.nombre2 = nombre2;
        dato.nombre3 = nombre3;
        dato.contador = contador;
        Debug.Log("Nombre actual " + dato.nombreActual);
        Debug.Log("dato contador " + dato.contador);
        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
        Debug.Log("se guardo archivo contador partida");

    }
    //El método nos manda los nombres de las partidas creadas
    public void cargarContador()
    {
        if (File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/contandoPartida.d");
            DatosPartidas datos = new DatosPartidas();

            datos = bf.Deserialize(expediente) as DatosPartidas;

            nombrePartida = datos.nombreActual;

            expediente.Close();
        }
        else { Debug.Log("No se encontro el archivo"); }
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

    //El método nos ayuda a eliminar la partida 1
    public void eliminarPartida1()
    {
        cargarPartida();
        nombrePartida = nombre1;
        nombre1 = nombre2;
        nombre2 = nombre3;
        nombre3 = " ";
        while (contador > 1)
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
            cargar();
        }
        else
        {
            Debug.Log("No hay partida");
        }
    }
    public void escena2()
    {
        if (nombre2 != "")
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                nombreEscena = next;
                SceneManager.LoadScene(nombreEscena);
            }
        }
        if (collision.gameObject.tag == "before")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                nombreEscena = before;
                SceneManager.LoadScene(nombreEscena);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            Debug.Log("Checkpoint " + nombrePartida);
            nombreEscena = SceneManager.GetActiveScene().name;
            guardar();
        }
    }
}

//Esta clase nos serializa los datos de las partidas
[Serializable()]//Datos listos para serializar
class DatosJuego : System.Object
{
    public String nombrePartida, nombreEscena;
    public int pila, manzana, platano, bolsa, carton, lata;
}


//Esta clase serializa el archivo contando partida
[Serializable()]
class DatosPartidas : System.Object
{
    public string nombre1, nombre2, nombre3;
    public string nombreActual;
    public int contador;
    public int pila, manzana, platano, bolsa, carton, lata;
}

