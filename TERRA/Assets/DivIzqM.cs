using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DivIzqM : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Barra;
    public GameObject Slide, slide2, TextoInstruccion, IndLvl, Finalizado;
    int ContadorLv1, ContadorLv2, ContadorLv3, ContFin, IndexLvl = 0;
    float RedSeg1 = 2.0f, RedSeg2, RedSeg3, Contador, currValue, finalW, Delay;
    public float countdownTime = 50;
    public bool Lvl1, Lvl2, Lvl3, Completo, Resta, Trigger, TriggerACT, TriggerREACT, Final;
    public TextMeshProUGUI Instruccion, Nivel;
    public Text TxtLvl;
    public static bool active, activeMain, WIN, bridge;

    public static float segs2 = 0.03f, segs4 = 0.069f, segs3 = 0.052f;

    [SerializeField] private GameObject L1;
    [SerializeField] private GameObject L2;
    [SerializeField] private GameObject L3;
    [SerializeField] private GameObject MINIBACK;
    [SerializeField] private Text txtCount;

    public Sprite stay, pass, fail;

    private BSliderPuto3 sl;

    void Start()
    {
        Slide.transform.localPosition = new Vector3(76f, 125);
        BSliderPuto3.speed = segs2;
        sl = GetComponent<BSliderPuto3>();
        Instruccion = GetComponent<TextMeshProUGUI>();
        Nivel = GetComponent<TextMeshProUGUI>();
    }

    //Barra.value = "Variable";
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (IndexLvl != 3 && Completo == false)
            TextoInstruccion.SetActive(true);
        if(IndexLvl == 3 && Completo == true)
        {
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextoInstruccion.SetActive(false);
        IndLvl.SetActive(false);

        if(IndexLvl == 3 && Completo == true)
        {
            Slide.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Delay = 5f;
        Delay = Delay - Time.deltaTime;
        if(Delay <= 0 && IndexLvl == 1)
        {
            Debug.Log("IniciaCorutina");            
            StartCoroutine(RedLvl1());
        }
        /*
         if (IndexLvl == 2)
         {
            StopAllCoroutines(); 
            NivelDos();

         }

         if (IndexLvl == 3)
         {
            StopAllCoroutines(); 
            NivelTres();


         }

       */

    }

    private void Update()
    {
        Debug.Log("PUTO: " + Contador);
        Debug.Log("PUTO: " + ContFin);

        if (Input.GetKeyDown(KeyCode.E) && Trigger && !bridge)
        {
            
            if (IndexLvl == 1 && active) NivelUno();
            if (IndexLvl == 2 && active) NivelDos();
            if (IndexLvl == 3 && active) NivelTres();
            txtCount.text = "" + ContFin;
            Trigger = false;
        }

        if (IndexLvl == 3 && Completo == true && active)
        {
            Slide.SetActive(false);
            TextoInstruccion.SetActive(false);
            Finalizado.SetActive(true);
            Final = true;
        }
        if (TriggerACT)
        {
            BSliderPuto3.start = true;
            MINIBACK.SetActive(true);
            Slide.SetActive(true);
            slide2.SetActive(true);

            //Barra.value = 50;
            IndexLvl = 1;
            currValue = 0;
            Completo = false;
            TriggerACT = false;
            activeMain = true;
        }

        if (TriggerREACT)
        {
            if (IndexLvl == 3)
            {
                ContFin = 0;
                Contador = 0;
                currValue = 0;
                bridge = false;
                BSliderPuto3.speed = segs3;
            }
            sl.Refill();
            Barra.value = 0;
            active = true;
            MINIBACK.SetActive(true);
            Slide.transform.localPosition = new Vector3(76f, 125);
            Slide.SetActive(true);
            slide2.SetActive(true);
            TriggerREACT = false;
            activeMain = true;
            

           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player" && IndexLvl == 0 && !TriggerACT && !activeMain)
        {
            TriggerACT = true;

        }
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player" && !TriggerREACT && !activeMain)
        {
            TriggerREACT = true;

        }
        if (collision.gameObject.tag == "Player" && IndexLvl == 1 && !Trigger)
        {
            Trigger = true;
            
        }

        if (collision.gameObject.tag == "Player" && IndexLvl == 2 && !Trigger)
        {
            Trigger = true;
        }

        if (collision.gameObject.tag == "Player" && IndexLvl == 3 && !Trigger)
        {
            Trigger = true;
        }
        
    }

    //Deshabilitar el minijuego por cada nivel 


    public void MINUS()
    {
        if (IndexLvl == 1)
        {

            if (ContFin >= 2 && Contador >= (2 * 3.33f))
            {
                ContFin -= 2;
                Contador = Contador - (2 * 3.33f);
                Barra.value = Contador;
            }
            else if(ContFin >= 0 && ContFin <=2 && Contador >= 0 && Contador < (2 * 3.33f))
            {
                ContFin = 0;
                Contador = 0;
                Barra.value = Contador;
            }
            txtCount.text = "" + ContFin;
        }
        else if(IndexLvl == 2)
        {
            if (ContFin >= 5 && Contador >= (5 * 2.5f))
            {
                ContFin -= 5;
                Contador = Contador- (5 * 2.5f);
                Barra.value = Contador;
               
            }
            else if (ContFin >= 0 && ContFin < 5 && Contador >= 0 && Contador < (5 * 2.5f))
            {
                ContFin = 0;
                Contador = 0;
                Barra.value = Contador;
            }
            txtCount.text = "" + ContFin;
        }
        else if (IndexLvl == 3)
        {
            if (ContFin >= 6 && Contador >= (6 * 2f))
            {
                ContFin -= 6;
                Contador = Contador - (6 * 2f);
                Barra.value = Contador;
                if (Barra.value <= 40 && bridge)
                {
                    StartCoroutine(LOSE());
                }
            }
            else if (ContFin >= 0 && ContFin < 6 && Contador >= 0 && Contador < (6 * 2f))
            {
                ContFin = 0;
                Contador = 0;
                Barra.value = Contador;
            }
            txtCount.text = "" + ContFin;
        }
        if (ContFin <= 0 || Contador <= 0)
        {
            active = false;
            txtCount.text = "" + ContFin;
            StartCoroutine(Fail());
        }
        else
        {
            txtCount.text = "" + ContFin;
            sl.Refill();
        }
        
    }

    public void NivelUno()
    {
        //while (Completo == false)
        //{
        //StartCoroutine(RedLvl1());

        if (Barra.value >= 96 && IndexLvl == 1)
        {
            Completo = true;
            Debug.Log("Condicion: " + Completo);
            IndexLvl = 2;
            Debug.Log("Nivel: " + IndexLvl);
            Barra.value = 100;
            ContFin = 30;
            active = false;
            StartCoroutine(Tran());
            L1.GetComponent<SpriteRenderer>().sprite = pass;
            BSliderPuto3.speed = segs4;
        }
        else if (Barra.value < 96 && IndexLvl == 1)
        {
            ContFin++;
            Debug.Log("Clicks: " + ContFin);
            Contador = Contador + 3.33f;
            Barra.value = Contador;

        }

        //}
    }
    public void NivelDos()
    {
        //StartCoroutine(RedLvl2());
        
        if (Contador < 100 && IndexLvl == 2)
        {
            Barra.value = 0;
            ContFin++;
            Contador = Contador + 2.5f;
            Debug.Log("Clicks: " + ContFin);
            Barra.value = Contador;
            if (Contador >= 100)
            {
                bridge = true;
                Completo = true;
                Debug.Log("Condicion: " + Completo);
                Contador = 0;
                IndexLvl = 3;
                Debug.Log("Nivel: " + IndexLvl);
                Barra.value = 100;
                ContFin = 40;
                Completo = false;
                L2.GetComponent<SpriteRenderer>().sprite = pass;

                StartCoroutine(Tran());

            }


        }

    }


    public void NivelTres()
    {
        if (Input.GetKeyDown(KeyCode.E) && Contador <= 100 && IndexLvl == 3)
        {
            Completo = false;
            ContFin++;
            Debug.Log(ContFin);
            Contador = Contador + 2f;
            Barra.value = Contador;
            Debug.Log("Cuenta: " + Contador);

            if (Contador >= 100)
            {
                Completo = true;
                Debug.Log("Condicion: " + Completo);
                Debug.Log("Nivel: " + IndexLvl);
                Barra.value = 100;
                ContFin = 50;
                L3.GetComponent<SpriteRenderer>().sprite = pass;
                TxtLvl = GetComponent<Text>();
                active = false;
                WIN = true;
                StartCoroutine(Tran());

                //TxtLvl.text = "Completado!";
            }
        }

    }



    IEnumerator Tran()
    {
        active = false;
        if (!WIN)
        {

           
            GetComponent<SpriteRenderer>().color = Color.gray;
            BSliderPuto3.active = false;
            yield return new WaitForSeconds(1f);
            Slide.transform.localPosition = new Vector3(76f, 329);
            MINIBACK.SetActive(false);
            if (IndexLvl == 2)
            {

                slide2.SetActive(false);
            }
            else if(IndexLvl == 3)
            {
                BSliderPuto3.active = true;
                bridge = true;
                sl.Refill();
                ContFin = 40;
                Contador = 100;
                Barra.value = 100;
                active = true;
                Slide.SetActive(true);
                slide2.SetActive(true);
                activeMain = true;
            }

        }
        else
        {
            BSliderPuto3.active = false;
            Finalizado.SetActive(true);
            yield return new WaitForSeconds(2f);
            Finalizado.SetActive(false);
            Slide.SetActive(false);
            MINIBACK.SetActive(false);
            slide2.SetActive(false);
        }

        
        if (!WIN)
        {
            yield return new WaitForSeconds(10f);
            GetComponent<SpriteRenderer>().color = Color.white;

            if(IndexLvl != 3)
            {
                ContFin = 0;
                Contador = 0;
                currValue = 0;
            }
            
            activeMain = false;
        }
       
    }
    IEnumerator LOSE()
    {
        Slide.SetActive(false);
        slide2.SetActive(false);
        active = false;
        GetComponent<SpriteRenderer>().color = Color.gray;
        BSliderPuto3.active = false;
        yield return new WaitForSeconds(1f);
        MINIBACK.SetActive(false);
        
    }
    IEnumerator Fail()
    {
        active = false;
        if (!WIN)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            BSliderPuto3.active = false;
            yield return new WaitForSeconds(1f);
            MINIBACK.SetActive(false);

        }
        else
        {
            BSliderPuto3.active = false;
            Finalizado.SetActive(true);
            yield return new WaitForSeconds(1f);
            Finalizado.SetActive(false);
            Slide.SetActive(false);
            MINIBACK.SetActive(false);
        }


        if (!WIN)
        {
            yield return new WaitForSeconds(5f);
            GetComponent<SpriteRenderer>().color = Color.white;

            activeMain = false;
        }

    }

    IEnumerator RedLvl1()
    {
        /*
        Debug.Log("Inicia Corutina");
        if(Delay <= 0)
        {
            Resta = true;
        }
        else
        {
            Resta = false;
            Debug.Log("Falso");
        }
        if (Resta == true && Barra.value > 0)
        {
            Contador -= 2;
            Barra.value = Contador;
        }
        */
        //Debug.Log("Resta - 2");
        yield return new WaitForSeconds(15f);
    }
 
        
        /*
        if (Completo == false && IndexLvl == 1)
        {
            RedSeg1 = 2.0f;
            RedSeg1 -= Time.deltaTime;
            currValue = RedSeg1;
            Debug.Log("Contador de Tiempo: " + currValue);
            if (currValue <= 0)
            {
                Contador = Contador - 2;
            }
        }
        */
    

   /* IEnumerator RedLvl2()
    {
        if (Completo == false && IndexLvl == 2 && Barra.value > 0)
        {
            RedSeg1 = 4.0f;
            RedSeg1 -= Time.deltaTime;
            if (RedSeg1 <= 0)
            {
                Debug.Log("REDLVL2");
                Contador = Contador - 5;
                Barra.value = Contador;
            }
        }
        yield return Barra.value;
    }
    */
}



