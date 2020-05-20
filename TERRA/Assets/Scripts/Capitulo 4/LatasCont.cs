using UnityEngine;
using UnityEngine.SceneManagement;

public class LatasCont : MonoBehaviour
{
    int latas, contador = 120, cont = 0;

    public void Update()
    {
        PlayerController.Equip = "Recogedor";
        Debug.Log(PlayerController.Equip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "lata")
        {

            latas++;
            Debug.Log("Numero de latas " + latas);
            if (latas == 30)
            {
                SceneManager.LoadScene("Plataforma");
            }
        }
    }
}
