using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCap6 : MonoBehaviour
{
    public GameObject Compu, Puerta, ChangeScene, puertaOpen,Clock;
    public bool Active, DI, DD;
    public DivIzqM DivI;
    public MiniPuto1 DivC;
    public MiniPuto2 DivD;
   

    [SerializeField] private GameObject Esf2;
    [SerializeField] private GameObject Esf3;
    [SerializeField] private GameObject Esf4s;
    [SerializeField] private GameObject Launch;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DI = DivI.Final;
        DD = DivD.Finalizado;
        if(DI == true && DD == true)
        {
            Clock.SetActive(false);
        }
        if (DivI.Final == true && DivD.Finalizado == true && Active == true && Input.GetKeyDown(KeyCode.E))
        {
            Compu.SetActive(true);
        }

        if (DivI.Completo == true)
        {
            DivI.Completo = false;
            StopAllCoroutines();
            StartCoroutine(LaunchESF());  
        }

        if (DivC.PorLMAO)
        {
            Puerta.SetActive(false);
            puertaOpen.SetActive(true);
            ChangeScene.SetActive(true);
        }
    }
    IEnumerator LaunchESF()
    {
        Debug.Log("LanzandoBasuras");
        Instantiate(Esf2, new Vector3(214,14f,0), Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Esf3, new Vector3(214.5f, 14f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Esf4s, new Vector3(215, 14f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                Active = true;
            }
        }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Active = false;
    }

}
