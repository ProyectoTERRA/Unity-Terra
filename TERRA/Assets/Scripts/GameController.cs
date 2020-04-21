using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int pila, bolsa, carton, manzana, platano, lata, llave, formula, normal, paralizante, desactivadora, tranquilizante, pesada, energia, curacion, ganzua, life;
    public static bool start;
    public static int vidas, corazones;


    //----Variable Singleton--
    public static GameController instance = null;

    //----Variables CAP.1-----

    public static bool linterna, Return, bolsa1, bolsa2, bolsa3, lata1, lata2, lata3, carton1, carton2;
    
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
=======
     
        
>>>>>>> c5853222c64693afcb9c93b44470ce568b0196e8
        /*
        Debug.Log("Pila en gameController " + pila);
        Debug.Log("Bolsa en gameController " + bolsa);
        Debug.Log("Carton en gameController " + carton);
        Debug.Log("Manzana en gameController " + manzana);
        Debug.Log("Platano en gameController " + platano);
        Debug.Log("Lata en gameController " + lata);*/

    }
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject); 
        DontDestroyOnLoad(gameObject);
    }
   
}
