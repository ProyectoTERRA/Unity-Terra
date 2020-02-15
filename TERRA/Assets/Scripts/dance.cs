using System.Collections;
using UnityEngine;

public class dance : MonoBehaviour
{
    public AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;
    private SpriteRenderer spr;
    private void Start()
    {
        gameObject.AddComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
    }
    public void OnMouseDown()
    {
        if (gameObject.name == "a")
        {
            oracion.frase += "a";
            oracion.contador++;
            spr.color = Color.red;
            StartCoroutine(test());
            playSoundA();
        }
        if (gameObject.name == "b")
        {
            oracion.frase += "b";
            oracion.contador++;
            spr.color = Color.green;
            StartCoroutine(test());
            playSoundA();
        }
        if (gameObject.name == "c")
        {
            oracion.frase += "c";
            oracion.contador++;
            spr.color = Color.yellow;
            StartCoroutine(test());
            playSoundA();
        }
        if (gameObject.name == "d")
        {
            oracion.frase += "d";
            oracion.contador++;
            spr.color = Color.blue;
            StartCoroutine(test());
            playSoundA();
        }
        if (gameObject.name == "e")
        {
            oracion.frase += "e";
            oracion.contador++;
            spr.color = Color.cyan;
            StartCoroutine(test());
            playSoundA();
        }
        if (gameObject.name == "f")
        {
            oracion.frase += "f";
            oracion.contador++;
            spr.color = Color.grey;
            StartCoroutine(test());
            playSoundA();
        }
        if (gameObject.name == "g")
        {
            oracion.frase += "g";
            oracion.contador++;
            spr.color = Color.magenta;
            StartCoroutine(test());
            playSoundA();
        }
    }
    void playSoundA()
    {
        source.PlayOneShot(clip);
    }
    public IEnumerator test()
    {
        yield return new WaitForSeconds(1);
        spr.color = Color.white;
    }

}
