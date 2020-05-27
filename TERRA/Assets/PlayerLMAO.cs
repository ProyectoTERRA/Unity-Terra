using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLMAO : MonoBehaviour
{
    private float X_support;
    [SerializeField] private GameObject Equip;
    [SerializeField] private GameObject H;
    [SerializeField] private Slider Slide;
    [SerializeField] private GameObject SlideV;
    [SerializeField] private Text LR;
    [SerializeField] private GameObject list;


    private bool healing, cSide, Front, Press, Launch, SPT;

    public Sprite half, ept;
    // Start is called before the first frame update
    void Start()
    {
       

        Heart_Bar.Phearts = 6;
        cSide = false;
        Front = true;
        healing = false;
        StartCoroutine(PL());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();
        if (radial.latas_recharge < 10)
        {
            LR.text = "x0" + radial.latas_recharge;
        }
        else
        {
            LR.text = "x" + radial.latas_recharge;
        }


        if (cSide)
        {
            cSide = false;

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
        if (PlayerController.Equip == "Esfera Pesada")
        {
            if (Input.GetKey(KeyCode.J))
            {

                SlideV.SetActive(true);

                Press = true;
            }
            else if (!Input.GetKey(KeyCode.J))
            {

                Press = false;
                SlideV.SetActive(false);
                Slide.value = 0;
                Equip.GetComponent<SpriteRenderer>().sprite = ept;
            }
        }
        else
        {
            SlideV.SetActive(false);
            Press = false;
            Slide.value = 0;
        }

        if (Launch)
        {
           
            var pl = GameObject.Find("Jugador");
            Instantiate(H, pl.transform.position, Quaternion.identity);

            radial.esfera[4]--;

            string normal = "heavy";
            if (radial.esfera[4] <= 0) list.SendMessage("remove", normal);
            Launch = false;
            SlideV.SetActive(false);
            Press = false;
        }

    }

    public IEnumerator PL()
    {
        yield return new WaitForSeconds(.04f);
        if (Press)
        {

            Slide.value = Slide.value + 1;
        }
        if(Slide.value >= 50)
        {
            Equip.GetComponent<SpriteRenderer>().sprite = half;
        }
        if(Slide.value >= 100)
        {
            Launch = true;
            Slide.value = 0;
            Equip.GetComponent<SpriteRenderer>().sprite = ept;

        }
        StartCoroutine(PL());
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BACK" && !cSide && Front)//compara si hizo la colision con el objeto correcto
        {
            Front = false;
            cSide = true;
            Debug.Log("SSSSSS");
            LMAO_Controller.side = LMAO_Controller.side * -1;

        }
        if (collision.gameObject.name == "FRONT")//compara si hizo la colision con el objeto correcto
        {
            Front = true;

        }

        if (collision.gameObject.name == "PUNCH" && !healing)
        {
            EnemyKnockBack(transform.position.x);
        }
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        Heart_Bar.Phearts -= 4;
        X_support = transform.position.x;
        healing = true;
        PlayerController.jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);


        PlayerController.movement = false;


        Invoke("EnableMovement", 0.7f);



        GetComponent<SpriteRenderer>().color = Color.red;

    }
    void EnableMovement()
    {

        healing = false;
        PlayerController.movement = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
