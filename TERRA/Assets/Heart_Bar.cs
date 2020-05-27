using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart_Bar : MonoBehaviour
{
    public Sprite LIFE_5x10;
    public Sprite LIFE_5x9;
    public Sprite LIFE_5x8;
    public Sprite LIFE_5x7;
    public Sprite LIFE_5x6;
    public Sprite LIFE_5x5;
    public Sprite LIFE_5x4;
    public Sprite LIFE_5x3;
    public Sprite LIFE_5x2;
    public Sprite LIFE_5x1;
    public Sprite LIFE_5x0;

    public Sprite LIFE_4x8;
    public Sprite LIFE_4x7;
    public Sprite LIFE_4x6;
    public Sprite LIFE_4x5;
    public Sprite LIFE_4x4;
    public Sprite LIFE_4x3;
    public Sprite LIFE_4x2;
    public Sprite LIFE_4x1;
    public Sprite LIFE_4x0;


    public Sprite LIFE_3x6;
    public Sprite LIFE_3x5;
    public Sprite LIFE_3x4;
    public Sprite LIFE_3x3;
    public Sprite LIFE_3x2;
    public Sprite LIFE_3x1;
    public Sprite LIFE_3x0;

    public GameObject LIFES;

    public Sprite Lifesx00;
    public Sprite Lifesx01;
    public Sprite Lifesx02;
    public Sprite Lifesx03;
    public Sprite Lifesx04;
    public Sprite Lifesx05;

    public static int type;
    public static int life;
    public int hearts;
    public static int Phearts;

    private int Ls1 = 6;
    private int Ls2 = 8;
    private int Ls3 = 10;

    public static int Maxlife;

    public static bool FULL;

    void Start()
    {
        Debug.Log(type);

        /*
        if (GameController.start)
        {
            life = GameController.life;
            
        }
        else
        {
            GameController.life = 3;
            life = GameController.life;
            GameController.start = true;
        }*/

        
    }
    void Update()
    {
        type = GameController.TypeLife;
        
        Debug.Log(Phearts);
        Debug.Log(life);

        hearts = Phearts;

        if (life <= 0)
        {

            Debug.Log("En heart bar perdio todas las vidas");
            life = 0;
            StartCoroutine(DIE2());
        }
        else if (hearts <= 0 && life >=1)
        {
            Debug.Log("En heart bar perdio una vida");
            hearts = 0;
            StartCoroutine(DIE());
        }

        switch (type)
        {
            case 1:
                {
                    transform.localPosition = new Vector3(-7f, 4f, 10f);
                    LIFES.transform.localPosition = new Vector3(2.5f, 0f);

                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        if (hearts > 0 && life > 0)
                        {
                            Phearts--;
                        }

                    }

                    if (hearts <= 0 && life > 1)
                    {
                        //hearts = Ls1;

                    }
                    else if (hearts <= 0 && life <= 1)
                    {

                        //life = 0;
                    }

                    if (hearts > 6)
                    {
                        hearts = 6;
                    }

                    if (hearts < 6)
                    {
                        FULL = false;
                    }

                    if (hearts == 6)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x6;
                        FULL = true;
                    }

                    else if (hearts == 5)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x5;
                    }

                    else if (hearts == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x4;
                    }

                    else if (hearts == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x3;
                    }

                    else if (hearts == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x2;
                    }

                    else if (hearts == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x1;
                    }

                    else if (hearts == 0)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_3x0;
                    }


                    break;
                }

            case 2:
                {
                    transform.localPosition = new Vector3(-6.5f, 4f, 10f);
                    LIFES.transform.localPosition = new Vector3(3f, 0f);

                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        if (hearts > 0 && life > 0)
                        {
                           Phearts--;
                        }

                    }
                    /*
                    if (hearts <= 0 && life > 1)
                    {
                        Debug.Log("que es esto" + Ls2);
                        //hearts = Ls2;
                        //life--;
                    }
                    else if (hearts <= 0 && life <= 1)
                    {
                        //life = 0;
                    }*/

                    if (hearts > 8)
                    {
                        hearts = 8;
                    }

                    if (hearts < 8)
                    {
                        FULL = false;
                    }

                    if (hearts == 8)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x8;
                        FULL = true;
                    }

                    else if (hearts == 7)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x7;
                    }

                    else if (hearts == 6)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x6;
                    }

                    else if (hearts == 5)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x5;
                    }

                    else if (hearts == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x4;
                    }

                    else if (hearts == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x3;
                    }

                    else if (hearts == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x2;
                    }

                    else if (hearts == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x1;
                    }

                    else if (hearts == 0)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_4x0;
                    }


                    break;
                }

            case 3:
                {
                    transform.localPosition = new Vector3(-6f, 4f, 10f);
                    LIFES.transform.localPosition = new Vector3(3.5f, 0f);

                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        if (hearts > 0 && life > 0)
                        {
                            Phearts--;
                        }

                    }

                    if (hearts <= 0 && life > 1)
                    {
                        hearts = Ls3;
                        //life--;
                    }
                    else if (hearts <= 0 && life <= 1)
                    {
                        //life = 0;
                    }

                    if (hearts > 10)
                    {
                        hearts = 10;
                    }

                    if (hearts < 10)
                    {
                        FULL = false;
                    }

                    if (hearts == 10)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x10;
                        FULL = true;
                    }
                    else if (hearts == 9)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x9;
                    }
                    else if (hearts == 8)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x8;
                    }
                    else if (hearts == 7)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x7;
                    }
                    else if (hearts == 6)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x6;
                    }

                    else if (hearts == 5)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x5;
                    }
                    else if (hearts == 4)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x4;
                    }

                    else if (hearts == 3)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x3;
                    }
                    else if (hearts == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x2;
                    }
                    else if (hearts == 1)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x1;
                    }
                    else if (hearts == 0)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = LIFE_5x0;
                    }
                    break;
                }
            default:
                {
                    transform.localPosition = new Vector3(-6f, 4f, 10f);
                    LIFES.transform.localPosition = new Vector3(3.5f, 0f);
                    break;
                }


        }

        // life

        if (life == 5)
        {
            LIFES.GetComponent<SpriteRenderer>().sprite = Lifesx05;
        }

        else if (life == 4)
        {
            LIFES.GetComponent<SpriteRenderer>().sprite = Lifesx04;
        }

        else if (life == 3)
        {
            LIFES.GetComponent<SpriteRenderer>().sprite = Lifesx03;
        }

        else if (life == 2)
        {
            LIFES.GetComponent<SpriteRenderer>().sprite = Lifesx02;
        }

        else if (life == 1)
        {
            LIFES.GetComponent<SpriteRenderer>().sprite = Lifesx01;
        }

        else if (life == 0)
        {
            LIFES.GetComponent<SpriteRenderer>().sprite = Lifesx00;
        }

        if (hearts == 6)
        {

        }
        else if (hearts == 5)
        {

        }
        else if (hearts == 4)
        {

        }
        else if (hearts == 3)
        {

        }
        else if (hearts == 2)
        {

        }
        else if (hearts == 1)
        {

        }
        else if (hearts == 1)
        {

        }
    }

    public void Refill()
    {
        Debug.Log("aqui entro");
        GameController.corazones = GameController.HeartsMax;
        Phearts = GameController.corazones;   
        GameController.vidas = GameController.LifeMax;
        life = GameController.vidas;
    }

    public IEnumerator DIE()
    {
        yield return new WaitForSeconds(1f);
        //GameController.life--;
        PlayerController.movement = true;
        Turret.act = false;
        SistemaGuardado.perder = 1;
        SistemaGuardado.morir = 0;

    }
    public IEnumerator DIE2()
    {
        yield return new WaitForSeconds(1f);
        //GameController.life--;
        PlayerController.movement = true;
        Turret.act = false;
        SistemaGuardado.morir = 1;
        SistemaGuardado.perder = 0;
        Refill();
    }
}
