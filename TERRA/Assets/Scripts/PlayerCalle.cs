using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerCalle : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private GameObject img_obj_1;
    [SerializeField] private GameObject img_obj_2;
    [SerializeField] private GameObject img_obj_3;
    [SerializeField] private GameObject img_obj_4;
    [SerializeField] private GameObject img_obj_5;
    [SerializeField] private GameObject img_obj_6;

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

    private bool market;

    // Start is called before the first frame update
    void Start()
    {
        market = false;

        Heart_Bar.Phearts = 6;
        

        if (GameController.Return)
        {
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
        if (GameController.Return)
        {
           
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
                Destroy(GameObject.Find("Palanca1"));
                Key_Palanca1.SetActive(false);
                radial.pl1 = true;

            }

        }

        if (collision.gameObject.name == "PuertaSuperMArket" && Input.GetKeyDown(KeyCode.E) && !market && !GameController.Return)
        {
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
                Destroy(GameObject.Find("Palanca2"));
                Key_Palanca2.SetActive(false);
                radial.pl2 = true;

            }

        }
    }
}
