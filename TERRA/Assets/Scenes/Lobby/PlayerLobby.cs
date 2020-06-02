using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLobby : MonoBehaviour
{//23.5
    [SerializeField] private GameObject HealthRefiill;
    [SerializeField] private GameObject Recicler;
    [SerializeField] private GameObject Equipment;

    [SerializeField] private GameObject HealthRefiill_Key;
    [SerializeField] private GameObject Recicler_Key;
    [SerializeField] private GameObject Equipment_Key;

    public static bool ActH, ActR, ActE;
    private bool TH, TR, TE;

    private bool exit;

    // Start is called before the first frame update
    void Start()
    {
        GameController.LobbyCAP = 5;
        exit = false;
        /*
        if (GameController.start)
        {
            Debug.Log("Continue");
            Heart_Bar.life = GameController.vidas;
            Heart_Bar.Phearts = GameController.corazones;
        }
        else
        {
            Debug.Log("NEW");
            GameController.corazones = 3;
            GameController.vidas = 3;
            GameController.TypeLife = 1;
            GameController.LifeMax = 3;
            GameController.HeartsMax = 6;
            Heart_Bar.life = GameController.vidas;
            Heart_Bar.Phearts = GameController.corazones;

            GameController.start = true;
        }
        */
        ActH = false;
        ActR = false;
        ActE = false;
        TH = false;
        TR = false;
        TE = false;

        GameController.LOBBY = true;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ActH);
        Debug.Log(TH);


        if (exit)
        {
            if(GameController.LobbyCAP == 2)
            {
                exit = false;
                GameController.LOBBY = false;
                SceneManager.LoadScene("edificio");
            }
            if (GameController.LobbyCAP == 3)
            {
                exit = false;
                GameController.LOBBY = false;
                SceneManager.LoadScene("Playa");
            }
            if (GameController.LobbyCAP == 5)
            {
                exit = false;
                GameController.LOBBY = false;
                SceneManager.LoadScene("Antartida 1");
            }
            exit = false;
        }

        if (TH)
        {
            ActH = !ActH;
            TH = false;
        }
        if (TR)
        {
            ActR = !ActR;
            TR = false;
        }
        if (TE)
        {
            ActE = !ActE;
            TE = false;
        }
        if (ActH)
        {
            transform.position = new Vector3(23.5f, transform.position.y);
            PlayerController.movement = false;
            //GetComponent<PlayerController>().enabled = false;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            HealthRefiill.SetActive(true);
            HealthRefiill_Key.SetActive(false);
        }else
        {
            PlayerController.movement = true;
            //GetComponent<PlayerController>().enabled = true;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            HealthRefiill.SetActive(false);
            HealthRefiill_Key.SetActive(true);
            ActH = false;
        }

        if (ActR)
        {
            transform.position = new Vector3(28.5f, transform.position.y);
            PlayerController.movement = false;
            //GetComponent<PlayerController>().enabled = false;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Recicler.SetActive(true);
            Recicler_Key.SetActive(false);
        }
        else
        {
            PlayerController.movement = true;
            //GetComponent<PlayerController>().enabled = true;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Recicler.SetActive(false);
            Recicler_Key.SetActive(true);
            ActR = false;
        }

        if (ActE)
        {
            transform.position = new Vector3(33.5f, transform.position.y);
            PlayerController.movement = false;
            //GetComponent<PlayerController>().enabled = false;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Equipment.SetActive(true);
            Equipment_Key.SetActive(false);
        }
        else
        {
            PlayerController.movement = true;
            //GetComponent<PlayerController>().enabled = true;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Equipment.SetActive(false);
            Equipment_Key.SetActive(true);
            ActE = false;
        }

        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            GameController.corazones = Heart_Bar.Phearts;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.name == "HealthRefillPlace" && Input.GetKeyDown(KeyCode.E) && !TH)
        {

            TH = true;
        }
        if (collision.name == "ReciclerPlace" && Input.GetKeyDown(KeyCode.E) && !TR)
        {

            TR = true;
        }
        if (collision.name == "EquipmentPlace" && Input.GetKeyDown(KeyCode.E) && !TE)
        {

            TE = true;
        }

        if (collision.name == "Diana 2.0" && Input.GetKeyDown(KeyCode.E) && !exit)
        {
            exit = true;
        }
    }

}
