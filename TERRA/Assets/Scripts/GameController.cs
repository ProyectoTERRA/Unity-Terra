using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int pila, bolsa, carton, manzana, platano, lata, llave, formula, normal, paralizante, desactivadora, tranquilizante, pesada, energia, curacion, ganzua, life;
    public static bool start;
    public static int vidas, corazones, tipo;
    public static string nombreActualPartida;

    //----- Equipment/Lobby------
    public static bool LOBBY;
    public static int LobbyCAP;

    public static string H1Equip;
    public static string H2Equip;


    public static int LifeMax, TypeLife, HeartsMax;

    public static bool DJumpUnlock, LJumpUnlock, DashUnlock, InvisibleUnlock, x4HeartsUnlock, x5HeartsUnlock, x4LifesUnlock, x5LifesUnlock;



    //----Variable Singleton--
    public static GameController instance = null;

    //----Variables CAP.1-----

    public static bool linterna, Return, bolsa1, bolsa2, bolsa3, lata1, lata2, lata3, carton1, carton2;
    
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Game controller " + nombreActualPartida);


    }
    private void Awake()
    {

        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject); 
        DontDestroyOnLoad(gameObject);
    }
   
}
