using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuper : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject puerta;

    [SerializeField] private GameObject Bloque;
    [SerializeField] private GameObject Caja;
    [SerializeField] private GameObject KEY;

    [SerializeField] private GameObject LATA1;
    [SerializeField] private GameObject LATA2;
    [SerializeField] private GameObject AWA;

    public Sprite CajaA, CajaC;

    // Start is called before the first frame update

    bool prexit, exit, key, pc, caja_fuerte;

    bool lata1, lata2, awa;

    public bool s1, s2, cuarto;
    void Start()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        key = false;
        s1 = true;
        s2 = false;
        cuarto = false;
        lata1 = false;
        lata2 = false;
        awa = false;
        Caja.GetComponent<SpriteRenderer>().sprite = CajaC;
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
            camera.transform.position = new Vector3(-18.0f, 0.0f, -10.0f);


        }

        if (collision.gameObject.name == "Tran2" && s2)//compara si hizo la colision con el objeto correcto
        {
            s1 = true;
            s2 = false;
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    void OnMouseOver()
    {
        Debug.Log(gameObject.name);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Caja fuerte")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Caja.GetComponent<SpriteRenderer>().sprite = CajaA;
                if (!key)
                {
                    KEY.SetActive(true);
                }

            }
        }

        if (collision.gameObject.name == "key")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("key");
                Destroy(KEY);
                key = true;
            }
        }

        if (collision.gameObject.name == "Lata Recargada 1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(LATA1);
                lata1 = true;
            }
        }

        if (collision.gameObject.name == "Lata Recargada 2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(LATA2);
                lata2 = true;
            }
        }

        if (collision.gameObject.name == "Botella de Agua")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(AWA);
                awa = true;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado 1")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(cuarto);

                if (cuarto == false)
                {
                    Bloque.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                    puerta.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                    camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);
                    puerta.transform.position = new Vector3(9.4f, -1f, 0f);
                    puerta.transform.localScale = new Vector3(1f, 0.83f, 0f);
                    this.transform.position = new Vector3(10.85f, -1.1f, 0.0f);

                }

                else if (cuarto == true)
                {
                    Bloque.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    puerta.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    puerta.transform.position = new Vector3(8.5f, -1f, 0f);
                    camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
                    puerta.transform.localScale = new Vector3(0.83f, 0.83f, 0f);
                    this.transform.position = new Vector3(7.1f, -1.1f, 0.0f);


                }

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                cuarto = !cuarto;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado2")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
                this.transform.position = new Vector3(-7f, -1.1f, 0.0f);
            }
        }
        if (collision.gameObject.name == "Puerta SuperMercado3" && key == true)//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera.transform.position = new Vector3(36f, 0.0f, -10.0f);
                this.transform.position = new Vector3(30f, -1.1f, 0.0f);
            }
        }
    }
}