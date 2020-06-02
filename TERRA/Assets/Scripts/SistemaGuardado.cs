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
    public static int perder=0, morir=0;
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
        if (perder == 1 )
        {
            Debug.Log("perdio una vida");
            buscarNombre = GameController.nombreActualPartida;
            Debug.Log("Perder antes de cargar " + perder);
            cargar1();
        }
        if(morir == 1)
        {
            Debug.Log("Se nos murio");
            buscarNombre = GameController.nombreActualPartida;
            if(GameController.LobbyCAP == 5 && paso != 0)
            {
                cargar5();
            }
            else if(GameController.LobbyCAP != 5)
            {
                cargar1();
            }
        }
    }
    int paso = 0;
    public void crearPartida()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida1 + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Dato es la variable de la clase que se serializa

        //Variables a guardar        
        dato.nombrePartida = nombrePartida1;
        dato.nombreEscena = "Casa";
        dato.pila = 0;
        dato.bolsa = 0;
        dato.carton = 0;
        dato.manzana = 0;
        dato.platano = 0;
        dato.lata = 0;
        dato.normal = 0;
        dato.paralizante = 0;
        dato.desactivadora = 0;
        dato.tranquilizante = 0;
        dato.pesada = 0;
        dato.energia = 0;
        dato.curacion = 0;
        dato.ganzua = 0;
        dato.formula = 0;
        dato.vidas = 3;
        dato.corazones = 6;
        dato.tipo = 1;
        dato.vidasMax = 3;
        dato.corazonesMax = 6;

        //Respaldo
        dato.nombreEscena1 = "Casa";
        dato.pila1 = 0;
        dato.bolsa1 = 0;
        dato.carton1 = 0;
        dato.manzana1 = 0;
        dato.platano1 = 0;
        dato.lata1 = 0;
        dato.normal1 = 0;
        dato.paralizante1 = 0;
        dato.desactivadora1 = 0;
        dato.tranquilizante1 = 0;
        dato.pesada1 = 0;
        dato.energia1 = 0;
        dato.curacion1 = 0;
        dato.ganzua1 = 0;
        dato.formula1 = 0;
        dato.vidas1 = 3;
        dato.corazones1 = 6;
        dato.tipo1 = 1;
        dato.vidasMax1 = 3;
        dato.corazonesMax1 = 6;
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
        Debug.Log("Nombre al guardar 1 " + dato.nombreEscena1);
        dato.nombrePartida = nombrePartida;
        dato.nombreEscena = nombreEscena;
        dato.pila = radial.basura[0];
        dato.bolsa = radial.basura[1];
        dato.carton = radial.basura[2];
        dato.manzana = radial.basura[3];
        dato.platano = radial.basura[4];
        dato.lata = radial.basura[5];
        dato.normal = radial.esfera[0];
        dato.paralizante = radial.esfera[1];
        dato.desactivadora = radial.esfera[2];
        dato.tranquilizante = radial.esfera[3];
        dato.pesada = radial.esfera[4];
        dato.energia = radial.especiales[0];
        dato.curacion = radial.especiales[1];
        dato.ganzua = radial.especiales[2];
        dato.formula = GameController.formula;
        dato.vidas = Heart_Bar.life;
        dato.corazones = Heart_Bar.Phearts;
        dato.tipo = GameController.TypeLife;
        dato.vidasMax = GameController.LifeMax;
        dato.corazonesMax = GameController.HeartsMax;
        Debug.Log("Datos vidas al guardar " + dato.vidas);

        //Datos para respaldo
        dato.nombreEscena1 = GameController.nombreEscena0;
        Debug.Log("Nombre de escena 1 " + dato.nombreEscena1);
        dato.pila1 = GameController.pila0;
        dato.bolsa1 = GameController.bolsa0;
        dato.carton1 = GameController.carton0;
        dato.manzana1 = GameController.manzana0;
        dato.platano1 = GameController.platano0;
        dato.lata1 = GameController.lata0;
        dato.normal1 = GameController.normal0;
        dato.paralizante1 = GameController.paralizante0;
        dato.desactivadora1 = GameController.desactivadora0;
        dato.tranquilizante1 = GameController.tranquilizante0;
        dato.pesada1 = GameController.pesada0;
        dato.energia1 = GameController.energia0;
        dato.curacion1 = GameController.curacion0;
        dato.ganzua1 = GameController.ganzua0;
        dato.formula1 = GameController.formula0;
        dato.vidasMax1 = GameController.LifeMax;
        dato.corazonesMax1 = GameController.HeartsMax;

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }
    public void recuperarCap5()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Dato es la variable de la clase que se serializa
        //Respaldo
        dato.nombreEscena1 = GameController.nombreEscena0;
        dato.pila1 = GameController.pila0 + radial.basura[0];
        dato.bolsa1 = GameController.bolsa0 + radial.basura[1];
        dato.carton1 = GameController.carton0 + radial.basura[2];
        dato.manzana1 = GameController.manzana0 + radial.basura[3];
        dato.platano1 = GameController.platano0 + radial.basura[4];
        dato.lata1 = GameController.lata0 + radial.basura[5];
        dato.normal1 = GameController.normal0 + radial.esfera[0];
        dato.paralizante1 = GameController.paralizante0 + radial.esfera[1];
        dato.desactivadora1 = GameController.desactivadora0 + radial.esfera[2];
        dato.tranquilizante1 = GameController.tranquilizante0 + radial.esfera[3];
        dato.pesada1 = GameController.pesada0 + radial.esfera[4];
        dato.energia1 = GameController.energia0 + radial.especiales[0];
        dato.curacion1 = GameController.curacion0 + radial.especiales[1];
        dato.ganzua1 = GameController.ganzua0 + radial.especiales[2];
        dato.formula1 = GameController.formula0;
        dato.vidas1 = GameController.LifeMax;
        dato.corazones1 = GameController.HeartsMax;
        dato.tipo1 = GameController.TypeLife;
        dato.vidasMax = GameController.LifeMax;
        dato.corazonesMax = GameController.HeartsMax;
        Debug.Log("Nombre de la escena 1 " + dato.nombreEscena1);

        dato.nombrePartida = nombrePartida;
        dato.nombreEscena = nombreEscena;
        dato.pila =dato.pila1;
        dato.bolsa = dato.bolsa1;
        dato.carton = dato.carton1;
        dato.manzana = dato.manzana1;
        dato.platano = dato.platano1;
        dato.lata = dato.lata1;
        dato.normal = dato.normal1;
        dato.paralizante = dato.paralizante1;
        dato.desactivadora = dato.desactivadora1;
        dato.tranquilizante = dato.tranquilizante1;
        dato.pesada = dato.pesada1;
        dato.energia = dato.energia1;
        dato.curacion = dato.curacion1;
        dato.ganzua = dato.ganzua1;
        dato.formula = dato.formula1;
        dato.vidas = dato.vidasMax;
        dato.corazones = dato.corazonesMax;
        dato.tipo = GameController.TypeLife;
    

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }
    public void guardarCap5()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Dato es la variable de la clase que se serializa
        //Respaldo
        dato.nombreEscena1 = nombreEscena;
        dato.pila1 = radial.basura[0];
        dato.bolsa1 = radial.basura[1];
        dato.carton1 = radial.basura[2];
        dato.manzana1 = radial.basura[3];
        dato.platano1 = radial.basura[4];
        dato.lata1 = radial.basura[5];
        dato.normal1 = radial.esfera[0];
        dato.paralizante1 = radial.esfera[1];
        dato.desactivadora1 = radial.esfera[2];
        dato.tranquilizante1 = radial.esfera[3];
        dato.pesada1 = radial.esfera[4];
        dato.energia1 = radial.especiales[0];
        dato.curacion1 = radial.especiales[1];
        dato.ganzua1 = radial.especiales[2];
        dato.formula1 = GameController.formula;
        dato.vidas1 = Heart_Bar.life;
        dato.corazones1 = Heart_Bar.Phearts;
        dato.tipo1 = GameController.TypeLife;
        dato.vidasMax = GameController.LifeMax;
        dato.corazonesMax = GameController.HeartsMax;
        Debug.Log("Nombre de la escena 1 " + dato.nombreEscena1);

        //Guardando en gamecontroller
        GameController.nombreEscena0 = dato.nombreEscena1;
        GameController.pila0 = dato.pila1;
        GameController.carton0 = dato.carton1;
        GameController.bolsa0 = dato.bolsa1;
        GameController.manzana0 = dato.manzana1;
        GameController.platano0 = dato.platano1;
        GameController.lata0 = dato.lata1;
        GameController.normal0 = dato.normal1;
        GameController.paralizante0 = dato.paralizante1;
        GameController.desactivadora0 = dato.desactivadora1;
        GameController.tranquilizante0 = dato.tranquilizante1;
        GameController.pesada0 = dato.pesada1;
        GameController.curacion0 = dato.curacion1;
        GameController.ganzua0 = dato.ganzua1;
        GameController.formula0 = dato.formula1;
        GameController.LifeMax = dato.vidasMax;
        GameController.HeartsMax = dato.corazonesMax;

        //Variables a modificar porel cap
        radial.basura[0] = 0;
        radial.basura[1] = 0;
        radial.basura[2] = 0;
        radial.basura[3] = 0;
        radial.basura[4] = 0;
        radial.basura[5] = 0;
        radial.esfera[1] = 0;
        radial.esfera[2] = 0;
        radial.esfera[3] = 0;
        radial.esfera[4] = 0;
        radial.especiales[0] = 0;
        radial.especiales[1] = 0;
        radial.especiales[2] = 0;
        Heart_Bar.life = 3;
        Heart_Bar.Phearts = 2;
        GameController.TypeLife = 1;


        //Variables a guardar        
        dato.nombrePartida = nombrePartida;
        dato.nombreEscena = nombreEscena;        
        dato.pila = radial.basura[0];
        dato.bolsa = radial.basura[1];
        dato.carton = radial.basura[2];
        dato.manzana = radial.basura[3];
        dato.platano = radial.basura[4];
        dato.lata = radial.basura[5];
        dato.normal = radial.esfera[0];
        dato.paralizante = radial.esfera[1];
        dato.desactivadora = radial.esfera[2];
        dato.tranquilizante = radial.esfera[3];
        dato.pesada = radial.esfera[4];
        dato.energia = radial.especiales[0];
        dato.curacion = radial.especiales[1];
        dato.ganzua = radial.especiales[2];
        dato.formula = GameController.formula;
        dato.vidas = Heart_Bar.life;
        dato.corazones = Heart_Bar.Phearts;
        dato.tipo = GameController.TypeLife; 

        

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }
    public void guardar1()
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
        dato.normal = radial.esfera[0];
        dato.paralizante = radial.esfera[1];
        dato.desactivadora = radial.esfera[2];
        dato.tranquilizante = radial.esfera[3];
        dato.pesada = radial.esfera[4];
        dato.energia = radial.especiales[0];
        dato.curacion = radial.especiales[1];
        dato.ganzua = radial.especiales[2];
        dato.formula = GameController.formula;
        dato.vidas = Heart_Bar.life;
        dato.corazones = Heart_Bar.Phearts;
        dato.tipo = GameController.TypeLife;
        dato.vidasMax = GameController.LifeMax;
        dato.corazonesMax = GameController.HeartsMax;

        //Respaldo
        dato.nombreEscena1 = nombreEscena;
        dato.pila1 = radial.basura[0];
        dato.bolsa1 = radial.basura[1];
        dato.carton1 = radial.basura[2];
        dato.manzana1 = radial.basura[3];
        dato.platano1 = radial.basura[4];
        dato.lata1 = radial.basura[5];
        dato.normal1 = radial.esfera[0];
        dato.paralizante1 = radial.esfera[1];
        dato.desactivadora1 = radial.esfera[2];
        dato.tranquilizante1 = radial.esfera[3];
        dato.pesada1 = radial.esfera[4];
        dato.energia1 = radial.especiales[0];
        dato.curacion1 = radial.especiales[1];
        dato.ganzua1 = radial.especiales[2];
        dato.formula1 = GameController.formula;
        dato.vidas1 = Heart_Bar.life;
        dato.corazones1 = Heart_Bar.Phearts;
        dato.tipo1 = GameController.TypeLife;
        dato.vidasMax1 = GameController.LifeMax;
        dato.corazonesMax1 = GameController.HeartsMax;
        Debug.Log("Nombre de la escena 1 " + dato.nombreEscena1);

        //Guardando en gamecontroller
        GameController.nombreEscena0 = dato.nombreEscena1;
        GameController.pila0 = dato.pila1;
        GameController.carton0 = dato.carton1;
        GameController.bolsa0 = dato.bolsa1;
        GameController.manzana0 = dato.manzana1;
        GameController.platano0 = dato.platano1;
        GameController.lata0 = dato.lata1;
        GameController.normal0 = dato.normal1;
        GameController.paralizante0 = dato.paralizante1;
        GameController.desactivadora0 = dato.desactivadora1;
        GameController.tranquilizante0 = dato.tranquilizante1;
        GameController.pesada0 = dato.pesada1;
        GameController.curacion0 = dato.curacion1;
        GameController.ganzua0 = dato.ganzua1;
        GameController.formula0 = dato.formula1;
        GameController.HeartsMax = dato.corazonesMax1;
        GameController.LifeMax = dato.vidasMax1;


        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
    }
    public void enemigosFalse()
    {
        GameController.e1 = false;
        GameController.e2 = false;
        GameController.e3 = false;
        GameController.e4 = false;
        GameController.e5 = false;
        GameController.e6 = false;
        GameController.e7 = false;
    }
    public void cargar5()
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
            
            
            if (morir == 1)
            {
                datos.nombreEscena = datos.nombreEscena1;
                nombreEscena = datos.nombreEscena;
                Debug.Log("Nombre escena datos " + datos.nombreEscena);
                Debug.Log("Nombre escena datos 1 " + datos.nombreEscena1);
                Debug.Log("Nombre escena " + nombreEscena);
                if (y==0)
                {
                    SceneManager.LoadScene(nombreEscena);
                    y++;
                }
                
                //Datos sobre la vida
                enemigosFalse();
                datos.vidas = 3;
                datos.corazones = 2;
                datos.tipo = 1;
                //Datos de respaldo metidos a datos
                Debug.Log("Cargar al morir");
                Debug.Log("Nombre de escena" + datos.nombreEscena1);
                Debug.Log("Bolsa " + datos.bolsa1);
                
                datos.pila1 = datos.pila1;
                datos.bolsa1 = datos.bolsa1;
                datos.carton1 = datos.carton1;
                datos.manzana1 = datos.manzana1;
                datos.platano1 = datos.platano1;
                datos.lata1 = datos.lata1;
                datos.normal1 = datos.normal1;
                datos.paralizante1 = datos.paralizante1;
                datos.desactivadora1 = datos.desactivadora1;
                datos.tranquilizante1 = datos.tranquilizante1;
                datos.pesada1 = datos.pesada1;
                datos.energia1 = datos.energia1;
                datos.curacion1 = datos.curacion1;
                datos.ganzua1 = datos.ganzua1;
                datos.formula1 = datos.formula1;
                morir = 0;
            }
            nombrePartida = datos.nombrePartida;
            
            radial.basura[0] = datos.pila;
            radial.basura[1] = datos.bolsa;
            radial.basura[2] = datos.carton;
            radial.basura[3] = datos.manzana;
            radial.basura[4] = datos.platano;
            radial.basura[5] = datos.lata;
            radial.esfera[0] = datos.normal;
            radial.esfera[1] = datos.paralizante;
            radial.esfera[2] = datos.desactivadora;
            radial.esfera[3] = datos.tranquilizante;
            radial.esfera[4] = datos.pesada;
            radial.especiales[0] = datos.energia;
            radial.especiales[1] = datos.curacion;
            radial.especiales[2] = datos.ganzua;
            GameController.lata = datos.lata;
            GameController.pila = datos.pila;
            GameController.bolsa = datos.bolsa;
            GameController.manzana = datos.manzana;
            GameController.platano = datos.platano;
            GameController.carton = datos.carton;
            GameController.normal = datos.normal;
            GameController.paralizante = datos.paralizante;
            GameController.desactivadora = datos.desactivadora;
            GameController.tranquilizante = datos.tranquilizante;
            GameController.pesada = datos.pesada;
            GameController.energia = datos.energia;
            GameController.curacion = datos.curacion;
            GameController.ganzua = datos.ganzua;
            GameController.formula = datos.formula;
            GameController.vidas = datos.vidas;
            GameController.corazones = datos.corazones;
            Heart_Bar.Phearts = datos.corazones;
            Heart_Bar.life = datos.vidas;
            GameController.TypeLife = datos.tipo;
            GameController.HeartsMax = datos.corazonesMax;
            GameController.LifeMax = datos.vidasMax;

            Debug.Log("Noombre de escenaaaaaaaaaaaaaaaaaaa " + nombreEscena);
            
        }
        else { Debug.Log("No se encontro el archivo"); }
    }
    int x = 0, y=0;
    public void cargar1()
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
            
            
            if (morir == 1)
            {
                datos.nombreEscena = datos.nombreEscena1;
                nombreEscena = datos.nombreEscena;
                Debug.Log("Nombre escena datos " + datos.nombreEscena);
                Debug.Log("Nombre escena datos 1 " + datos.nombreEscena1);
                Debug.Log("Nombre escena " + nombreEscena);
                if (y==0)
                {
                    SceneManager.LoadScene(nombreEscena);
                    y++;
                }
                
                //Datos sobre la vida
                enemigosFalse();
                datos.vidas = GameController.LifeMax;
                datos.corazones = GameController.HeartsMax;
                datos.tipo = GameController.TypeLife;
                //Datos de respaldo metidos a datos
                Debug.Log("Cargar al morir");
                Debug.Log("Nombre de escena" + datos.nombreEscena1);
                Debug.Log("Bolsa " + datos.bolsa1);
                
                datos.pila = datos.pila1;
                datos.bolsa = datos.bolsa1;
                datos.carton = datos.carton1;
                datos.manzana = datos.manzana1;
                datos.platano = datos.platano1;
                datos.lata = datos.lata1;
                datos.normal = datos.normal1;
                datos.paralizante = datos.paralizante1;
                datos.desactivadora = datos.desactivadora1;
                datos.tranquilizante = datos.tranquilizante1;
                datos.pesada = datos.pesada1;
                datos.energia = datos.energia1;
                datos.curacion = datos.curacion1;
                datos.ganzua = datos.ganzua1;
                datos.formula = datos.formula1;
                morir = 0;
            }
            if (perder == 1)
            {
                Debug.Log("Al cargar vidas " + Heart_Bar.life + " En los datos " + datos.vidas);
                datos.vidas = datos.vidas - 1;
                Debug.Log(datos.vidas);
                Debug.Log("corazones maimos " + GameController.HeartsMax);
                datos.corazones = GameController.HeartsMax;
                
                enemigosFalse();
                nombreEscena = datos.nombreEscena;
                if (x == 0)
                {
                    SceneManager.LoadScene(nombreEscena);
                    x++;
                }
                perder = 0;
            }
            nombrePartida = datos.nombrePartida;
            
            radial.basura[0] = datos.pila;
            radial.basura[1] = datos.bolsa;
            radial.basura[2] = datos.carton;
            radial.basura[3] = datos.manzana;
            radial.basura[4] = datos.platano;
            radial.basura[5] = datos.lata;
            radial.esfera[0] = datos.normal;
            radial.esfera[1] = datos.paralizante;
            radial.esfera[2] = datos.desactivadora;
            radial.esfera[3] = datos.tranquilizante;
            radial.esfera[4] = datos.pesada;
            radial.especiales[0] = datos.energia;
            radial.especiales[1] = datos.curacion;
            radial.especiales[2] = datos.ganzua;
            GameController.lata = datos.lata;
            GameController.pila = datos.pila;
            GameController.bolsa = datos.bolsa;
            GameController.manzana = datos.manzana;
            GameController.platano = datos.platano;
            GameController.carton = datos.carton;
            GameController.normal = datos.normal;
            GameController.paralizante = datos.paralizante;
            GameController.desactivadora = datos.desactivadora;
            GameController.tranquilizante = datos.tranquilizante;
            GameController.pesada = datos.pesada;
            GameController.energia = datos.energia;
            GameController.curacion = datos.curacion;
            GameController.ganzua = datos.ganzua;
            GameController.formula = datos.formula;
            GameController.vidas = datos.vidas;
            GameController.corazones = datos.corazones;
            Heart_Bar.Phearts = datos.corazones;
            Heart_Bar.life = datos.vidas;
            GameController.TypeLife = datos.tipo;
            GameController.HeartsMax = datos.corazonesMax;
            GameController.LifeMax = datos.vidasMax;

            Debug.Log("Noombre de escenaaaaaaaaaaaaaaaaaaa " + nombreEscena);
            
        }
        else { Debug.Log("No se encontro el archivo"); }
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
            radial.esfera[0] = datos.normal;
            radial.esfera[1] = datos.paralizante;
            radial.esfera[2] = datos.desactivadora;
            radial.esfera[3] = datos.tranquilizante;
            radial.esfera[4] = datos.pesada;
            radial.especiales[0] = datos.energia;
            radial.especiales[1] = datos.curacion;
            radial.especiales[2] = datos.ganzua;
            GameController.lata = datos.lata;
            GameController.pila = datos.pila;
            GameController.bolsa = datos.bolsa;
            GameController.manzana = datos.manzana;
            GameController.platano = datos.platano;
            GameController.carton = datos.carton;
            GameController.normal = datos.normal;
            GameController.paralizante = datos.paralizante;
            GameController.desactivadora = datos.desactivadora;
            GameController.tranquilizante = datos.tranquilizante;
            GameController.pesada = datos.pesada;
            GameController.energia = datos.energia;
            GameController.curacion = datos.curacion;
            GameController.ganzua = datos.ganzua;
            GameController.formula = datos.formula;
            GameController.vidas = datos.vidas;
            GameController.corazones = datos.corazones;
            Heart_Bar.Phearts = datos.corazones;
            Heart_Bar.life = datos.vidas;
            GameController.TypeLife = datos.tipo;
            GameController.HeartsMax = datos.corazonesMax;
            GameController.LifeMax = datos.vidasMax;
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

            name = GameObject.Find("InputField").GetComponent<InputField>();

            if (contador == 1)
            {
                nombre1 = name.text;
                nombrePartida1 = name.text;
                dato.nombre1 = nombre1;
                contador += 1;
                crearPartida();
            }
            else if (contador == 2)
            {
                nombre2 = name.text;
                nombrePartida1 = name.text;
                dato.nombre2 = nombre2;
                contador += 1;
                crearPartida();
            }
            else if (contador == 3)
            {
                nombre3 = name.text;
                nombrePartida1 = name.text;
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
        Debug.Log("Nombre actual en guardar contador " + dato.nombreActual);
        GameController.nombreActualPartida = dato.nombreActual;
        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();

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
            Debug.Log("Checkpoint 1 " + nombrePartida);
            nombreEscena = SceneManager.GetActiveScene().name;
            Debug.Log("Nombre de la escena" + nombreEscena);
            guardar();
        }
        if(collision.gameObject.tag =="Checkpoint2")
        {
            Debug.Log("Chechkpoint 2 " + nombrePartida);
            nombreEscena = SceneManager.GetActiveScene().name;
            guardar1();
        }
        if (collision.gameObject.tag == "Checkpoint3")
        {
            Debug.Log("Chechkpoint 5 " + nombrePartida);
            nombreEscena = SceneManager.GetActiveScene().name;
            GameController.LobbyCAP = 5;
            guardarCap5();
        }
        if (collision.gameObject.tag == "Checkpoint4")
        {
            paso = 1;
            Debug.Log("Checkpoint recuperar cap  5 " + nombrePartida);
            nombreEscena = SceneManager.GetActiveScene().name;
            recuperarCap5();
        }
    }
}

//Esta clase nos serializa los datos de las partidas
[Serializable()]//Datos listos para serializar
class DatosJuego : System.Object
{
    public String nombrePartida, nombreEscena;
    public int pila, manzana, platano, bolsa, carton, lata, normal, paralizante, desactivadora, tranquilizante, pesada, energia, curacion, ganzua;
    public int formula;
    public int vidas, corazones, tipo, corazonesMax, vidasMax;
    public String nombreEscena1;
    public int pila1, manzana1, platano1, bolsa1, carton1, lata1, normal1, paralizante1, desactivadora1, tranquilizante1, pesada1, energia1, curacion1, ganzua1;
    public int formula1;
    public int vidas1, corazones1, tipo1, corazonesMax1, vidasMax1;
}


//Esta clase serializa el archivo contando partida
[Serializable()]
class DatosPartidas : System.Object
{
    public string nombre1, nombre2, nombre3;
    public string nombreActual;
    public int contador;
    public int pila, manzana, platano, bolsa, carton, lata, normal, paralizante, desactivadora, tranquilizante, pesada, energia, curazion, ganzua;
    public int formula;
    public int vidas, corazones, tipo, corazonesMax, vidasMax;
}

