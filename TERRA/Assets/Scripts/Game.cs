using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Game : MonoBehaviour
{
    public static Game current;
    public Character basura;
    public string nombrePartida;
    public Game()
    {
        nombrePartida = "";
        basura = new Character();
    }
}
