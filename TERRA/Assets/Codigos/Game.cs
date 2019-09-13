using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Game 
{
    public static Game current;
    public Character basura;
    public string name;
    public Game()
    {
        name = "";
        basura = new Character();
    }
}
