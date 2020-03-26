using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Minijuego_2 : MonoBehaviour
{
    [SerializeField] private GameObject bTN;
    // Start is called before the first frame update
    bool touch;
    void Start()
    {
        touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(touch);
    }
    public void OnMouseOver()
    {
        touch = true;
    }
    void OnMouseExit()
    {
        touch = false;
    }
}
