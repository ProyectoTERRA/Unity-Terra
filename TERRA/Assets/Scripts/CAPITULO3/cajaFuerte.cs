using UnityEngine;
using UnityEngine.SceneManagement;

public class cajaFuerte : MonoBehaviour
{
    public GameObject formula, cientifico, cientifica1, llave;
    public int comprobar;
    int x =0;
    void Update()
    {
        Debug.Log("Numero de llaveeeeee " + GameController.llave);
        if (comprobar != 1)
        {
            if (GameController.llave == 1)
            {
                llave.SetActive(true);
                GameController.llave++;
                Debug.Log("Llave   " + GameController.llave);
            }
        }
        
        if (GameController.formula >= 8)
        {
            Debug.Log("YA HAY 8 FORMULAS");
            cientifico.SetActive(false);
            cientifica1.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "cajaFuerte")
        {
            Debug.Log("Colision con caja fuerte");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameController.llave == 2 && x != 1)
                {
                    formula.SetActive(true);
                    GameController.llave++;
                    x = 1;
                }                
            }
        }
    }
}
