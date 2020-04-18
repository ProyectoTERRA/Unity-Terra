using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAlcantarilla : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject minijuego;

    [SerializeField] private GameObject Key_Activator;
    [SerializeField] private GameObject Key_Escaleras;


    public bool s1, s2;
    private bool min;
    // Start is called before the first frame update
    void Start()
    {
        Key_Escaleras.SetActive(false);
        Heart_Bar.Phearts = 6;
        minijuego.SetActive(false);
        camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);
        s1 = true;
        s2 = false;
        min = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Minijuego_1.win)
        {
            Key_Escaleras.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (min)
            {
                Minijuego_1.start = !Minijuego_1.start;

            }
            else
            {
                Minijuego_1.start = false;
            }

        }
        if (!Minijuego_1.start)
        {
            Key_Activator.SetActive(true);
            minijuego.SetActive(false);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        else if (Minijuego_1.start && min)
        {
            Key_Activator.SetActive(false);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            minijuego.SetActive(true);
        }

        if (Minijuego_1.win)
        {
            StartCoroutine(Close());
            min = false;
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Interruptor" && Minijuego_1.win == false)//compara si hizo la colision con el objeto correcto
        {
            
            min = true;
        }

        if (collision.gameObject.name == "Escalera")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E) && Minijuego_1.win)
            {
                Debug.Log("Salido");
                SceneManager.LoadScene("Supermercado");

            }

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tran1" && s1)//compara si hizo la colision con el objeto correcto
        {


            s1 = false;
            s2 = true;
            camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if (collision.gameObject.name == "Tran2" && s2)//compara si hizo la colision con el objeto correcto
        {
            s1 = true;
            s2 = false;
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);

        }
        if (collision.gameObject.name == "Interruptor" && Minijuego_1.win == false)//compara si hizo la colision con el objeto correcto
        {
            min = false;
        }
    }
    IEnumerator Close()
    {

        yield return new WaitForSeconds(1f);
        minijuego.SetActive(false);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Key_Activator.SetActive(false);

    }
}
