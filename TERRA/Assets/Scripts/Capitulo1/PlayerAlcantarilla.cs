using UnityEngine;

public class PlayerAlcantarilla : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject minijuego;



    public bool s1, s2;
    private bool min;
    // Start is called before the first frame update
    void Start()
    {
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
            minijuego.SetActive(false);
        }
        else if (Minijuego_1.start && min)
        {
            minijuego.SetActive(true);
        }

        if (Minijuego_1.win)
        {
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
}
