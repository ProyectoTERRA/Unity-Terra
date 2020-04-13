using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServidores : MonoBehaviour
{
    [SerializeField] private GameObject list;

    [SerializeField] private GameObject Mini;
    [SerializeField] private GameObject Guard;
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;
    public Sprite door;
    private bool ActM;
    static public bool dies;
    // Start is called before the first frame update
    void Start()
    {
        ActM = false;
        dies = false;

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
            Door2.GetComponent<SpriteRenderer>().sprite = door;
        }
        if (ActM)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[0]--;
            string normal = "energy";
            if (radial.especiales[0] <= 0) list.SendMessage("remove", normal);

            ActM = false;
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Activator" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0")
        {
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


            StartCoroutine(push());
        }
        if (collision.gameObject.name == "DoorOpenPanel 1" && Input.GetKeyDown(KeyCode.E) && MinijuegoServidores.win)
        {
            Debug.Log("NEEEEEEEEEEEEEXT");

        }

    }
    public IEnumerator push2()
    {

        Door1.GetComponent<SpriteRenderer>().sprite = door;
        yield return new WaitForSeconds(.5f);
        Destroy(Mini);
        Guard.SetActive(true);

    }
  
    public IEnumerator push()
    {

        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);

    }
}
