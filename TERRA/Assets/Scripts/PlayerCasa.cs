using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCasa : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private GameObject Key_DoorPlayer;
    [SerializeField] private GameObject Key_DoorLucySala;
    [SerializeField] private GameObject Key_DoorSalaLucy;
    [SerializeField] private GameObject Key_DoorCalle;

    [SerializeField] private GameObject Key_Lucy;
    [SerializeField] private GameObject Key_Linterna;

    public bool lucy;
    public bool linterna;
    private int basuraL, basuraP, basuraC, basuraM;

    private bool agarrar, trash;
    private string nombre, tag;

    // Start is called before the first frame update
    void Start()
    {
        trash = false;
        Heart_Bar.Phearts = 6;

        Key_DoorPlayer.SetActive(false);
        Key_DoorLucySala.SetActive(false);
        Key_DoorCalle.SetActive(false);

        camera.transform.position = new Vector3(0.0f, 3.0f, -10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);

        transform.position = new Vector3(-6.4f, 0.5f);
        transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

        basuraL = 0;
        basuraP = 0;
        basuraC = 0;
        basuraM = 0;

        lucy = false;
        linterna = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (basuraL >= 4 && basuraC >=2 && basuraP >= 2 && basuraM >=1 )
        {
            Key_DoorPlayer.SetActive(true);
            trash = true;
        }
        if (agarrar)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            if (tag == "LataFAKE")
            {

                GameController.lata++;
                radial.basura[5]++;
                Destroy(GameObject.Find(nombre));
                basuraL++;

            }
            else if (tag == "CartonFAKE")
            {
                GameController.carton++;
                radial.basura[2]++;
                Destroy(GameObject.Find(nombre));
                basuraC++;
            }
            else if (tag == "PlatanoFAKE")
            {
                GameController.platano++;
                radial.basura[4]++;
                Destroy(GameObject.Find(nombre));
                basuraP++;
            }
            else if (tag == "ManzanaFAKE")
            {
                GameController.manzana++;
                radial.basura[3]++;
                Destroy(GameObject.Find(nombre));
                basuraM++;
            }
            agarrar = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LataFAKE")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }
        if (collision.gameObject.tag == "PlatanoFAKE")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }
        if (collision.gameObject.tag == "CartonFAKE")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }

        if (collision.gameObject.tag == "ManzanaFAKE")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }
        if (collision.gameObject.tag == "PuertaLucy" && trash)//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                transform.position = new Vector3(16.8f, 0.5f);
                transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                camera.transform.position = new Vector3(18.0f, 3.0f, -10.0f);
                camera.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (collision.gameObject.tag == "PuertaSala")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E) && lucy)
            {
                Debug.Log("Tecla e");
                transform.position = new Vector3(30.6f, 0.5f);
                transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                camera.transform.position = new Vector3(36.0f, 3.0f, -10.0f);
                camera.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (collision.gameObject.tag == "Lucy")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a Lucy");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                lucy = true;
                Key_DoorLucySala.SetActive(true);
                Key_Lucy.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "PuertaCalle")//compara si hizo la colision con el objeto correcto
        {

            if (Input.GetKeyDown(KeyCode.E) && linterna)
            {

                Debug.Log("Salido");
                SceneManager.LoadScene("Calle");
            }
        }

        if (collision.gameObject.tag == "linterna")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a LINTERNA");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Has agarrado la linterna");
                linterna = true;
                Destroy(GameObject.Find("linterna"));
                Key_DoorCalle.SetActive(true);
                GameController.linterna = true;
                Key_Linterna.SetActive(false);
            }
        }



    }
}
