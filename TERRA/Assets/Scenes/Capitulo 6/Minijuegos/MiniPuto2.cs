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

    public static bool waitkeys, Plvl1, Plvl2, Plvl3, start;
    private bool CorrectKey1;
    private int randKey1;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
        Plvl1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Plvl1 && start)
        {
            lvl1();
            start = false;
        }
        if (Plvl1 && waitkeys)
        {
            if (KeyM1.activeSelf) checkKey(randKey1, KeyM1);
        }
        if (!start && !waitkeys && Input.GetKeyDown(KeyCode.Return))
        {
            KeyM1.SetActive(true);
            start = true;
        }
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

    void checkKey(int val, GameObject key)
    {
        if (val == 1 && Input.GetKeyDown(KeyCode.Alpha1))
        {

            key.SetActive(false);
        }
        else if (val == 2 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            key.SetActive(false);
        }
        else if (val == 3 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            key.SetActive(false);
        }
        else if (val == 4 && Input.GetKeyDown(KeyCode.Alpha4))
        {
            key.SetActive(false);
        }
        else if (val == 5 && Input.GetKeyDown(KeyCode.Alpha5))
        {
            key.SetActive(false);
        }
        else if (val == 6 && Input.GetKeyDown(KeyCode.Alpha6))
        {
            key.SetActive(false);
        }
        else if (val == 7 && Input.GetKeyDown(KeyCode.Alpha7))
        {
            key.SetActive(false);
        }
        else if (val == 8 && Input.GetKeyDown(KeyCode.Alpha8))
        {
            key.SetActive(false);
        }
        else if (val == 9 && Input.GetKeyDown(KeyCode.Alpha9))
        {
            key.SetActive(false);
        }
        else if (val == 10 && Input.GetKeyDown(KeyCode.Alpha0))
        {
            key.SetActive(false);
        }

        else if (val == 11 && Input.GetKeyDown(KeyCode.Q))
        {
            key.SetActive(false);
        }
        else if (val == 12 && Input.GetKeyDown(KeyCode.W))
        {
            key.SetActive(false);
        }
        else if (val == 13 && Input.GetKeyDown(KeyCode.E))
        {
            key.SetActive(false);
        }
        else if (val == 14 && Input.GetKeyDown(KeyCode.R))
        {
            key.SetActive(false);
        }
        else if (val == 15 && Input.GetKeyDown(KeyCode.T))
        {
            key.SetActive(false);
        }
        else if (val == 16 && Input.GetKeyDown(KeyCode.Y))
        {
            key.SetActive(false);
        }
        else if (val == 17 && Input.GetKeyDown(KeyCode.U))
        {
            key.SetActive(false);
        }
        else if (val == 18 && Input.GetKeyDown(KeyCode.I))
        {
            key.SetActive(false);
        }
        else if (val == 19 && Input.GetKeyDown(KeyCode.O))
        {
            key.SetActive(false);
        }
        else if (val == 20 && Input.GetKeyDown(KeyCode.P))
        {
            key.SetActive(false);
        }

        else if (val == 21 && Input.GetKeyDown(KeyCode.A))
        {
            key.SetActive(false);
        }
        else if (val == 22 && Input.GetKeyDown(KeyCode.S))
        {
            key.SetActive(false);
        }
        else if (val == 23 && Input.GetKeyDown(KeyCode.D))
        {
            key.SetActive(false);
        }
        else if (val == 24 && Input.GetKeyDown(KeyCode.F))
        {
            key.SetActive(false);
        }
        else if (val == 25 && Input.GetKeyDown(KeyCode.G))
        {
            key.SetActive(false);
        }
        else if (val == 26 && Input.GetKeyDown(KeyCode.H))
        {
            key.SetActive(false);
        }
        else if (val == 27 && Input.GetKeyDown(KeyCode.J))
        {
            key.SetActive(false);
        }
        else if (val == 28 && Input.GetKeyDown(KeyCode.K))
        {
            key.SetActive(false);
        }
        else if (val == 29 && Input.GetKeyDown(KeyCode.L))
        {
            key.SetActive(false);
        }
        else if (val == 30 && Input.GetKeyDown(KeyCode.Tab))
        {
            key.SetActive(false);
        }

        else if (val == 31 && Input.GetKeyDown(KeyCode.Z))
        {
            key.SetActive(false);
        }
        else if (val == 32 && Input.GetKeyDown(KeyCode.X))
        {
            key.SetActive(false);
        }
        else if (val == 33 && Input.GetKeyDown(KeyCode.C))
        {
            key.SetActive(false);
        }
        else if (val == 34 && Input.GetKeyDown(KeyCode.V))
        {
            key.SetActive(false);
        }
        else if (val == 35 && Input.GetKeyDown(KeyCode.B))
        {
            key.SetActive(false);
        }
        else if (val == 36 && Input.GetKeyDown(KeyCode.N))
        {
            key.SetActive(false);
        }
        else if (val == 37 && Input.GetKeyDown(KeyCode.M))
        {
            key.SetActive(false);
        }
        else if (val == 38 && Input.GetKeyDown(KeyCode.Space))
        {
            key.SetActive(false);
        }
        else if (val == 39 && Input.GetKeyDown(KeyCode.Delete))
        {
            key.SetActive(false);
        }
        else if (val == 40 && Input.GetKeyDown(KeyCode.Return))
        {
            key.SetActive(false);
        }
    }

    void lvl1()
    {
        randKey1 = Random.Range(1, 40);
        randomkey(randKey1, KeyM1);
        StartCoroutine(waitLvl1());
    }

    IEnumerator waitLvl1()
    {
        waitkeys = true;
        yield return new WaitForSeconds(5f);
        waitkeys = false;
    }
}
