using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DivIzqM : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Barra;
    public GameObject Slide;
    int ContadorLv1, ContadorLv2, ContadorLv3, ContFin, IndexLvl = 0;
    float RedSeg1 = 2.0f, RedSeg2, RedSeg3, Contador, currValue, finalW;
    public float countdownTime = 50;
    public bool Lvl1, Lvl2, Lvl3, Completo;
    void Start()
    {

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
    }

    /*void FixedUpdate()
    {

         if (IndexLvl == 1)
         {
             NivelUno();
             //StartCoroutine(RedLvl1());

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
    */
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
    }

    

    //Utilizar las variables booleanas como Banderas, para checar cual nivel está activo y si está completado, algo como if(Lvl1 == true && Completado) se aumenta
    //el valor del IndexLvl y se elige el nivel 2, recordar que el valor del Slider es de 100, por lo que se tendrá que dividir entre los diferentes niveles
    //nivel uno 30 clicks, por lo que el valor de cada contador del botón sera de 1 + 2, algo como cont = cont + 2
    //Y así sucesivamente
    //Deshabilitar el minijuego por cada nivel 
    

   public void NivelUno()
    {
        //while (Completo == false)
        //{

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

        }
        //}
    }
        public void NivelDos()
        {

        if (Input.GetKeyDown(KeyCode.E) && Contador <= 100 && IndexLvl == 2)
        {
            Barra.value = 0;
            ContFin++;
            Debug.Log(ContFin);
            Contador = Contador + 2.5f;
            Barra.value = Contador;
            Debug.Log("Cuenta : " + Contador);
            StartCoroutine(RedLvl1());

            if (Contador >= 100)
            {
                Completo = true;
                Debug.Log("Condicion: " + Completo);
                Contador = 0;
                IndexLvl = 3;
                Debug.Log("Nivel: " + IndexLvl);
                Barra.value = 0;
                ContFin = 0;
            }
            //RedLvl1();
        }

       }


    public void NivelTres()
    {
        if (Input.GetKeyDown(KeyCode.E) && Contador <= 100 && IndexLvl == 3)
        {
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
            }

            //RedLvl1();
        }

    }



    IEnumerator RedLvl1()
    {
        while (countdownTime >= 0){
            Contador = Contador - 2;
            yield return new WaitForSeconds(2.0f);
            Debug.Log("Valor Contador: " + Contador);
            Barra.value = Contador;
            Debug.Log("Cuenta atras: " + countdownTime);
        }
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
    

    void RedLvl2()
    {
        while (Completo == false && IndexLvl == 2)
        {
            RedSeg1 = 4.0f;
            RedSeg1 -= Time.deltaTime;
            if (RedSeg1 <= 0)
            {
                Contador = Contador - 5;
            }
        }
    }
}


