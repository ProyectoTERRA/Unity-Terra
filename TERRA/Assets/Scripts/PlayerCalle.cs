using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [SerializeField] private GameObject img_fab;
    [SerializeField] private GameObject img_fab_1;
    [SerializeField] private GameObject img_fab_2;





    public bool s1, s2;

    public Image spr;
    public Sprite Palanca;
    public Sprite Palanca1;
    public Sprite Palanca2;

    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);

        transform.position = new Vector3(-7f, -.75f);



        s1 = true;
        s2 = false;

        radial.objFab = "Palanca";

        spr = img_fab.GetComponent<Image>();
        spr.sprite = Palanca;
        spr = img_fab_1.GetComponent<Image>();
        spr.sprite = Palanca1;
        spr = img_fab_2.GetComponent<Image>();
        spr.sprite = Palanca2;

    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("S");
        if (collision.gameObject.name == "Palanca1")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spr = img_obj_1.GetComponent<Image>();
                spr.sprite = Palanca1;
                Destroy(GameObject.Find("Palanca1"));

                radial.pl1 = true;

            }

        }

        if (collision.gameObject.name == "Alcantarilla")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("S");
            if (Input.GetKeyDown(KeyCode.E) && radial.pl)
            {
                Debug.Log("Salido");

            }

        }

        if (collision.gameObject.name == "Palanca2")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spr = img_obj_2.GetComponent<Image>();
                spr.sprite = Palanca2;
                Destroy(GameObject.Find("Palanca2"));

                radial.pl2 = true;

            }

        }
    }
}
