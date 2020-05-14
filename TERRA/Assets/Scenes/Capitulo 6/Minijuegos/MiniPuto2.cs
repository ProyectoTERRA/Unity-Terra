using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniPuto2 : MonoBehaviour
{
    [SerializeField] private Sprite Key1;
    [SerializeField] private Sprite Key2;
    [SerializeField] private Sprite Key3;
    [SerializeField] private Sprite Key4;
    [SerializeField] private Sprite Key5;
    [SerializeField] private Sprite Key6;
    [SerializeField] private Sprite Key7;
    [SerializeField] private Sprite Key8;
    [SerializeField] private Sprite Key9;
    [SerializeField] private Sprite Key0;

    [SerializeField] private Sprite KeyQ;
    [SerializeField] private Sprite KeyW;
    [SerializeField] private Sprite KeyE;
    [SerializeField] private Sprite KeyR;
    [SerializeField] private Sprite KeyT;
    [SerializeField] private Sprite KeyY;
    [SerializeField] private Sprite KeyU;
    [SerializeField] private Sprite KeyI;
    [SerializeField] private Sprite KeyO;
    [SerializeField] private Sprite KeyP;

    [SerializeField] private Sprite KeyA;
    [SerializeField] private Sprite KeyS;
    [SerializeField] private Sprite KeyD;
    [SerializeField] private Sprite KeyF;
    [SerializeField] private Sprite KeyG;
    [SerializeField] private Sprite KeyH;
    [SerializeField] private Sprite KeyJ;
    [SerializeField] private Sprite KeyK;
    [SerializeField] private Sprite KeyL;
    [SerializeField] private Sprite KeyTab;

    [SerializeField] private Sprite KeyZ;
    [SerializeField] private Sprite KeyX;
    [SerializeField] private Sprite KeyC;
    [SerializeField] private Sprite KeyV;
    [SerializeField] private Sprite KeyB;
    [SerializeField] private Sprite KeyN;
    [SerializeField] private Sprite KeyM;
    [SerializeField] private Sprite KeySpace;
    [SerializeField] private Sprite KeyDel;
    [SerializeField] private Sprite KeyEnter;

    [SerializeField] private GameObject KeyM1;
    [SerializeField] private GameObject BackKey;

    [SerializeField] private GameObject Lvl1;
    [SerializeField] private GameObject Lvl2;
    [SerializeField] private GameObject Lvl3;

    [SerializeField] private GameObject View;

    [SerializeField] private GameObject F1;
    [SerializeField] private GameObject F2;
    [SerializeField] private GameObject F3;
    [SerializeField] private GameObject F4;

    [SerializeField] private GameObject P1;
    [SerializeField] private GameObject P2;
    [SerializeField] private GameObject P3;
    [SerializeField] private GameObject P4;
    [SerializeField] private GameObject P5;
    [SerializeField] private GameObject P6;
    [SerializeField] private GameObject P7;
    [SerializeField] private GameObject P8;
    [SerializeField] private GameObject P9;


    public Color verd, roj, bl;
    public static bool active, Plvl1, Plvl2, Plvl3, start1, c1, c2, c3, Lose, enable;
    private bool CorrectKey1;
    private int randKey1;
    private string State;
    public SliderPuto2 sl;
    public static int countF, countE;
    private float segs5 = 0.04f, segs3 = 0.024f
        , xFail1 = 216 + 36
        , xFail2_1 = 216, xFail2_2 = 288
        , xFail3_1 = 144, xFail3_2 = 216, xFail3_3 = 288
        , yPush1 = -130
        , yPush2_1 = -130 + 27, yPush2_2 = -130 - 27
        , yPush3_1 =  -75, yPush3_2 = -130, yPush3_3 = -184;
    public Sprite stay, pass, fail, FPstay, FPpass, FPfail;
    public BSliderPuto2 BS;
    // Start is called before the first frame update
    void Start()
    {
        View.SetActive(false);
        if (!c1)
        { 
            SliderPuto2.speed = segs5;
        }
        enable = true;

        SliderPuto2.speed = segs5;

        BS = GetComponent<BSliderPuto2>();

        State = "C";
        countF = 0;
        countE = 0;
        sl = GetComponent<SliderPuto2>();
        Plvl1 = true;

        FPcheckCount();
        FPcheckEn();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SliderPuto2.speed);
        Debug.Log(countE);
        if (Plvl1 && start1)
        {
            BackKey.GetComponent<SpriteRenderer>().color = bl;
            lvl1();
            //BSliderPuto2.start = true;
            
            start1 = false;
            active = true;
        }

        if (Plvl1 && active)
        {
            if (State == "C" && active ) State = checkKey(randKey1, KeyM1);
            else if (State == "F")
            {
                StartCoroutine(FAIL());
            }
            else if (State == "T")
            {
                if (active)
                {
                    StartCoroutine(next());
                }
               
                
            }
        }
        /*
        if (enable && !start1 && !active && Input.GetKeyDown(KeyCode.Return))
        {
            Renabled();
        }
        */
    }

    public void FPcheckEn()
    {
        if (!c1)
        {
            F1.SetActive(true);
            F2.SetActive(false);
            F3.SetActive(false);
            F4.SetActive(false);

            P1.SetActive(true);
            P2.SetActive(true);
            P3.SetActive(true);
            P4.SetActive(false);
            P5.SetActive(false);
            P6.SetActive(false);
            P7.SetActive(false);
            P8.SetActive(false);
            P9.SetActive(false);

            F1.transform.localPosition = new Vector3(xFail1, F1.transform.localPosition.y);

            P1.transform.localPosition = new Vector3(P1.transform.localPosition.x, yPush1);
            P2.transform.localPosition = new Vector3(P2.transform.localPosition.x, yPush1);
            P3.transform.localPosition = new Vector3(P3.transform.localPosition.x, yPush1);
        }
        else if (c1 && !c2)
        {
            F1.SetActive(true);
            F2.SetActive(true);
            F3.SetActive(false);
            F4.SetActive(false);

            P1.SetActive(true);
            P2.SetActive(true);
            P3.SetActive(true);
            P4.SetActive(true);
            P5.SetActive(true);
            P6.SetActive(true);
            P7.SetActive(false);
            P8.SetActive(false);
            P9.SetActive(false);

            F1.transform.localPosition = new Vector3(xFail2_1, F1.transform.localPosition.y);
            F2.transform.localPosition = new Vector3(xFail2_2, F2.transform.localPosition.y);

            P1.transform.localPosition = new Vector3(P1.transform.localPosition.x, yPush2_1);
            P2.transform.localPosition = new Vector3(P2.transform.localPosition.x, yPush2_1);
            P3.transform.localPosition = new Vector3(P3.transform.localPosition.x, yPush2_1);
            P4.transform.localPosition = new Vector3(P4.transform.localPosition.x, yPush2_2);
            P5.transform.localPosition = new Vector3(P5.transform.localPosition.x, yPush2_2);
            P6.transform.localPosition = new Vector3(P6.transform.localPosition.x, yPush2_2);
        }
        else if (c1 && c2)
        {
            F1.SetActive(true);
            F2.SetActive(true);
            F3.SetActive(true);
            F4.SetActive(true);

            P1.SetActive(true);
            P2.SetActive(true);
            P3.SetActive(true);
            P4.SetActive(true);
            P4.SetActive(true);
            P6.SetActive(true);
            P7.SetActive(true);
            P8.SetActive(true);
            P9.SetActive(true);

            F1.transform.localPosition = new Vector3(xFail3_1, F1.transform.localPosition.y);
            F2.transform.localPosition = new Vector3(xFail3_2, F2.transform.localPosition.y);
            F3.transform.localPosition = new Vector3(xFail3_3, F3.transform.localPosition.y);

            P1.transform.localPosition = new Vector3(P1.transform.localPosition.x, yPush3_1);
            P2.transform.localPosition = new Vector3(P2.transform.localPosition.x, yPush3_1);
            P3.transform.localPosition = new Vector3(P3.transform.localPosition.x, yPush3_1);
            P4.transform.localPosition = new Vector3(P4.transform.localPosition.x, yPush3_2);
            P5.transform.localPosition = new Vector3(P5.transform.localPosition.x, yPush3_2);
            P6.transform.localPosition = new Vector3(P6.transform.localPosition.x, yPush3_2);
            P7.transform.localPosition = new Vector3(P7.transform.localPosition.x, yPush3_3);
            P8.transform.localPosition = new Vector3(P8.transform.localPosition.x, yPush3_3);
            P9.transform.localPosition = new Vector3(P9.transform.localPosition.x, yPush3_3);

        }
    }

    public void FPcheckCount()
    {
        if (countE == 0)
        {
            F1.GetComponent<SpriteRenderer>().sprite = FPstay;
            F2.GetComponent<SpriteRenderer>().sprite = FPstay;
            F3.GetComponent<SpriteRenderer>().sprite = FPstay;
            F4.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if(countE == 1)
        {
            F1.GetComponent<SpriteRenderer>().sprite = FPfail;
            F2.GetComponent<SpriteRenderer>().sprite = FPstay;
            F3.GetComponent<SpriteRenderer>().sprite = FPstay;
            F4.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countE == 2)
        {
            F1.GetComponent<SpriteRenderer>().sprite = FPfail;
            F2.GetComponent<SpriteRenderer>().sprite = FPfail;
            F3.GetComponent<SpriteRenderer>().sprite = FPstay;
            F4.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countE == 3)
        {
            F1.GetComponent<SpriteRenderer>().sprite = FPfail;
            F2.GetComponent<SpriteRenderer>().sprite = FPfail;
            F3.GetComponent<SpriteRenderer>().sprite = FPfail;
            F4.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countE == 4)
        {
            F1.GetComponent<SpriteRenderer>().sprite = FPfail;
            F2.GetComponent<SpriteRenderer>().sprite = FPfail;
            F3.GetComponent<SpriteRenderer>().sprite = FPfail;
            F4.GetComponent<SpriteRenderer>().sprite = FPfail;
        }

        if (countF == 0)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPstay;
            P2.GetComponent<SpriteRenderer>().sprite = FPstay;
            P3.GetComponent<SpriteRenderer>().sprite = FPstay;
            P4.GetComponent<SpriteRenderer>().sprite = FPstay;
            P5.GetComponent<SpriteRenderer>().sprite = FPstay;
            P6.GetComponent<SpriteRenderer>().sprite = FPstay;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 1)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPstay;
            P3.GetComponent<SpriteRenderer>().sprite = FPstay;
            P4.GetComponent<SpriteRenderer>().sprite = FPstay;
            P5.GetComponent<SpriteRenderer>().sprite = FPstay;
            P6.GetComponent<SpriteRenderer>().sprite = FPstay;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 2)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPstay;
            P4.GetComponent<SpriteRenderer>().sprite = FPstay;
            P5.GetComponent<SpriteRenderer>().sprite = FPstay;
            P6.GetComponent<SpriteRenderer>().sprite = FPstay;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 3)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPstay;
            P5.GetComponent<SpriteRenderer>().sprite = FPstay;
            P6.GetComponent<SpriteRenderer>().sprite = FPstay;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 4)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPpass;
            P5.GetComponent<SpriteRenderer>().sprite = FPstay;
            P6.GetComponent<SpriteRenderer>().sprite = FPstay;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 5)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPpass;
            P5.GetComponent<SpriteRenderer>().sprite = FPpass;
            P6.GetComponent<SpriteRenderer>().sprite = FPstay;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 6)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPpass;
            P5.GetComponent<SpriteRenderer>().sprite = FPpass;
            P6.GetComponent<SpriteRenderer>().sprite = FPpass;
            P7.GetComponent<SpriteRenderer>().sprite = FPstay;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 7)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPpass;
            P5.GetComponent<SpriteRenderer>().sprite = FPpass;
            P6.GetComponent<SpriteRenderer>().sprite = FPpass;
            P7.GetComponent<SpriteRenderer>().sprite = FPpass;
            P8.GetComponent<SpriteRenderer>().sprite = FPstay;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 8)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPpass;
            P5.GetComponent<SpriteRenderer>().sprite = FPpass;
            P6.GetComponent<SpriteRenderer>().sprite = FPpass;
            P7.GetComponent<SpriteRenderer>().sprite = FPpass;
            P8.GetComponent<SpriteRenderer>().sprite = FPpass;
            P9.GetComponent<SpriteRenderer>().sprite = FPstay;
        }
        else if (countF == 9)
        {
            P1.GetComponent<SpriteRenderer>().sprite = FPpass;
            P2.GetComponent<SpriteRenderer>().sprite = FPpass;
            P3.GetComponent<SpriteRenderer>().sprite = FPpass;
            P4.GetComponent<SpriteRenderer>().sprite = FPpass;
            P5.GetComponent<SpriteRenderer>().sprite = FPpass;
            P6.GetComponent<SpriteRenderer>().sprite = FPpass;
            P7.GetComponent<SpriteRenderer>().sprite = FPpass;
            P8.GetComponent<SpriteRenderer>().sprite = FPpass;
            P9.GetComponent<SpriteRenderer>().sprite = FPpass;
        }

    }

    public IEnumerator Renabled()
    {

        yield return new WaitForSeconds(0.1f);
        sl.reset();
        countE = 0;
        countF = 0;
        State = "C";
        start1 = true;
        FPcheckCount();
        FPcheckEn();
        yield return new WaitForSeconds(0.3f);
        View.SetActive(true);
        BSliderPuto2.start = true;
        BSliderPuto2.Barempty = false;
    }
    void randomkey(int val, GameObject key)
    {
        Debug.Log(val);

        if (val == 0)
        {
            key.GetComponent<SpriteRenderer>().sprite = null;
        }

        if (val == 1)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key1;
        }
        else if (val == 2)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key2;
        }
        else if (val == 3)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key3;
        }
        else if (val == 4)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key4;
        }
        else if (val == 5)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key5;
        }
        else if (val == 6)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key6;
        }
        else if (val == 7)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key7;
        }
        else if (val == 8)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key8;
        }
        else if (val == 9)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key9;
        }
        else if (val == 10)
        {
            key.GetComponent<SpriteRenderer>().sprite = Key0;
        }

        else if (val == 11)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyQ;
        }
        else if (val == 12)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyW;
        }
        else if (val == 13)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyE;
        }
        else if (val == 14)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyR;
        }
        else if (val == 15)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyT;
        }
        else if (val == 16)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyY;
        }
        else if (val == 17)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyU;
        }
        else if (val == 18)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyI;
        }
        else if (val == 19)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyO;
        }
        else if (val == 20)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyP;
        }

        else if (val == 21)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyA;
        }
        else if (val == 22)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyS;
        }
        else if (val == 23)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyD;
        }
        else if (val == 24)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyF;
        }
        else if (val == 25)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyG;
        }
        else if (val == 26)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyH;
        }
        else if (val == 27)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyJ;
        }
        else if (val == 28)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyK;
        }
        else if (val == 29)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyL;
        }
        else if (val == 30)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyTab;
        }

        else if (val == 31)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyZ;
        }
        else if (val == 32)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyX;
        }
        else if (val == 33)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyC;
        }
        else if (val == 34)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyV;
        }
        else if (val == 35)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyB;
        }
        else if (val == 36)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyN;
        }
        else if (val == 37)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyM;
        }
        else if (val == 38)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeySpace;
        }
        else if (val == 39)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyDel;
        }
        else if (val == 40)
        {
            key.GetComponent<SpriteRenderer>().sprite = KeyEnter;
        }
    }

    string checkKey(int val, GameObject key)
    {
        if (val == 1 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 2 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 3 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 4 && Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 5 && Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 6 && Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 7 && Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 8 && Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 9 && Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 10 && Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }

        else if (val == 11 && Input.GetKeyDown(KeyCode.Q))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 12 && Input.GetKeyDown(KeyCode.W))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 13 && Input.GetKeyDown(KeyCode.E))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 14 && Input.GetKeyDown(KeyCode.R))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 15 && Input.GetKeyDown(KeyCode.T))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 16 && Input.GetKeyDown(KeyCode.Y))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 17 && Input.GetKeyDown(KeyCode.U))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 18 && Input.GetKeyDown(KeyCode.I))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 19 && Input.GetKeyDown(KeyCode.O))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 20 && Input.GetKeyDown(KeyCode.P))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }

        else if (val == 21 && Input.GetKeyDown(KeyCode.A))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 22 && Input.GetKeyDown(KeyCode.S))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 23 && Input.GetKeyDown(KeyCode.D))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 24 && Input.GetKeyDown(KeyCode.F))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 25 && Input.GetKeyDown(KeyCode.G))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 26 && Input.GetKeyDown(KeyCode.H))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 27 && Input.GetKeyDown(KeyCode.J))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 28 && Input.GetKeyDown(KeyCode.K))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 29 && Input.GetKeyDown(KeyCode.L))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 30 && Input.GetKeyDown(KeyCode.Tab))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }

        else if (val == 31 && Input.GetKeyDown(KeyCode.Z))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 32 && Input.GetKeyDown(KeyCode.X))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 33 && Input.GetKeyDown(KeyCode.C))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 34 && Input.GetKeyDown(KeyCode.V))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 35 && Input.GetKeyDown(KeyCode.B))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 36 && Input.GetKeyDown(KeyCode.N))
        {
            if(SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 37 && Input.GetKeyDown(KeyCode.M))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 38 && Input.GetKeyDown(KeyCode.Space))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 39 && Input.GetKeyDown(KeyCode.Backspace))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (val == 40 && Input.GetKeyDown(KeyCode.Return))
        {
            if (SliderPuto2.Target) return "T";
            else return "F";
        }
        else if (Input.anyKeyDown)
        {
            return "F";
        }
        else
        {
            return "C";
        }
    }

    void lvl1()
    {
        randKey1 = Random.Range(1, 40);
        randomkey(randKey1, KeyM1);
    }
    public IEnumerator FAIL()
    {
        SliderPuto2.active = false;
        active = false;
        BackKey.GetComponent<SpriteRenderer>().color = roj;

        countE++;
        FPcheckCount();

        if (!c1 && !c2 && !c3 && countE == 1)
        {
            Lvl1.GetComponent<SpriteRenderer>().sprite = fail;
            Lvl2.GetComponent<SpriteRenderer>().sprite = fail;
            Lvl3.GetComponent<SpriteRenderer>().sprite = fail;
            BSliderPuto2.active = false;
            Lose = true;
        }
        else if (c1 && !c2 && !c3 && countE == 2)
        {
            Lvl1.GetComponent<SpriteRenderer>().sprite = fail;
            Lvl2.GetComponent<SpriteRenderer>().sprite = fail;
            Lvl3.GetComponent<SpriteRenderer>().sprite = fail;
            BSliderPuto2.active = false;
            Lose = true;
        }
        else if (c1 && c2 && !c3 && countE == 4)
        {
            Lvl1.GetComponent<SpriteRenderer>().sprite = fail;
            Lvl2.GetComponent<SpriteRenderer>().sprite = fail;
            Lvl3.GetComponent<SpriteRenderer>().sprite = fail;
            BSliderPuto2.active = false;
            Lose = true;
        }
        if (!Lose)
        {
            yield return new WaitForSeconds(0.2f);
        }
        else
        {
            yield return new WaitForSeconds(2f);
        }
        State = "C";
        FPcheckEn();
        if (Lose)
        {
            StartCoroutine(LOSE());
        }
        else
        {
            sl.reset();
            start1 = true;
            if (!c1 && !c2 && !c3)
            {
                Lvl1.GetComponent<SpriteRenderer>().sprite = stay;
                Lvl2.GetComponent<SpriteRenderer>().sprite = stay;
                Lvl3.GetComponent<SpriteRenderer>().sprite = stay;
                SliderPuto2.speed = segs5;
            }
            else if (c1 && !c2 && !c3)
            {
                Lvl1.GetComponent<SpriteRenderer>().sprite = pass;
                Lvl2.GetComponent<SpriteRenderer>().sprite = stay;
                Lvl3.GetComponent<SpriteRenderer>().sprite = stay;
                SliderPuto2.speed = segs3;
            }
            else if (c1 && c2 && !c3)
            {

                Lvl1.GetComponent<SpriteRenderer>().sprite = pass;
                Lvl2.GetComponent<SpriteRenderer>().sprite = pass;
                Lvl3.GetComponent<SpriteRenderer>().sprite = stay;
                SliderPuto2.speed = segs3;
            }
        }
            
        
       
        
    }
    IEnumerator LOSE()
    {
        SliderPuto2.active = false;
        BS.Refill();

        active = false;
        enable = false;
        View.SetActive(false);
        BackKey.GetComponent<SpriteRenderer>().color = roj;
        yield return new WaitForSeconds(10f);
        Lose = false;
        enable = true;
        countE = 0;
        if (!c1 && !c2 && !c3)
        {
            Lvl1.GetComponent<SpriteRenderer>().sprite = stay;
            Lvl2.GetComponent<SpriteRenderer>().sprite = stay;
            Lvl3.GetComponent<SpriteRenderer>().sprite = stay;
            SliderPuto2.speed = segs5;
        }
        else if (c1 && !c2 && !c3)
        {
            Lvl1.GetComponent<SpriteRenderer>().sprite = pass;
            Lvl2.GetComponent<SpriteRenderer>().sprite = stay;
            Lvl3.GetComponent<SpriteRenderer>().sprite = stay;
            SliderPuto2.speed = segs3;
        }
        else if (c1 && c2 && !c3)
        {
            Lvl1.GetComponent<SpriteRenderer>().sprite = pass;
            Lvl2.GetComponent<SpriteRenderer>().sprite = pass;
            Lvl3.GetComponent<SpriteRenderer>().sprite = stay;
            SliderPuto2.speed = segs3;
        }

    }
    IEnumerator next()
    {
        bool tr = false;
        active = false;
        State = "C";
        SliderPuto2.active = false;
        BackKey.GetComponent<SpriteRenderer>().color = verd;
        countF++;
        FPcheckCount();
        if ( !c1 && !c2 && !c3 && Plvl1 && countF == 3)
        {
            tr = true;
            BSliderPuto2.active = false;
            c1 = true;
            active = false;
            Lvl1.GetComponent<SpriteRenderer>().sprite = pass;
            SliderPuto2.speed = segs3;
            countF = 0;
        }
        else if (c1 && !c2 && !c3 && Plvl1 && countF == 6)
        {
            tr = true;
            BSliderPuto2.active = false;
            c2 = true;
            active = false;
            Lvl2.GetComponent<SpriteRenderer>().sprite = pass;
            countF = 0;
        }
        else if (c1 && c2 && !c3 && Plvl1 && countF == 9)
        {
            tr = true;
            BSliderPuto2.active = false;
            c3 = true;
            active = false;
            Lvl3.GetComponent<SpriteRenderer>().sprite = pass;
            countF = 0;
        }
        if (c3 && c2 && c1)
        {
            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
        }
       
        
        if (tr)
        {
            BSliderPuto2.start = true;
            BS.Refill();
            tr = false;
        }
        
        FPcheckEn();
        FPcheckCount();
        if (countF == 0 && !c3)
        {
            start1 = true;
            sl.reset();
        }
        if (c3)
        {
            View.SetActive(false);
        }
        if (!c1 && !c2 && !c3 && Plvl1 && countF < 3 && countF > 0)
        {
            start1 = true;
            sl.reset();
        }
        else if (c1 && !c2 && !c3 && Plvl1 && countF < 6 && countF > 0)
        {
            start1 = true;
            sl.reset();
        }
        else if (c1 && c2 && !c3 && Plvl1 && countF < 9 && countF > 0)
        {
            start1 = true;
            sl.reset();
        }
    }
}
