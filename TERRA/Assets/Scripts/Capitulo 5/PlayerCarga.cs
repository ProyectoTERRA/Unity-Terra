using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarga : MonoBehaviour
{
    [SerializeField] private GameObject LIST;

    [SerializeField] private GameObject ExitGate;

    [SerializeField] private GameObject Palanca_1;
    [SerializeField] private GameObject Palanca_2;
    [SerializeField] private GameObject Palanca_3;

    [SerializeField] private GameObject FPalanca_1;
    [SerializeField] private GameObject FPalanca_2;
    [SerializeField] private GameObject FPalanca_3;

    [SerializeField] private GameObject SlideV_1;
    [SerializeField] private GameObject SlideV_2;
    [SerializeField] private GameObject SlideV_3;
    [SerializeField] private Slider Slide_1;
    [SerializeField] private Slider Slide_2;
    [SerializeField] private Slider Slide_3;

    [SerializeField] private GameObject Led_1;
    [SerializeField] private GameObject Led_2;
    [SerializeField] private GameObject Led_3;

    [SerializeField] private GameObject Energy_1;
    [SerializeField] private GameObject Energy_2;
    [SerializeField] private GameObject Energy_3;

    [SerializeField] private GameObject NOX;
    [SerializeField] private GameObject BYE;

    [SerializeField] private GameObject Pack;

    public Sprite LED_ON, LED_ACT, Palanca_ACT;

    private bool Ener_1, Ener_2, Ener_3, dEnergy, PL1_Ready, PL2_Ready, PL3_Ready, Pulling_1, Pulling_2, Pulling_3, EXIT;
    // Start is called before the first frame update
    void Start()
    {
        BYE.SetActive(false);
        ExitGate.SetActive(true);
        FPalanca_1.tag = "Ground";
        FPalanca_2.tag = "Ground";
        FPalanca_3.tag = "Ground";
        Slide_1.value = 0;
        Slide_2.value = 0;
        Slide_3.value = 0;

        SlideV_1.SetActive(false);
        SlideV_2.SetActive(false);
        SlideV_3.SetActive(false);

        Energy_1.SetActive(false);
        Energy_2.SetActive(false);
        Energy_3.SetActive(false);


        EXIT = false;
        Pulling_1 = false;
        Pulling_2 = false;
        Pulling_3 = false;
        PL3_Ready = false;
        PL3_Ready = false;
        PL3_Ready = false;
        Ener_1 = false;
        Ener_2 = false;
        Ener_3 = false;
        dEnergy = false;
        StartCoroutine(PL1());
        StartCoroutine(PL2());
        StartCoroutine(PL3());
    }

    // Update is called once per frame
    void Update()
    {
        if (dEnergy)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[0]--;
            string normal = "energy";
            if (radial.especiales[0] <= 0) LIST.SendMessage("remove", normal);
            dEnergy = false;
        }
        if(Slide_1.value >= 50)
        {
            PL1_Ready = true;
            SlideV_1.SetActive(false);
            PlayerController.groundCAP5 = true;
        }
        if (Slide_2.value >= 50)
        {
            PL2_Ready = true;
            SlideV_2.SetActive(false);
            PlayerController.groundCAP5 = true;
        }
        if (Slide_3.value >= 50)
        {
            PL3_Ready = true;
            SlideV_3.SetActive(false);
            PlayerController.groundCAP5 = true;
        }
        if (PL2_Ready)
        {
            Led_2.GetComponent<SpriteRenderer>().sprite = LED_ACT;
            Palanca_2.GetComponent<SpriteRenderer>().sprite = Palanca_ACT;
        }
        if (PL1_Ready)
        {
            Led_1.GetComponent<SpriteRenderer>().sprite = LED_ACT;
            Palanca_1.GetComponent<SpriteRenderer>().sprite = Palanca_ACT;
        }
        if (PL3_Ready)
        {
            Led_3.GetComponent<SpriteRenderer>().sprite = LED_ACT;
            Palanca_3.GetComponent<SpriteRenderer>().sprite = Palanca_ACT;
        }
        if (PL1_Ready && PL2_Ready && PL3_Ready)
        {
            
            StartCoroutine(BYEBYE());
            PL3_Ready = false;
            PL3_Ready = false;
            PL3_Ready = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Energy_1" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_1)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_1.GetComponent<SpriteRenderer>().color = Color.white;
            Led_3.GetComponent<SpriteRenderer>().sprite = LED_ON;
            Ener_1 = true;
        }

        if (collision.gameObject.name == "Energy_2" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_2)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_2.GetComponent<SpriteRenderer>().color = Color.white;
            Led_2.GetComponent<SpriteRenderer>().sprite = LED_ON;
            Ener_2 = true;
        }
        if (collision.gameObject.name == "Energy_3" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_3)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_3.GetComponent<SpriteRenderer>().color = Color.white;
            Led_1.GetComponent<SpriteRenderer>().sprite = LED_ON;
            Ener_3 = true;
        }
        if (collision.gameObject.name == "Palanca 3" && Ener_1 && !PL3_Ready)//compara si hizo la colision con el objeto correcto
        {
            PlayerController.groundCAP5 = false;
            if (Input.GetKey(KeyCode.Space))
            {

                SlideV_3.SetActive(true);

                Pulling_3 = true;
            }
            else if (!Input.GetKey(KeyCode.Space))
            {

                Pulling_3 = false;
                SlideV_3.SetActive(false);
                Slide_3.value = 0;
            }
        }
        if (collision.gameObject.name == "Palanca 2" && Ener_2 && !PL2_Ready)//compara si hizo la colision con el objeto correcto
        {
            PlayerController.groundCAP5 = false;
            if (Input.GetKey(KeyCode.Space))
            {

                SlideV_2.SetActive(true);

                Pulling_2 = true;
            }
            else if (!Input.GetKey(KeyCode.Space))
            {

                Pulling_2 = false;
                SlideV_2.SetActive(false);
                Slide_2.value = 0;
            }
        }
        if (collision.gameObject.name == "Palanca 1" && Ener_3 && !PL1_Ready)//compara si hizo la colision con el objeto correcto
        {
            PlayerController.groundCAP5 = false;
            if (Input.GetKey(KeyCode.Space))
            {
                
                SlideV_1.SetActive(true);

                Pulling_1 = true;
            }
            else if(!Input.GetKey(KeyCode.Space))
            {
                
                Pulling_1 = false;
                SlideV_1.SetActive(false);
                Slide_1.value = 0;
            }

        }
        

        if (collision.gameObject.name == "Pack" && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            Energy_1.SetActive(true);
            Energy_2.SetActive(true);
            Energy_3.SetActive(true);

            //NOX.SetActive(true);

            Pack.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Palanca 1" && Ener_3 && !PL1_Ready)//compara si hizo la colision con el objeto correcto
        {
            PlayerController.groundCAP5 = true;
            Pulling_1 = false;
            SlideV_1.SetActive(false);
            Slide_1.value = 0;



        }
        if (collision.gameObject.name == "Palanca 2" && Ener_2 && !PL2_Ready)//compara si hizo la colision con el objeto correcto
        {
            PlayerController.groundCAP5 = true;
            Pulling_2 = false;
            SlideV_2.SetActive(false);
            Slide_2.value = 0;



        }
        if (collision.gameObject.name == "Palanca 3" && Ener_1 && !PL3_Ready)//compara si hizo la colision con el objeto correcto
        {
            PlayerController.groundCAP5 = true;
            Pulling_3 = false;
            SlideV_3.SetActive(false);
            Slide_3.value = 0;



        }
    }

    public IEnumerator BYEBYE()
    {
        yield return new WaitForSeconds(1f);
        EXIT = true;
        BYE.SetActive(true);
        ExitGate.SetActive(false);
        yield return new WaitForSeconds(3f);
        BYE.SetActive(false);
        ExitGate.SetActive(true);

    }
    public IEnumerator PL1()
    {
        yield return new WaitForSeconds(.02f);
        if (Pulling_1)
        {
            
            Slide_1.value = Slide_1.value + 1;
        }
        if (!EXIT)
        {
            StartCoroutine(PL1());
        }
    }
    public IEnumerator PL2()
    {
        yield return new WaitForSeconds(.02f);
        if (Pulling_2)
        {

            Slide_2.value = Slide_2.value + 1;
        }
        if (!EXIT)
        {
            StartCoroutine(PL2());
        }

    }
    public IEnumerator PL3()
    {
        yield return new WaitForSeconds(.02f);
        if (Pulling_3)
        {

            Slide_3.value = Slide_3.value + 1;
        }
        if (!EXIT)
        {
            StartCoroutine(PL3());
        }

    }
}
