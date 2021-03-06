﻿using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int pila, bolsa, carton, manzana, platano, lata, llave, formula, normal, paralizante;
    public static int desactivadora, tranquilizante, pesada, energia, curacion, ganzua, life;
    public static bool start;
    public static int vidas, corazones, tipo;
    public static string nombreActualPartida;

    

    //Variables para el respaldo
    public static string nombreEscena0;
    public static int pila0, bolsa0, carton0, manzana0, platano0, lata0, normal0, paralizante0;
    public static int desactivadora0, tranquilizante0, pesada0, energia0, curacion0, ganzua0, formula0;

    //----- Equipment/Lobby------
    public static bool LOBBY;
    public static int LobbyCAP;
    public static bool CAP5;

    public static string H1Equip;
    public static string H2Equip;

    public static string H1Equip0;
    public static string H2Equip0;

    public static bool TequipCap5;
    public static int LifeMax, TypeLife, HeartsMax, TypeLife0;

    public static bool DJumpUnlock, LJumpUnlock, DashUnlock, InvisibleUnlock, x4HeartsUnlock, x5HeartsUnlock, x4LifesUnlock, x5LifesUnlock;

    

    //----Variable Singleton--
    public static GameController instance = null;

    //----Variables CAP.1-----

    public static bool linterna, Return, bolsa1, bolsa2, bolsa3, lata1, lata2, lata3, carton1, carton2;

    //-----Variables CAP.2-----Escena Refrigeracion-----------
    public static bool e1, e2, e3, e4, e5, e6, e7, b1, b2, b3, b4, b5, l1, l2, l3,l4, l5, m1, m2, m3, m4, m5;
    public static bool t1, t2, t3, t4, t5, t6, t7;

    public static bool breve;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game controller " + nombreActualPartida);
    }
    private void Update()
    {
        Debug.Log("Game controller nombre escena 0 " + nombreEscena0);
        Debug.Log("Game controler equipo 1  " + H1Equip);
        Debug.Log("Game controller equipo 2 " + H2Equip);
        Debug.Log("Vidas max  " + LifeMax);
        Debug.Log("Game controller type " + TypeLife);
        Debug.Log("Game controller type 0 " + TypeLife0);
        Debug.Log("Game controller Heartmax " + HeartsMax);

        Debug.Log("-------------datos------------");
        Debug.Log(pila0);
        Debug.Log(bolsa0);
        Debug.Log(carton0);
        Debug.Log(manzana0);
        Debug.Log(platano0);
        Debug.Log(lata0);
        Debug.Log(normal0);
        Debug.Log(paralizante0);
        Debug.Log(desactivadora0);
        Debug.Log(tranquilizante0);
        Debug.Log(pesada0);
        Debug.Log(curacion0);
        Debug.Log(ganzua0);
        Debug.Log("-------------Terminaaaaaaaa--");

    }
    private void Awake()
    {

        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject); 
        DontDestroyOnLoad(gameObject);
    }
   
}
