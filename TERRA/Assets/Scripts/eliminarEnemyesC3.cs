using UnityEngine;

public class eliminarEnemyesC3 : MonoBehaviour
{
    public static int guardias;
    public GameObject puerta, formula, formula2;
    private int x;
    private bool inicia;
    public void Start()
    {
        guardias = 0;
        x = 0;
        inicia = true;
    }
    void Update()
    {
        if (guardias == 7)
        {
            Debug.Log(guardias);
            puerta.SetActive(true);
            if (x == 0)
            {
                formula.SetActive(true);
                formula2.SetActive(true);
                x = 1;
            }
        }
        if (inicia)
        {
            Debug.Log("iniciaaaaa");
            if (GameController.e1)
            {
                Destroy(GameObject.Find("e1"));
            }
            if (GameController.e2)
            {
                Destroy(GameObject.Find("e2"));
            }
            if (GameController.e3)
            {
                Destroy(GameObject.Find("e3"));
            }
            if (GameController.e4)
            {
                Destroy(GameObject.Find("e4"));
            }
            if (GameController.e5)
            {
                Destroy(GameObject.Find("e5"));
            }
            if (GameController.e6)
            {
                Destroy(GameObject.Find("e6"));
            }
            if (GameController.e7)
            {
                Destroy(GameObject.Find("e7"));
            }
            if (GameController.b1)
            {
                Destroy(GameObject.Find("b1"));
            }
            if (GameController.b2)
            {
                Destroy(GameObject.Find("b2"));
            }
            if (GameController.b3)
            {
                Destroy(GameObject.Find("b3"));
            }
            if (GameController.b4)
            {
                Destroy(GameObject.Find("b4"));
            }
            if (GameController.b5)
            {
                Destroy(GameObject.Find("b5"));
            }

            inicia = false;
        }
        
    }
}
