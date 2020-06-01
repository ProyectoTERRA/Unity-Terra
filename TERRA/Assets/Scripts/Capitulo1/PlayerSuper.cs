using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private GameObject OBJ_Lata1Key;
    [SerializeField] private GameObject OBJ_Lata2;
    [SerializeField] private GameObject OBJ_Awa;


    [SerializeField] private GameObject Key_DoorKey;
    [SerializeField] private GameObject Key_DoorFood;
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

    bool prexit, exit, key, pc, caja_fuerte, usedkey, CRoom1, CRoom2;

    bool lata1, lata2, awa, flag, flag1;
    static public bool Complete_mini;

    public bool s1, s2, cuarto;
    void Start()
    {
        CRoom1 = false;
        CRoom2 = false;
        Key_DoorFood.SetActive(false);
        Key_Key.SetActive(false);
        Key_Pc.SetActive(false);
        Key_Interruptor.SetActive(false);
        Key_Exit.SetActive(false);
        flag1 = false;
       
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
        usedkey = false;
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
            Key_DoorFood.SetActive(true);
            flag1 = true;
            
        }

        if (usedkey)
        {
            OBJ_Lata1Key.SetActive(false);
            Key_DoorKey.SetActive(false);
            List.select.Remove(KEY_inv);
            List.index = 0;
            usedkey = false;
        }

        if (CRoom1)
        {
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            this.transform.position = new Vector3(6f, -1.1f, 0.0f);
            CRoom1 = false;
        }
        if (CRoom2)
        {
            camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);
            this.transform.position = new Vector3(12f, -1.1f, 0.0f);
            CRoom2 = false;
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
        
        if (collision.gameObject.name == "Caja fuerte" &&Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Ganzua")
        {
           

               
                if (!Complete_mini)
                {
                    Key_Caja.SetActive(false);
                    Mini.SetActive(flag);
                    GetComponent<PlayerController>().enabled = false;
                    
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
                GameObject go = GameObject.Find("InvFunc");
                radial radial = go.GetComponent<radial>();
                GameController.pila = radial.basura[0];
                GameController.bolsa = radial.basura[1];
                GameController.carton = radial.basura[2];
                GameController.manzana = radial.basura[3];
                GameController.platano = radial.basura[4];
                GameController.lata = radial.basura[5];

                GameController.normal = radial.esfera[0];
                GameController.paralizante = radial.esfera[1];
                GameController.desactivadora = radial.esfera[2];
                GameController.tranquilizante = radial.esfera[3];
                GameController.pesada = radial.esfera[4];

                GameController.energia = radial.especiales[0];
                GameController.curacion = radial.especiales[1];
                GameController.ganzua = radial.especiales[2];
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
                OBJ_Lata1Key.GetComponent<Image>().sprite = KEY_inv.GetComponent<SpriteRenderer>().sprite;
                OBJ_Lata1Key.GetComponent<Image>().preserveAspect = true;
                OBJ_Lata1Key.SetActive(true);
                Destroy(KEY);
                key = true;
            }
        }

        if (collision.gameObject.name == "Lata Recargada 1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OBJ_Lata1Key.GetComponent<Image>().sprite = LATA1.GetComponent<SpriteRenderer>().sprite;
                OBJ_Lata1Key.GetComponent<Image>().preserveAspect = true;
                OBJ_Lata1Key.SetActive(true);
                Key_Lata1.SetActive(false);
                Destroy(LATA1);
                lata1 = true;
            }
        }

        if (collision.gameObject.name == "Lata Recargada 2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OBJ_Lata2.GetComponent<Image>().sprite = LATA2.GetComponent<SpriteRenderer>().sprite;
                OBJ_Lata2.GetComponent<Image>().preserveAspect = true;
                OBJ_Lata2.SetActive(true);
                Key_Lata2.SetActive(false);
                Destroy(LATA2);
                lata2 = true;
            }
        }

        if (collision.gameObject.name == "Botella de Agua")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OBJ_Awa.GetComponent<Image>().sprite = AWA.GetComponent<SpriteRenderer>().sprite;
                OBJ_Awa.GetComponent<Image>().preserveAspect = true;
                OBJ_Awa.SetActive(true);
                Key_Agua.SetActive(false);
                Destroy(AWA);
                awa = true;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado 1")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CRoom2 = true;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado 12")//compara si hizo la colision con el objeto correcto
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CRoom1 = true;
            }
        }

        if (collision.gameObject.name == "Puerta SuperMercado2" && flag1)//compara si hizo la colision con el objeto correcto
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
                usedkey = true;
            }
        }
    }
}