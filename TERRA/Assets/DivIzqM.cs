using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DivIzqM : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Barra;
    public GameObject Slide, TextoInstruccion, IndLvl, Finalizado;
    int ContadorLv1, ContadorLv2, ContadorLv3, ContFin, IndexLvl = 0;
    float RedSeg1 = 2.0f, RedSeg2, RedSeg3, Contador, currValue, finalW, Delay;
    public float countdownTime = 50;
    public bool Lvl1, Lvl2, Lvl3, Completo, Resta;
    public TextMeshProUGUI Instruccion, Nivel;
    public Text TxtLvl;
    void Start()
    {
        Instruccion = GetComponent<TextMeshProUGUI>();
        Nivel = GetComponent<TextMeshProUGUI>();
    }

    //Barra.value = "Variable";
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IndexLvl == 0)
        {
            Slide.SetActive(true);
            //Barra.value = 50;
            IndexLvl = 1;
            currValue = 0;
            Completo = false;
            
        }
        if (IndexLvl != 3 && Completo == false)
            TextoInstruccion.SetActive(true);
        if(IndexLvl == 3 && Completo == true)
        {
            Finalizado.SetActive(true);
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
 

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IndexLvl == 1)
        {         
            NivelUno();
        }

        if (collision.gameObject.tag == "Player" && IndexLvl == 2)
        {
            NivelDos();
        }

        if (collision.gameObject.tag == "Player" && IndexLvl == 3)
        {
            NivelTres();
        }
        if (IndexLvl == 3 && Completo == true)
        {
            Finalizado.SetActive(true);
        }
    }

    //Deshabilitar el minijuego por cada nivel 
    

   public void NivelUno()
    {
        //while (Completo == false)
        //{
        //StartCoroutine(RedLvl1());
        if (Input.GetKeyDown(KeyCode.E) && Barra.value <= 99 && IndexLvl == 1)
        {
            ContFin++;
            Debug.Log("Clicks: " + ContFin);
            Contador = Contador + 3.33f;
            Barra.value = Contador;
        }
        else if (Barra.value > 99)
        {
            Completo = true;
            Debug.Log("Condicion: " + Completo);
            IndexLvl = 2;
            Debug.Log("Nivel: " + IndexLvl);
            Barra.value = 0;
            ContFin = 0;
            Contador = 0;
            currValue = 0;
        }

        //}
    }
        public void NivelDos()
        {
             //StartCoroutine(RedLvl2());
        if (Input.GetKeyDown(KeyCode.E) && Contador <= 100 && IndexLvl == 2)
        {
            Barra.value = 0;
            ContFin++;
            Contador = Contador + 2.5f;
            Barra.value = Contador;

            if (Contador >= 100)
            {
                Completo = true;
                Debug.Log("Condicion: " + Completo);
                Contador = 0;
                IndexLvl = 3;
                Debug.Log("Nivel: " + IndexLvl);
                Barra.value = 0;
                ContFin = 0;
                Completo = false;
                
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
                Barra.value = 0;
                ContFin = 0;
                Slide.SetActive(false);
                TextoInstruccion.SetActive(false);
                TxtLvl = GetComponent<Text>();
                //TxtLvl.text = "Completado!";
            }
        }

    }

    IEnumerator RedLvl1()
    {
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



