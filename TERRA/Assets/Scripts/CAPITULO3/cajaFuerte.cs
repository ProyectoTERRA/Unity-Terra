using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (GameController.formula >= 8)
        {
            Debug.Log("YA HAY 8 FORMULAS");
            cientifico.SetActive(false);
            cientifica1.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject.name == "")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("playa");
            }
        }
    }
}
