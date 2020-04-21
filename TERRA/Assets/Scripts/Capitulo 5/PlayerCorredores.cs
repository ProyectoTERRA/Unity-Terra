using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCorredores : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject LIST;

    [SerializeField] private GameObject Inter_Guard;
    [SerializeField] private GameObject Fake_APL;
    [SerializeField] private GameObject Legit_APL;

    [SerializeField] private GameObject Key_EnergyALMA;
    [SerializeField] private GameObject Key_EnergyFinal;
    [SerializeField] private GameObject Key_EnergyC1;
    [SerializeField] private GameObject Key_EnergyC2;
    [SerializeField] private GameObject Key_YellowCardOBJ;
    [SerializeField] private GameObject Key_GreenCardOBJ;
    [SerializeField] private GameObject Key_YellowCardACT;
    [SerializeField] private GameObject Key_GreenCardACT;
    [SerializeField] private GameObject Key_APL;
    [SerializeField] private GameObject Key_Door1;
    [SerializeField] private GameObject Key_Door2;
    [SerializeField] private GameObject Key_Capsule;

    [SerializeField] private GameObject YellowCard_ACT;
    [SerializeField] private GameObject GreenCard_ACT;
    [SerializeField] private GameObject YellowCard_OBJ;
    [SerializeField] private GameObject GreenCard_OBJ;
    [SerializeField] private GameObject YellowCard_INV;
    [SerializeField] private GameObject GreenCard_INV;

    [SerializeField] private GameObject CAPSULE;

    [SerializeField] private GameObject Energy_ALMA;
    [SerializeField] private GameObject Energy_FINAL;
    [SerializeField] private GameObject Energy_C1;
    [SerializeField] private GameObject Energy_C2;

    [SerializeField] private GameObject Door_FINAL;
    [SerializeField] private GameObject Door_ALMA;

    public Sprite Inter_ON, Door_ON, Door_Access, Capsule_OPEN, Door_OPEN;

    static public bool s1, s2, s3, turret;
    static public bool YellowPass, GreenPass, Ener_Al, Ener_Fi, Ener_C1, Ener_C2, Act_Guard, FINAL, ALMA, YT, GT, dYT, dGT, dEnergy, PassRoom, PassCorr, Capsule;
    // Start is called before the first frame update
    void Start()
    {
        Key_EnergyALMA.SetActive(true);

        Key_YellowCardOBJ.SetActive(false);
        Key_Capsule.SetActive(false);
        Key_Door1.SetActive(false);
        Key_Door2.SetActive(false);

        Heart_Bar.Phearts = 6;
        turret = false;
        s1 = true;
        s2 = false;
        s3 = false;

        YellowPass = false;
        GreenPass = false;
        Ener_Al = false;
        Ener_Fi = false;
        Ener_C1 = false;
        Ener_C2 = false;
        Act_Guard = false;
        ALMA = false;
        FINAL = false;
        PassRoom = false;
        PassCorr = false;

        Capsule = false;

        YT = false;
        GT = false;
        dYT = false;
        dGT = false;
        dEnergy = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Act_Guard)
        {
            Key_APL.SetActive(false);
            Destroy(Fake_APL);
            Legit_APL.SetActive(true);
            Act_Guard = false;
        }
        if (YT)
        {
            Key_YellowCardOBJ.SetActive(false);
            List.select.Add(YellowCard_INV);
            Destroy(YellowCard_OBJ);
            YT = false;
        }
        if (GT)
        {
            Key_GreenCardOBJ.SetActive(false);
            List.select.Add(GreenCard_INV);
            Destroy(GreenCard_OBJ);
            GT = false;
        }
        if (dYT)
        {
            Key_YellowCardACT.SetActive(false);
            YellowCard_ACT.GetComponent<SpriteRenderer>().color = Color.white; 
            List.select.Remove(YellowCard_INV);
            List.index = 0;
            dYT = false;

        }
        if (dGT)
        {
            Key_GreenCardACT.SetActive(false);
            GreenCard_ACT.GetComponent<SpriteRenderer>().color = Color.white;
            List.select.Remove(GreenCard_INV);
            List.index = 0;
            dGT = false;
            Key_Door1.SetActive(true);
        }
        if (dEnergy)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[0]--;
            GameController.energia--;
            string normal = "energy";
            if (radial.especiales[0] <= 0) LIST.SendMessage("remove", normal);

            

            dEnergy = false;
        }

        if(GreenPass && Ener_Fi)
        {
            Key_Door2.SetActive(true);
            Door_FINAL.GetComponent<SpriteRenderer>().sprite = Door_Access;
            FINAL = true;
            GreenPass = false;
            Ener_Fi = false;
        }

        if (YellowPass && Ener_Al)
        {
            Key_Door1.SetActive(true);
            Door_ALMA.GetComponent<SpriteRenderer>().sprite = Door_Access;
            ALMA = true;
            YellowPass = false;
            Ener_Al = false;
        }

        if (PassRoom)
        {
            camera.transform.position = new Vector3(78.0f, -1.0f, -10.0f);
            transform.position = new Vector3(70.7f, -2.4f, 0.0f);
            Door_ALMA.GetComponent<SpriteRenderer>().sprite = Door_OPEN;
            PassRoom = false;
        }
        if (PassCorr)
        {
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            transform.position = new Vector3(-1.5f, -2.4f, 0.0f);
            PassCorr = false;
        }
        if(Ener_C1 && Ener_C2)
        {
            CAPSULE.GetComponent<SpriteRenderer>().sprite = Capsule_OPEN;
            Key_Capsule.SetActive(true);
            Capsule = true;
            Ener_C1 = false;
            Ener_C2 = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DummyGuard")
        {
            EnemyKnockBack(transform.position.x);
        }
        if (collision.gameObject.name == "SwitchAP" && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            Key_YellowCardOBJ.SetActive(true);
            Inter_Guard.GetComponent<SpriteRenderer>().sprite = Inter_ON;
            
            Act_Guard = true;
        }
        if (collision.gameObject.name == "Capsule" && Input.GetKeyDown(KeyCode.E) && Capsule)//compara si hizo la colision con el objeto correcto
        {
            Key_Capsule.SetActive(false);
        }
        if (collision.gameObject.name == "YellowCard_OBJ" && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            YT = true;
        }
        if (collision.gameObject.name == "GreenCard_OBJ" && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            GT = true;
        }
        if (collision.gameObject.name == "GreenCard_ACT" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "GreenCard_INV")//compara si hizo la colision con el objeto correcto
        {
            GreenPass = true;
            dGT = true;
        }
        if (collision.gameObject.name == "YellowCard_ACT" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "YellowCard_INV")//compara si hizo la colision con el objeto correcto
        {
            YellowPass = true;
            dYT = true;
        }
        if (collision.gameObject.name == "DoorALMA" && ALMA && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            PassRoom = true;
        }
        if (collision.gameObject.name == "ExitALMA" && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            PassCorr = true;
        }
        if (collision.gameObject.name == "FINAL" && FINAL && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
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
            Debug.Log("A Dormir.............");
            SceneManager.LoadScene("Sala de Carga");
        }
        //------------------ENERGY----------------------
        if (collision.gameObject.name == "Energy_ALMA" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_Al)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_ALMA.GetComponent<SpriteRenderer>().color = Color.white;
            Door_ALMA.GetComponent<SpriteRenderer>().sprite = Door_ON;

            Key_EnergyALMA.SetActive(false);
            Ener_Al = true;
        }

        if (collision.gameObject.name == "Energy_FINAL" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_Fi)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_FINAL.GetComponent<SpriteRenderer>().color = Color.white;
            Door_FINAL.GetComponent<SpriteRenderer>().sprite = Door_ON;

            Key_EnergyFinal.SetActive(false);
            Ener_Fi = true;
        }

        if (collision.gameObject.name == "Energy_C1" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_C1)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_C1.GetComponent<SpriteRenderer>().color = Color.white;
            Key_EnergyC1.SetActive(false);
            Ener_C1 = true;
        }
        if (collision.gameObject.name == "Energy_C2" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_C2)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_C2.GetComponent<SpriteRenderer>().color = Color.white;
            Key_EnergyC2.SetActive(false);
            Ener_C2 = true;
        }
        //------------------------------------------------------------------------
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tran1" && s1)//compara si hizo la colision con el objeto correcto
        {
            Debug.Log(turret);
            turret = true;
            s1 = false;
            s2 = true;
            camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);


        }

        if (collision.gameObject.name == "Tran2" && s2)//compara si hizo la colision con el objeto correcto
        {
            turret = false;
            s1 = true;
            s2 = false;
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);


        }
        if (collision.gameObject.name == "Tran3" && s3)//compara si hizo la colision con el objeto correcto
        {


            s3 = false;
            s2 = true;
            camera.transform.position = new Vector3(36f, 0.0f, -10.0f);
            


        }

        if (collision.gameObject.name == "Tran4" && s2)//compara si hizo la colision con el objeto correcto
        {
            s3 = true;
            s2 = true;
            camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);


        }
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        PlayerController.jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);

        GetComponent<Rigidbody2D>().AddForce(Vector2.left * side * 1, ForceMode2D.Impulse);
        PlayerController.movement = false;


        Invoke("EnableMovement", 0.7f);



        GetComponent<SpriteRenderer>().color = Color.red;
    }
    void EnableMovement()
    {
        PlayerController.movement = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
