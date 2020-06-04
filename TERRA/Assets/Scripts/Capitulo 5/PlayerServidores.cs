using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerServidores : MonoBehaviour
{
    [SerializeField] private GameObject list;

    [SerializeField] private GameObject Key_Energy;
    [SerializeField] private GameObject Key_Door;

    [SerializeField] private GameObject Mini;
    [SerializeField] private GameObject Guard;
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;

    [SerializeField] private GameObject Energy;
    public Sprite door;
    private bool ActM;
    static public bool dies;
    private GameObject name;
    // Start is called before the first frame update
    void Start()
    {

        ActM = false;
        dies = false;

        Key_Door.SetActive(false);
        Mini.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown.ZERO)
        {
            
            StartCoroutine(push2());
            
        }
        if (MinijuegoServidores.win)
        {
            Key_Door.SetActive(true);
            Door2.GetComponent<SpriteRenderer>().sprite = door;
        }
        if (ActM)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[0]--;
            string normal = "energy";
            if (radial.especiales[0] <= 0) list.SendMessage("remove", normal);

            Energy.GetComponent<SpriteRenderer>().color = Color.white;

            ActM = false;
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Activator" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0")
        {
            Key_Energy.SetActive(false);
            ActM = true;
           
            Mini.SetActive(true);
            Debug.Log("AAAA");
        }
        if (collision.gameObject.name == "CargoElPayaso2")
        {
            Debug.Log("Ha hecho colision con el jugador");

            Prueba.die = true;
            dies = true;
            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(transform.position.x, -1.4f);


            push();
        }
        if (collision.gameObject.name == "DoorOpenPanel 1" && Input.GetKeyDown(KeyCode.E) && MinijuegoServidores.win)
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
            Debug.Log("NEEEEEEEEEEEEEXT");
            SceneManager.LoadScene("Corredores");

        }

    }
    public IEnumerator push2()
    {

        Door1.GetComponent<SpriteRenderer>().sprite = door;
        yield return new WaitForSeconds(.5f);
        Destroy(Mini);
        Guard.SetActive(true);


    }
  
    public void push()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Heart_Bar.Phearts = 0;


    }
}
