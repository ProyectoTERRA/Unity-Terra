using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniPuto1 : MonoBehaviour
{
    [SerializeField] private Text TD;
    [SerializeField] private Text Te1;
    [SerializeField] private Text Tt1;
    [SerializeField] private Text Te2;
    [SerializeField] private Text Tn1;
    [SerializeField] private Text Te3;
    [SerializeField] private Text Tr1;
    [SerializeField] private Text TP;
    [SerializeField] private Text Tl;
    [SerializeField] private Text Ta1;
    [SerializeField] private Text Tn2;
    [SerializeField] private Text TM;
    [SerializeField] private Text Ta2;
    [SerializeField] private Text Te4;
    [SerializeField] private Text Ts;
    [SerializeField] private Text Tt2;
    [SerializeField] private Text Tr2;
    [SerializeField] private Text To;

    [SerializeField] private GameObject Error1;
    [SerializeField] private GameObject Error2;
    [SerializeField] private GameObject Error3;
    [SerializeField] private GameObject Error4;
    [SerializeField] private GameObject Error5;

    [SerializeField] private GameObject self;

    public Sprite ErrorOn, ErrorWin;

    public static bool active, win, fail;
    private int Errors;
    private bool Press1, Press2, Press3, Press4, Press5, Press6, Press7, Press8, Press9, Press10, Press11;
    // Start is called before the first frame update
    void Start()
    {
        Errors = 0;

        active = false;
        win = false;
        fail = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !win && !fail) {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Press1 = true;
                TD.text = "D";
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Press2 = true;
                Te1.text = "e";
                Te2.text = "e";
                Te3.text = "e";
                Te4.text = "e";
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                Press3 = true;
                Tt1.text = "t";
                Tt2.text = "t";
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                Press4 = true;
                Tn1.text = "n";
                Tn2.text = "n";

            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Press5 = true;
                Tr1.text = "r";
                Tr2.text = "r";
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Press6 = true;
                TP.text = "P";
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Press7 = true;
                Tl.text = "l";
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Press8 = true;
                Ta1.text = "a";
                Ta2.text = "a";
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                Press9 = true;
                TM.text = "M";
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Press10 = true;
                Ts.text = "s";
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                Press11 = true;
                To.text = "o";
            }
            else if (Input.anyKeyDown)
            {
                Errors++;
                Debug.Log(Errors);
            }
            if (Errors == 1)
            {
                Error1.GetComponent<SpriteRenderer>().sprite = ErrorOn;
            }

            if (Errors == 2)
            {
                Error2.GetComponent<SpriteRenderer>().sprite = ErrorOn;
            }

            if (Errors == 3)
            {
                Error3.GetComponent<SpriteRenderer>().sprite = ErrorOn;
            }

            if (Errors == 4)
            {
                Error4.GetComponent<SpriteRenderer>().sprite = ErrorOn;
            }

            if (Errors == 5)
            {
                Error5.GetComponent<SpriteRenderer>().sprite = ErrorOn;
            }

            if (Errors >= 5)
            {
                Debug.Log("Puto");
                StartCoroutine(Lose());

            }

            if (Press1 && Press2 && Press3 && Press4 && Press5 && Press6 && Press7 && Press8 && Press9 && Press10 && Press11)
            {
                Error1.GetComponent<SpriteRenderer>().sprite = ErrorWin;
                Error2.GetComponent<SpriteRenderer>().sprite = ErrorWin;
                Error3.GetComponent<SpriteRenderer>().sprite = ErrorWin;
                Error4.GetComponent<SpriteRenderer>().sprite = ErrorWin;
                Error5.GetComponent<SpriteRenderer>().sprite = ErrorWin;

                StartCoroutine(Win());
            }
        }

    }

    IEnumerator Lose()
    {
        fail = true;
        yield return new WaitForSeconds(2f);
        Destroy(self);
    }

    IEnumerator Win()
    {
        win = true;
        yield return new WaitForSeconds(2f);
        Destroy(self);

    }

}
