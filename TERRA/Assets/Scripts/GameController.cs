using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int pila, bolsa, carton, manzana, platano, lata, llave, formula;
    // Start is called before the first frame update
    void Start()
    {/*
        Debug.Log("Pila en gameController " + pila);
        Debug.Log("Bolsa en gameController " + bolsa);
        Debug.Log("Carton en gameController " + carton);
        Debug.Log("Manzana en gameController " + manzana);
        Debug.Log("Platano en gameController " + platano);
        Debug.Log("Lata en gameController " + lata);*/        
    }
    public void Update()
    {

    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
