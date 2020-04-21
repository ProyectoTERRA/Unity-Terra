using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerCalle : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private GameObject img_obj_1;
    [SerializeField] private GameObject img_obj_2;
    [SerializeField] private GameObject img_obj_3;

    [SerializeField] private GameObject Key_Casa;
    [SerializeField] private GameObject Key_Palanca1;
    [SerializeField] private GameObject Key_Palanca2;
    [SerializeField] private GameObject Key_Alcantarilla;
    [SerializeField] private GameObject Key_Supermercado;

    [SerializeField] private GameObject img_fab;
    [SerializeField] private GameObject img_fab_1;
    [SerializeField] private GameObject img_fab_2;

    [SerializeField] private GameObject RAT1;
    [SerializeField] private GameObject RAT2;
    [SerializeField] private GameObject RAT3;
    [SerializeField] private GameObject RAT4;





    public bool s1, s2;

    public Image spr;
    public Sprite Palanca;
    public Sprite Palanca1;
    public Sprite Palanca2;

    public Sprite Lata;
    public Sprite AWA;

    private bool market, agarrar;
    private string nombre;

    

    // Start is called before the first frame update
    void Start()
    {
        market = false;

        Heart_Bar.Phearts = 6;

        img_fab.SetActive(false);
        img_fab_1.SetActive(false);
        img_fab_2.SetActive(false);

        if (GameController.Return)
        {
            if (GameController.bolsa1)
            {
                Destroy(GameObject.Find("bolsa1"));
            }
            if (GameController.bolsa2)
            {
                Destroy(GameObject.Find("bolsa2"));
            }
            if (GameController.bolsa3)
            {
                Destroy(GameObject.Find("bolsa3"));
            }
            if (GameController.lata1)
            {
                Destroy(GameObject.Find("lata1"));
            }
            if (GameController.lata2)
            {
                Destroy(GameObject.Find("lata2"));
            }
            if (GameController.lata3)
            {
                Destroy(GameObject.Find("lata3"));
            }
            if (GameController.carton1)
            {
                Destroy(GameObject.Find("carton1"));
            }
            if (GameController.carton2)
            {
                Destroy(GameObject.Find("carton2"));
            }

            RAT1.SetActive(true);
            RAT2.SetActive(true);
            RAT3.SetActive(true);
            RAT4.SetActive(true);

            camera.transform.position = new Vector3(18.0f, 2.0f, -10.0f);
            Key_Supermercado.SetActive(false);
            Key_Casa.SetActive(true);
            Destroy(GameObject.Find("Palanca1"));
            Destroy(GameObject.Find("Palanca2"));
            Key_Palanca1.SetActive(false);
            Key_Palanca2.SetActive(false);
            Key_Alcantarilla.SetActive(false);
            s2 = true;
            s1 = false;
            transform.position = new Vector3(24.8f, -.75f);
            img_obj_1.GetComponent<Image>().sprite = Lata;
            img_obj_1.GetComponent<Image>().preserveAspect = true;
            img_obj_1.SetActive(true);
            img_obj_2.GetComponent<Image>().sprite = Lata;
            img_obj_2.GetComponent<Image>().preserveAspect = true;
            img_obj_2.SetActive(true);
            img_obj_3.GetComponent<Image>().sprite = AWA;
            img_obj_3.GetComponent<Image>().preserveAspect = true;
            img_obj_3.SetActive(true);



        }
        else
        {
            RAT1.SetActive(false);
            RAT2.SetActive(false);
            RAT3.SetActive(false);
            RAT4.SetActive(false);
            Key_Palanca1.SetActive(false);
            Key_Palanca2.SetActive(false);
            camera.transform.position = new Vector3(0.0f, 2.0f, -10.0f);
            Key_Casa.SetActive(false);
            Key_Alcantarilla.SetActive(false);
            transform.position = new Vector3(-5.77f, -.75f);
            s1 = true;
            s2 = false;
        }
        



        

        radial.objFab = "Palanca";

        spr = img_fab.GetComponent<Image>();
        img_fab.GetComponent<SpriteRenderer>().sprite = Palanca;
        spr.sprite = Palanca;
        spr = img_fab_1.GetComponent<Image>();
        spr.sprite = Palanca1;
        spr = img_fab_2.GetComponent<Image>();
        spr.sprite = Palanca2;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerController.Equip);
        if (radial.pl)
        {
            img_obj_1.SetActive(false);
            img_obj_2.SetActive(false);
        }

        if (agarrar)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            if (nombre == "lata1")
            {

                GameController.lata++;
                radial.basura[5]++;
                Destroy(GameObject.Find(nombre));
                GameController.lata1 = true;


            }
            else if (nombre == "lata2")
            {

                GameController.lata++;
                radial.basura[5]++;
                Destroy(GameObject.Find(nombre));
                GameController.lata2 = true;

            }
            else if (nombre == "lata3")
            {

                GameController.lata++;
                radial.basura[5]++;
                Destroy(GameObject.Find(nombre));
                GameController.lata3 = true;


            }
            else if (nombre == "carton1")
            {
                GameController.carton++;
                radial.basura[2]++;
                Destroy(GameObject.Find(nombre));
                GameController.carton1 = true;
            }
            else if (nombre == "carton2")
            {
                GameController.carton++;
                radial.basura[2]++;
                Destroy(GameObject.Find(nombre));
                GameController.carton2 = true;
            }
            else if (nombre == "bolsa1")
            {
                GameController.bolsa++;
                radial.basura[1]++;
                Destroy(GameObject.Find(nombre));
                GameController.bolsa1 = true;
            }
            else if (nombre == "bolsa2")
            {
                GameController.bolsa++;
                radial.basura[1]++;
                Destroy(GameObject.Find(nombre));
                GameController.bolsa2 = true;
            }
            else if (nombre == "bolsa3")
            {
                GameController.bolsa++;
                radial.basura[1]++;
                Destroy(GameObject.Find(nombre));
                GameController.bolsa3 = true;
            }

            agarrar = false;
        }
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tran1" && s1)//compara si hizo la colision con el objeto correcto
        {


            s1 = false;
            s2 = true;
            camera.transform.position = new Vector3(18.0f, 2.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if (collision.gameObject.name == "Tran2" && s2)//compara si hizo la colision con el objeto correcto
        {
            s1 = true;
            s2 = false;
            camera.transform.position = new Vector3(0.0f, 2.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("S");
        if (collision.gameObject.name == "Palanca1" && market)//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spr = img_obj_1.GetComponent<Image>();
                spr.sprite = Palanca1;
                spr.preserveAspect = true;
                img_obj_1.SetActive(true);
                Destroy(GameObject.Find("Palanca1"));
                Key_Palanca1.SetActive(false);
                radial.pl1 = true;

            }

        }

        if (collision.gameObject.name == "PuertaSuperMArket" && Input.GetKeyDown(KeyCode.E) && !market && !GameController.Return)
        {
            img_fab.SetActive(true);
            img_fab_1.SetActive(true);
            img_fab_2.SetActive(true);
            Key_Palanca1.SetActive(true);
            Key_Palanca2.SetActive(true);
            market = true;
            Key_Supermercado.SetActive(false);
            Key_Alcantarilla.SetActive(true);
        }

        if (collision.gameObject.name == "Alcantarilla")//compara si hizo la colision con el objeto correcto
        { 
            Debug.Log("S");
            if (Input.GetKeyDown(KeyCode.J) && radial.pl && PlayerController.Equip == "Image" && !GameController.Return && market)
            {
                Debug.Log("Salido");
                SceneManager.LoadScene("Alcantarillas");
            }

        }
        if (collision.gameObject.name == "PuertaCasa")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E) && GameController.Return)
            {
                Debug.Log("Salido");
                SceneManager.LoadScene("CasaReturn");
            }

        }
        if (collision.gameObject.name == "Palanca2")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E) && market)
            {
                spr = img_obj_2.GetComponent<Image>();
                spr.sprite = Palanca2;
                img_obj_2.GetComponent<Image>().preserveAspect = true;
                img_obj_2.SetActive(true);
                Destroy(GameObject.Find("Palanca2"));
                Key_Palanca2.SetActive(false);
                radial.pl2 = true;

            }

        }
        if (collision.gameObject.tag == "BolsaFAKE" && PlayerController.Equip == "Recogedor")
        {

            nombre = collision.gameObject.name;
            agarrar = true;

        }

        if (collision.gameObject.tag == "CartonFAKE" && PlayerController.Equip == "Recogedor")
        {

            nombre = collision.gameObject.name;
            agarrar = true;
        }

        if (collision.gameObject.tag == "LataFAKE" && PlayerController.Equip == "Recogedor")
        {
            nombre = collision.gameObject.name;
            agarrar = true;
        }
    }
}
