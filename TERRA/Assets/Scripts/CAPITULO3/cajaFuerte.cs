using UnityEngine;

public class cajaFuerte : MonoBehaviour
{
    public GameObject formula, cientifico, cientifica1;
    public int comprobar;
    void Update()
    {
        if (comprobar != 1)
        {
            if (GameController.llave == 1)
            {
                formula.SetActive(true);
                GameController.llave++;
            }
        }

        if (GameController.formula >= 7)
        {
            Debug.Log("YA HAY 7 FORMULAS");
            cientifico.SetActive(false);
            cientifica1.SetActive(true);
        }
    }
}
