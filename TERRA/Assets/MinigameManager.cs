using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    int N1, N2, N3, N4;
    int C1, C2, C3, C4;
    public string CC;
    public SpriteRenderer col1, col2, col3, col4;
    public GameObject D1, D2, D3, D4;
    public Sprite S1, S2, S3, S4, S5, S6, S7, S8, S9, S0;
    Color Cafe = new Color(0.6039216f, 0.2117647f, 0, 1);
    Color Naranja = new Color(0.9529412f, 0.6117647f, 0.07058824f, 1);
    Color Morado = new Color(0.5333334f, 0.3058824f, 0.627451f, 1);

    // Start is called before the first frame update
    void Start()
    {
        #region RANDOM
        N1 = Random.Range(0, 10);
        N2 = Random.Range(0, 10);
        N3 = Random.Range(0, 10);
        N4 = Random.Range(0, 10);

        C1 = Random.Range(0, 10);
        C2 = Random.Range(0, 10);
        C3 = Random.Range(0, 10);
        C4 = Random.Range(0, 10);

        CC = "Valor 1: " + C1; 
        #endregion
        

        Debug.Log(N1);
        Debug.Log(N2);
        Debug.Log(N3);
        Debug.Log(N4);

        Debug.Log(C1);
        Debug.Log(C2);
        Debug.Log(C3);
        Debug.Log(C4);


        #region Colores

        //----------- C1 -----------------

        if (C1 == 0)
        {
            col1.color = Color.black;
           
        }
        else if (C1 == 1)
        {
            col1.color = Cafe;
        }
        else if (C1 == 2)
        {
            col1.color = Color.red;
        }
        else if (C1 == 3)
        {
            col1.color = Naranja;          
        }
        else if (C1 == 4)
        {
            col1.color = Color.yellow;
        }
        else if (C1 == 5)
        {
            col1.color = Color.green;
        }
        else if (C1 == 6)
        {
            col1.color = Color.blue;
        }
        else if (C1 == 7)
        {
            col1.color = Morado;
        }
        else if (C1 == 8)
        {
            col1.color = Color.gray;
        }
        else if (C1 == 9)
        {
            col1.color = Color.white;
        }

        //----------- C2 ----------------

        if (C2 == 0)
        {
            col2.color = Color.black;
        }
        else if (C2 == 1)
        {
            col2.color = Cafe;
        }
        else if (C2 == 2)
        {
            col2.color = Color.red;
        }
        else if (C2 == 3)
        {
            col2.color = Naranja;
        }
        else if (C2 == 4)
        {
            col2.color = Color.yellow;
        }
        else if (C2 == 5)
        {
            col2.color = Color.green;
        }
        else if (C2 == 6)
        {
            col2.color = Color.blue;
        }
        else if (C2 == 7)
        {
            col2.color = Morado;
        }
        else if (C2 == 8)
        {
            col2.color = Color.gray;
        }
        else if (C2 == 9)
        {
            col2.color = Color.white;
        }

        //----------- C3 ----------------

        if (C3 == 0)
        {
            col3.color = Color.black;
        }
        else if (C3 == 1)
        {
            col3.color = Cafe;
        }
        else if (C3 == 2)
        {
            col3.color = Color.red;
        }
        else if (C3 == 3)
        {
            col3.color = Naranja;
        }
        else if (C3 == 4)
        {
            col3.color = Color.yellow;
        }
        else if (C3 == 5)
        {
            col3.color = Color.green;
        }
        else if (C3 == 6)
        {
            col3.color = Color.blue;
        }
        else if (C3 == 7)
        {
            col3.color = Morado;
        }
        else if (C3 == 8)
        {
            col3.color = Color.gray;
        }
        else if (C3 == 9)
        {
            col3.color = Color.white;
        }

        //----------- C4 ----------------

        if (C4 == 0)
        {
            col4.color = Color.black;
        }
        else if (C4 == 1)
        {
            col4.color = Cafe;
        }
        else if (C4 == 2)
        {
            col4.color = Color.red;
        }
        else if (C4 == 3)
        {
            col4.color = Naranja;
        }
        else if (C4 == 4)
        {
            col4.color = Color.yellow;
        }
        else if (C4 == 5)
        {
            col4.color = Color.green;
        }
        else if (C4 == 6)
        {
            col4.color = Color.blue;
        }
        else if (C4 == 7)
        {
            col4.color = Morado;
        }
        else if (C4 == 8)
        {
            col4.color = Color.gray;
        }
        else if (C4 == 9)
        {
            col4.color = Color.white;
        }

        #endregion

        #region Numeros

        #region N1
        if (N1 == 0)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
        }
        else if (N1 == 1)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
        }
        else if (N1 == 2)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
        }
        else if (N1 == 3)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
        }
        else if (N1 == 4)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
        }
        else if (N1 == 5)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
        }
        else if (N1 == 6)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
        }
        else if (N1 == 7)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
        }
        else if (N1 == 8)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
        }
        else if (N1 == 9)
        {
            D1.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
        }
        #endregion

        #region N2
        if (N2 == 0)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
        }
        else if (N2 == 1)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
        }
        else if (N2 == 2)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
        }
        else if (N2 == 3)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
        }
        else if (N2 == 4)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
        }
        else if (N2 == 5)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
        }
        else if (N2 == 6)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
        }
        else if (N2 == 7)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
        }
        else if (N2 == 8)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
        }
        else if (N2 == 9)
        {
            D2.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
        }
        #endregion

        #region N3
        if (N3 == 0)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
        }
        else if (N3 == 1)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
        }
        else if (N3 == 2)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
        }
        else if (N3 == 3)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
        }
        else if (N3 == 4)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
        }
        else if (N3 == 5)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
        }
        else if (N3 == 6)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
        }
        else if (N3 == 7)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
        }
        else if (N3 == 8)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
        }
        else if (N3 == 9)
        {
            D3.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
        }
        #endregion

        #region N4
        if (N4 == 0)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S0;
        }
        else if (N4 == 1)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S1;
        }
        else if (N4 == 2)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S2;
        }
        else if (N4 == 3)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S3;
        }
        else if (N4 == 4)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S4;
        }
        else if (N4 == 5)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S5;
        }
        else if (N4 == 6)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S6;
        }
        else if (N4 == 7)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S7;
        }
        else if (N4 == 8)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S8;
        }
        else if (N4 == 9)
        {
            D4.gameObject.GetComponent<SpriteRenderer>().sprite = S9;
        }
        #endregion
        #endregion

        //El panel pondrá el valor de los colores, no la combinacion
    }

    // Update is called once per frame




    void Update()
    {/* 
        N1 = Random.Range(0, 10);
        N2 = Random.Range(0, 10);
        N3 = Random.Range(0, 10);
        N4 = Random.Range(0, 10);

        C1 = Random.Range(0, 10);
        C2 = Random.Range(0, 10);
        C3 = Random.Range(0, 10);
        C4 = Random.Range(0, 10);
        */
    }
}
