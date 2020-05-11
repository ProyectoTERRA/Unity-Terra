using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objetivos
{
    public bool isActive;
    public string NombreMision;
    [TextArea(3, 100)]
    public string Descripcion;

    public ObjetivosGoal goal;


}
