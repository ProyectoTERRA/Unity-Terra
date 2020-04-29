using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobby : MonoBehaviour
{
    [SerializeField] private GameObject HealthRefiill;
    [SerializeField] private GameObject Recicler;
    [SerializeField] private GameObject Equipment;

    [SerializeField] private GameObject HealthRefiill_Key;
    [SerializeField] private GameObject Recicler_Key;
    [SerializeField] private GameObject Equipment_Key;

    private bool ActH, ActR, ActE, TH, TR, TE;

    // Start is called before the first frame update
    void Start()
    {
        ActH = false;
        ActR = false;
        ActE = false;
        TH = false;
        TR = false;
        TE = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ActH);
        if (TH)
        {
            ActH = true;
            TH = false;
        }
        if(ActH && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<PlayerController>().enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            HealthRefiill.SetActive(false);
            HealthRefiill_Key.SetActive(true);
            ActH = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.name == "HealthRefillPlace" && Input.GetKeyDown(KeyCode.E) && !TH)
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            HealthRefiill.SetActive(true);
            HealthRefiill_Key.SetActive(false);
            TH = true;
        }
    }
}
