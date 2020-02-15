using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LatasMar : MonoBehaviour
{
    public GameObject lata, lata1, lata2, lata3, lata4, lata5, lata6, lata7, lata8, lata9, lata10, lata11, lata12, lata13, lata14, lata15;
    public GameObject lata16, lata17, lata18, lata19, lata20, lata21, lata22, lata23, lata24, lata25, lata26, lata27, lata28, lata29;
    public GameObject mensaje4;
    int x = 0;
    void Start()
    {

    }

    void Update()
    {
        if (x == 0) { StartCoroutine(aparecen1()); }
        if (x == 1) { StartCoroutine(aparecen2()); }
        if (x == 2) { StartCoroutine(aparecen3()); }
        if (x == 3) { StartCoroutine(aparecen4()); }
        if (x == 4) { StartCoroutine(aparecen5()); }
        if (x == 5) { StartCoroutine(aparecen6()); }
        if (x == 6) { StartCoroutine(aparecen7()); }
        if (x == 7) { StartCoroutine(aparecen8()); }
        if (x == 8) { StartCoroutine(aparecen9()); }
        if (x == 9) { StartCoroutine(aparecen10()); }
        if (x == 10) { StartCoroutine(aparecen11()); }
        if (x == 11) { StartCoroutine(aparecen12()); }
        if (x == 12) { StartCoroutine(aparecen13()); }
        if (x == 13) { StartCoroutine(aparecen14()); }
        if (x == 14) { StartCoroutine(aparecen15()); }
        if (x == 15) { StartCoroutine(aparecen16()); }
        if (x == 16) { StartCoroutine(aparecen17()); }
        if (x == 17) { StartCoroutine(aparecen18()); }
        if (x == 18) { StartCoroutine(aparecen19()); }
        if (x == 19) { StartCoroutine(aparecen20()); }
        if (x == 20) { StartCoroutine(aparecen21()); }
        if (x == 21) { StartCoroutine(aparecen22()); }
        if (x == 22) { StartCoroutine(aparecen23()); }
        if (x == 23) { StartCoroutine(aparecen24()); }
        if (x == 24) { StartCoroutine(aparecen25()); }
        if (x == 25) { StartCoroutine(aparecen26()); }
        if (x == 26) { StartCoroutine(aparecen27()); }
        if (x == 27) { StartCoroutine(aparecen28()); }
        if (x == 28) { StartCoroutine(aparecen29()); }
        if (x == 29) { StartCoroutine(aparecen30()); }
        if (x == 30) { StartCoroutine(aparecen31()); }
        if (x == 31) { StartCoroutine(aparecen32()); }
    }

    IEnumerator aparecen1()
    {
        yield return new WaitForSeconds(3);
        if (lata != null)
        {
            lata.SetActive(true);
        }
        x = 1;
    }
    IEnumerator aparecen2()
    {
        yield return new WaitForSeconds(3);
        if (lata1 != null)
        {
            lata1.SetActive(true);
        }
        x = 2;
    }
    IEnumerator aparecen3()
    {
        yield return new WaitForSeconds(3);
        if (lata2 != null)
        {
            lata2.SetActive(true);
        }
        x = 3;
    }
    IEnumerator aparecen4()
    {
        yield return new WaitForSeconds(4);
        if (lata3 != null)
        {
            lata3.SetActive(true);
        }
        x = 4;
    }
    IEnumerator aparecen5()
    {
        yield return new WaitForSeconds(3);
        if (lata4 != null)
        {
            lata4.SetActive(true);
        }
        x = 5;
    }
    IEnumerator aparecen6()
    {
        yield return new WaitForSeconds(4);
        if (lata5 != null)
        {
            lata5.SetActive(true);
        }
        x = 6;
    }
    IEnumerator aparecen7()
    {
        yield return new WaitForSeconds(3);
        if (lata6 != null)
        {
            lata6.SetActive(true);
        }
        x = 7;
    }
    IEnumerator aparecen8()
    {
        yield return new WaitForSeconds(3);
        if (lata7 != null)
        {
            lata7.SetActive(true);
        }
        x = 8;
    }
    IEnumerator aparecen9()
    {
        yield return new WaitForSeconds(4);
        if (lata8 != null)
        {
            lata8.SetActive(true);
        }
        x = 9;
    }
    IEnumerator aparecen10()
    {
        yield return new WaitForSeconds(4);
        if (lata9 != null)
        {
            lata9.SetActive(true);
        }
        x = 10;
    }
    IEnumerator aparecen11()
    {
        yield return new WaitForSeconds(4);
        if (lata10 != null)
        {
            lata10.SetActive(true);
        }
        x = 11;
    }
    IEnumerator aparecen12()
    {
        yield return new WaitForSeconds(4);
        if (lata11 != null)
        {
            lata11.SetActive(true);
        }
        x = 12;
    }
    IEnumerator aparecen13()
    {
        yield return new WaitForSeconds(4);
        if (lata12 != null)
        {
            lata12.SetActive(true);
        }
        x = 13;
    }
    IEnumerator aparecen14()
    {
        yield return new WaitForSeconds(4);
        if (lata13 != null)
        {
            lata13.SetActive(true);
        }
        x = 14;
    }
    IEnumerator aparecen15()
    {
        yield return new WaitForSeconds(4);
        if (lata14 != null)
        {
            lata14.SetActive(true);
        }
        x = 15;
    }
    IEnumerator aparecen16()
    {
        yield return new WaitForSeconds(4);
        if (lata15 != null)
        {
            lata15.SetActive(true);
        }
        x = 16;
    }
    IEnumerator aparecen17()
    {
        yield return new WaitForSeconds(3);
        if (lata16 != null)
        {
            lata16.SetActive(true);
        }
        x = 17;
    }

    IEnumerator aparecen18()
    {
        yield return new WaitForSeconds(3);
        if (lata17 != null)
        {
            lata17.SetActive(true);
        }
        x = 18;
    }
    IEnumerator aparecen19()
    {
        yield return new WaitForSeconds(4);
        if (lata18 != null)
        {
            lata18.SetActive(true);
        }
        x = 19;
    }
    IEnumerator aparecen20()
    {
        yield return new WaitForSeconds(4);
        if (lata19 != null)
        {
            lata19.SetActive(true);
        }
        x = 20;
    }
    IEnumerator aparecen21()
    {
        yield return new WaitForSeconds(4);
        if (lata20 != null)
        {
            lata20.SetActive(true);
        }
        x = 21;
    }
    IEnumerator aparecen22()
    {
        yield return new WaitForSeconds(4);
        if (lata21 != null)
        {
            lata21.SetActive(true);
        }
        x = 22;
    }
    IEnumerator aparecen23()
    {
        yield return new WaitForSeconds(3);
        if (lata22 != null)
        {
            lata22.SetActive(true);
        }
        x = 23;
    }
    IEnumerator aparecen24()
    {
        yield return new WaitForSeconds(3);
        if (lata23 != null)
        {
            lata23.SetActive(true);
        }
        x = 24;
    }
    IEnumerator aparecen25()
    {
        yield return new WaitForSeconds(4);
        if (lata24 != null)
        {
            lata24.SetActive(true);
        }
        x = 25;
    }
    IEnumerator aparecen26()
    {
        yield return new WaitForSeconds(4);
        if (lata25 != null)
        {
            lata25.SetActive(true);
        }
        x = 26;
    }
    IEnumerator aparecen27()
    {
        yield return new WaitForSeconds(3);
        if (lata26 != null)
        {
            lata26.SetActive(true);
        }
        x = 27;
    }
    IEnumerator aparecen28()
    {
        yield return new WaitForSeconds(3);
        if (lata27 != null)
        {
            lata27.SetActive(true);
        }
        x = 28;
    }
    IEnumerator aparecen29()
    {
        yield return new WaitForSeconds(3);
        if (lata28 != null)
        {
            lata28.SetActive(true);
        }
        x = 29;
    }
    IEnumerator aparecen30()
    {
        yield return new WaitForSeconds(3);
        if (lata29 != null)
        {
            lata29.SetActive(true);
        }
        x = 30;
    }
    IEnumerator aparecen31()
    {
        yield return new WaitForSeconds(15);
        //SceneManager.LoadScene("Mar");
        mensaje4.SetActive(true);
        x = 31;
    }
    IEnumerator aparecen32()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Mar");
        x = 32;
    }
}

