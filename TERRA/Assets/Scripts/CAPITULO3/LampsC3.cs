using UnityEngine;
using UnityEngine.SceneManagement;

public class LampsC3 : MonoBehaviour
{
    public GameObject faroV, faroR, faroAma, faroAzul, hoja;
    public string nombreEscena;
    int contadorHojas = 0;
    private bool v = false, r = false, ama = false, azul = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "lampara1")
        {
            azul = true;
            if (r && v && ama)
            {
                hoja.SetActive(true);
            }
            else
            {
                r = false;
                v = false;
                azul = false;
                ama = false;
                faroAma.SetActive(false);
                faroAzul.SetActive(false);
                faroR.SetActive(false);
                faroV.SetActive(false);
            }
            faroAzul.SetActive(true);
        }
        if (collision.gameObject.name == "lampara2")
        {
            faroAma.SetActive(true);
            ama = true;
            if (r || azul)
            {
                r = false;
                azul = false;
                v = false;
                ama = false;
                faroR.SetActive(false);
                faroAzul.SetActive(false);
                faroV.SetActive(false);
                faroAma.SetActive(false);
            }
        }
        if (collision.gameObject.name == "lampara3")
        {
            faroR.SetActive(true);
            r = true;
            if (azul)
            {
                azul = false;
                v = false;
                ama = false;
                r = false;
                faroAzul.SetActive(false);
                faroV.SetActive(false);
                faroAma.SetActive(false);
                faroR.SetActive(false);
            }
        }
        if (collision.gameObject.name == "lampara4")
        {
            faroV.SetActive(true);
            v = true;
            if (r || ama || azul)
            {
                r = false;
                ama = false;
                azul = false;
                v = false;
                faroV.SetActive(false);
                faroR.SetActive(false);
                faroAma.SetActive(false);
                faroAzul.SetActive(false);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "formula")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                contadorHojas++;
                string nombre = collision.gameObject.name;
                Destroy(GameObject.Find(nombre));
                if (contadorHojas > 4)
                {
                    SceneManager.LoadScene(nombreEscena);
                }
            }
        }
    }
}
