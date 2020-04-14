using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorredores : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject LIST;

    [SerializeField] private GameObject Inter_Guard;
    [SerializeField] private GameObject Fake_APL;
    [SerializeField] private GameObject Legit_APL;


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
    private bool YellowPass, GreenPass, Ener_Al, Ener_Fi, Ener_C1, Ener_C2, Act_Guard, FINAL, ALMA, YT, GT, dYT, dGT, dEnergy, PassRoom, PassCorr, Capsule;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(Fake_APL);
            Legit_APL.SetActive(true);
            Act_Guard = false;
        }
        if (YT)
        {
            List.select.Add(YellowCard_INV);
            Destroy(YellowCard_OBJ);
            YT = false;
        }
        if (GT)
        {
            List.select.Add(GreenCard_INV);
            Destroy(GreenCard_OBJ);
            GT = false;
        }
        if (dYT)
        {
            YellowCard_ACT.GetComponent<SpriteRenderer>().color = Color.white; 
            List.select.Remove(YellowCard_INV);
            List.index = 0;
            dYT = false;
        }
        if (dGT)
        {
            GreenCard_ACT.GetComponent<SpriteRenderer>().color = Color.white;
            List.select.Remove(GreenCard_INV);
            List.index = 0;
            dGT = false;
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

        if(GreenPass && Ener_Fi)
        {
            Door_FINAL.GetComponent<SpriteRenderer>().sprite = Door_Access;
            FINAL = true;
            GreenPass = false;
            Ener_Fi = false;
        }

        if (YellowPass && Ener_Al)
        {
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
            Ener_C1 = false;
            Ener_C2 = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SwitchAP" && Input.GetKeyDown(KeyCode.E))//compara si hizo la colision con el objeto correcto
        {
            Inter_Guard.GetComponent<SpriteRenderer>().sprite = Inter_ON;
            Act_Guard = true;
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
            Debug.Log("A Dormir.............");
        }
        //------------------ENERGY----------------------
        if (collision.gameObject.name == "Energy_ALMA" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_Al)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_ALMA.GetComponent<SpriteRenderer>().color = Color.white;
            Door_ALMA.GetComponent<SpriteRenderer>().sprite = Door_ON;
            Ener_Al = true;
        }

        if (collision.gameObject.name == "Energy_FINAL" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_Fi)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_FINAL.GetComponent<SpriteRenderer>().color = Color.white;
            Door_FINAL.GetComponent<SpriteRenderer>().sprite = Door_ON;
            Ener_Fi = true;
        }

        if (collision.gameObject.name == "Energy_C1" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_C1)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_C1.GetComponent<SpriteRenderer>().color = Color.white;
            Ener_C1 = true;
        }
        if (collision.gameObject.name == "Energy_C2" && Input.GetKeyDown(KeyCode.J) && PlayerController.Equip == "Especiales_0" && !Ener_C2)//compara si hizo la colision con el objeto correcto
        {
            dEnergy = true;
            Energy_C2.GetComponent<SpriteRenderer>().color = Color.white;
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
}
