﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public string Cambio;
    public int LobCAP;

    private void Update()
    {
        GameController.LobbyCAP = LobCAP;
    }
    public void CargarJuego(string Cambio)
    {
        SceneManager.LoadScene(Cambio);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CargarJuego(Cambio);
        }
    }
}
