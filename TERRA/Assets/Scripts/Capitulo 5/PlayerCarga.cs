using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCarga : MonoBehaviour
{
    [SerializeField] private GameObject LIST;

    [SerializeField] private GameObject ExitGate;

    [SerializeField] private GameObject Key_Ener1;
    [SerializeField] private GameObject Key_Ener2;
    [SerializeField] private GameObject Key_Ener3;
    [SerializeField] private GameObject Key_Pl1;
    [SerializeField] private GameObject Key_Pl2;
    [SerializeField] private GameObject Key_Pl3;
    [SerializeField] private GameObject Key_Pack;

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

    [SerializeField] private GameObject NoX;
    [SerializeField] private GameObject BYE;

    [SerializeField] private GameObject Pack;

    private float X_support;
    public Sprite LED_ON, LED_ACT, Palanca_ACT;

    public static int countPL;

    private bool Ener_1, Ener_2, Ener_3, dEnergy, PL1_Ready, PL2_Ready, PL3_Ready, Pulling_1, Pulling_2, Pulling_3, EXIT, healing, cSide, Front, cAct1, cAct2, cAct3;
    // Start is called before the first frame update
    void Start()
    {
        Key_Ener1.SetActive(false);
        Key_Ener2.SetActive(false);
        Key_Ener3.SetActive(false);
        Key_Pl1.SetActive(false);
        Key_Pl2.SetActive(false);
        Key_Pl3.SetActive(false);

        Heart_Bar.Phearts = 6;

        countPL = 0;
        cAct1= false;
        cAct2 = false;
        cAct3 = false;
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

        cSide = false;
        Front = true;

        healing = false;
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
        if (cSide)
        {
            cSide = false;
            //StartCoroutine(push());
            
        }
        if (healing)
        {
            if (X_support <= 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * 700f);

            }
            else if (X_support > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * -700f);
            }
        }
        if (dEnergy)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[0]--;
            string normal = "energy";
            if (radial.especiales[0] <= 0) LIST.SendMessage("remove", normal);
            dEnergy = false;
        }
        if(Slide_1.value >= 50 && !cAct1)
        {
            Key_Pl1.SetActive(false);
            countPL++;
            PL1_Ready = true;
            SlideV_1.SetActive(false);
            PlayerController.groundCAP5 = true;
            cAct1 = true;
        }
        if (Slide_2.value >= 50 && !cAct2)
        {
            Key_Pl2.SetActive(false);
            countPL++;
            PL2_Ready = true;
            SlideV_2.SetActive(false);
            PlayerController.groundCAP5 = true;
            cAct2 = true;
        }
        if (Slide_3.value >= 50 && !cAct3)
        {
            Key_Pl3.SetActive(false);
            countPL++;
            PL3_Ready = true;
            SlideV_3.SetActive(false);
            PlayerController.groundCAP5 = true;
            cAct3 = true;
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
        if (collision.gameObject.name == "BACK" && !cSide && Front)//compara si hizo la colision con el objeto correcto
        {
            Front = false;
            cSide = true;
            Debug.Log("SSSSSS");
            NOX.side = NOX.side * -1;

        }
        if (collision.gameObject.name == "FRONT" )//compara si hizo la colision con el objeto correcto
        {
            Front = true;

        }
        if (collision.gameObject.name == "Energy_1" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_1)//compara si hizo la colision con el objeto correcto
        {
            Key_Ener1.SetActive(false);
            Key_Pl3.SetActive(true);
            dEnergy = true;
            Energy_1.GetComponent<SpriteRenderer>().color = Color.white;
            Led_3.GetComponent<SpriteRenderer>().sprite = LED_ON;
            Ener_1 = true;
        }

        if (collision.gameObject.name == "Energy_2" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_2)//compara si hizo la colision con el objeto correcto
        {
            Key_Ener2.SetActive(false);
            Key_Pl2.SetActive(true);
            dEnergy = true;
            Energy_2.GetComponent<SpriteRenderer>().color = Color.white;
            Led_2.GetComponent<SpriteRenderer>().sprite = LED_ON;
            Ener_2 = true;
        }
        if (collision.gameObject.name == "Energy_3" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_3)//compara si hizo la colision con el objeto correcto
        {
            Key_Ener3.SetActive(false);
            Key_Pl1.SetActive(true);
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

            Key_Ener1.SetActive(true);
            Key_Ener2.SetActive(true);
            Key_Ener3.SetActive(true);

            Key_Pack.SetActive(false);

            NoX.SetActive(true);

            Pack.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "PUNCH" && !healing)
        {
            EnemyKnockBack(transform.position.x);
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
    public void OnTriggerEnter2D(Collider2D collision)
    {

       
    }

    public IEnumerator BYEBYE()
    {
        yield return new WaitForSeconds(1f);
        NoX.GetComponent<NOX>().enabled = false;
        NoX.GetComponent<CircleCollider2D>().enabled = true;
        NoX.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        NoX.GetComponent<Rigidbody2D>().mass = 20;
        EXIT = true;
        BYE.SetActive(true);
        ExitGate.SetActive(false);
        yield return new WaitForSeconds(3f);
        BYE.SetActive(false);
        ExitGate.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Caída");


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

    public void EnemyKnockBack(float enemyPosX)
    {
        X_support = transform.position.x;
        healing = true;
        PlayerController.jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
       

        PlayerController.movement = false;


        Invoke("EnableMovement", 0.7f);



        GetComponent<SpriteRenderer>().color = Color.red;
    }
    public IEnumerator push()
    {

        yield return new WaitForSeconds(.5f);
        if (NOX.side == -1)
        {
            NOX.side = 1;
        }
        else if(NOX.side == 1)
        {
            NOX.side = -1;
        }



    }
    void EnableMovement()
    {

        healing = false;
        PlayerController.movement = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
