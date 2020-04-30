using UnityEngine;
using UnityEngine.UI;
public class Hability_1 : MonoBehaviour
{
    [SerializeField] private GameObject inv;
    [SerializeField] private GameObject Lobby_Equip1;
    public Sprite DoubleJump;
    public Sprite LongJump;
    public Sprite Invisible;
    public Sprite Dash;

    public bool disp;
    public bool act;

    public float actD;
    public float dispD;

    private bool HNull;

    public Color ac = new Color(0.8679245f, 0.3561766f, 0.3814742f, 1f);


    public SpriteRenderer spr;

    private string set = "";

    void Start()
    {
        set = GameController.H1Equip;
        spr = GetComponent<SpriteRenderer>();


        if (set == null)
        {
            inv.SetActive(false);
        }
        else
        {

            inv.SetActive(true);
            inv.GetComponent<Image>().sprite = spr.sprite;

        }

        disp = true;
        act = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {

        Debug.Log(set);

        set = GameController.H1Equip;

        if (GameController.LOBBY)
        {
            if (set == null)
            {
                Lobby_Equip1.SetActive(false);
            }
            else
            {

                Lobby_Equip1.SetActive(true);
                Lobby_Equip1.GetComponent<Image>().sprite = spr.sprite;

            }
        }

        if (set == null)
        {
            HNull = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            HNull = false;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (set == "Double_Jump")
        {
            LoBbY.DJEquip = true;
            spr.sprite = DoubleJump;
            dispD = 120;
            actD = 10;
        }

        else if (set == "Long_Jump")
        {
            LoBbY.LJEquip = true;
            spr.sprite = LongJump;
            dispD = 120;
            actD = 5;
        }
        else if (set == "Invisible")
        {
            LoBbY.IEquip = true;
            spr.sprite = Invisible;
            dispD = 240;
            actD = 5;
        }

        else if (set == "Dash")
        {
            LoBbY.DEquip = true;
            spr.sprite = Dash;
            dispD = 20;
            actD = 1;
        }


        if (disp && !HNull)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                act = true;
                disp = false;
                Invoke("Activate", actD);
            }
            spr.color = Color.white;
        }
        else if (act)
        {


            spr.color = ac;
            Debug.Log(spr.color);
        }
        else if (!act && !disp)
        {
            spr.color = Color.gray;
        }


    }


    public void Activate()
    {
        act = false;
        disp = false;
        Invoke("Dispo", dispD);

    }

    public void Dispo()
    {
        act = false;
        disp = true;

    }
}
