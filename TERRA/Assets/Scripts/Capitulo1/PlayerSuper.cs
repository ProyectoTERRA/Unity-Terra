using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSuper : MonoBehaviour
{
    [SerializeField] private GameObject camera;



    [SerializeField] private GameObject Caja;
    [SerializeField] private GameObject PC;
    [SerializeField] private GameObject KEY;
    [SerializeField] private GameObject KEY_inv;
    [SerializeField] private GameObject interruptor;

    [SerializeField] private GameObject LATA1;
    [SerializeField] private GameObject LATA2;
    [SerializeField] private GameObject AWA;

    [SerializeField] private GameObject Key_Caja;
    [SerializeField] private GameObject Key_Key;
    [SerializeField] private GameObject Key_Pc;
    [SerializeField] private GameObject Key_Exit;
    [SerializeField] private GameObject Key_Interruptor;
    [SerializeField] private GameObject Key_Lata1;
    [SerializeField] private GameObject Key_Lata2;
    [SerializeField] private GameObject Key_Agua;

    [SerializeField] private GameObject Mini;

    [SerializeField] private GameObject Equip;


    public Sprite CajaA, CajaC;
    public Sprite PCOff, PCON;
    public Sprite IntON;

    // Start is called before the first frame update

    bool prexit, exit, key, pc, caja_fuerte;

    bool lata1, lata2, awa, flag, flag1;
    static public bool Complete_mini;

    public bool s1, s2, cuarto;
    void Start()
    {
        Key_Key.SetActive(false);
        Key_Pc.SetActive(false);
        Key_Interruptor.SetActive(false);
        Key_Exit.SetActive(false);
        flag1 = false;
        Heart_Bar.Phearts = 6;
        flag = true;
        Mini.SetActive(false);
        camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        key = false;
        s1 = true;
        s2 = false;
        cuarto = false;
        lata1 = false;
        lata2 = false;
        awa = false;
        Caja.GetComponent<SpriteRenderer>().sprite = CajaC;
        interruptor.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        if(lata1 && lata2 && awa)
        {
            Key_Interruptor.SetActive(true);
            lata1 = false;
            lata2 = false;
            awa = false;
            flag1 = true;
            
        }

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


    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Caja fuerte")
        {
            if (Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Ganzua")
            {

                Key_Caja.SetActive(false);
                if (!Complete_mini)
                {
                    Mini.SetActive(flag);
                    GetComponent<PlayerController>().enabled = !flag;
                    flag = !flag;
                    
                }

            }

            if (Complete_mini)
            {
                Caja.GetComponent<SpriteRenderer>().sprite = CajaA;
                if (!key)
                {
                    KEY.SetActive(true);
                    Key_Key.SetActive(true);

                }
            }
        }
        if (collision.gameObject.name == "Interruptor" && flag1)
        {
            if (Input.GetKeyDown(KeyCode.E) && !prexit)
            {
                Key_Interruptor.SetActive(false);
                Key_Pc.SetActive(true);
                interruptor.GetComponent<SpriteRenderer>().color = Color.white;
                prexit = true;
                PC.GetComponent<SpriteRenderer>().sprite = PCOff;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado 4")
        {
            if (Input.GetKeyDown(KeyCode.E) && exit)
            {
                Debug.Log("SALIDO");
                GameController.Return = true;
                SceneManager.LoadScene("Calle");
            }
        }

        if (collision.gameObject.name == "PC" && prexit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Key_Pc.SetActive(false);
                Key_Exit.SetActive(true);
                interruptor.GetComponent<SpriteRenderer>().sprite = IntON;
                exit = true;
                PC.GetComponent<SpriteRenderer>().sprite = PCON;
            }
        }

        if (collision.gameObject.name == "key")
        {
            if (Input.GetKeyDown(KeyCode.E) && !key)
            {
                Key_Key.SetActive(false);
                Debug.Log("key");
                List.select.Add(KEY_inv);
                Destroy(KEY);
                key = true;
            }
        }

        if (collision.gameObject.name == "Lata Recargada 1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Key_Lata1.SetActive(false);
                Destroy(LATA1);
                lata1 = true;
            }
        }

        if (collision.gameObject.name == "Lata Recargada 2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Key_Lata2.SetActive(false);
                Destroy(LATA2);
                lata2 = true;
            }
        }

        if (collision.gameObject.name == "Botella de Agua")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Key_Agua.SetActive(false);
                Destroy(AWA);
                awa = true;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado 1")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);
                this.transform.position = new Vector3(12f, -1.1f, 0.0f);


            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado 12")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
                this.transform.position = new Vector3(6f, -1.1f, 0.0f);

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
            if (Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "key_inv")
            {
                camera.transform.position = new Vector3(36f, 0.0f, -10.0f);
                this.transform.position = new Vector3(30f, -1.1f, 0.0f);

            }
        }
    }
}