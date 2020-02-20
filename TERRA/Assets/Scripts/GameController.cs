using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int pila, bolsa, carton, manzana, platano, lata, llave, formula, normal, paralizante, desactivadora, tranquilizante, pesada, energia, curacion, ganzua;
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
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
