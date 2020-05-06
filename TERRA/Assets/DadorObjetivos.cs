using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DadorObjetivos : MonoBehaviour
{
    public Objetivos objetivo;
    public PlayerController Jugador;
    public GameObject MenuObj;
    public Animator animador;
    public bool MenuAbierto = false;
    public Text NombreTxt;
    public Text descripcionTxt;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && MenuAbierto == false)
        {
            animador.SetTrigger("Abrir");
            MenuAbierto = true;
            MenuObj.SetActive(true);
            animador.SetTrigger("Stay");
            Debug.Log("Menu abierto");
            NombreTxt.text = objetivo.NombreMision;
            descripcionTxt.text = objetivo.Descripcion;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && MenuAbierto == true)
        {
            animador.SetTrigger("Cerrar");
            MenuAbierto = false;
            animador.SetTrigger("StayClose");
            Debug.Log("menu cerrado");
          
        }
    }



}
