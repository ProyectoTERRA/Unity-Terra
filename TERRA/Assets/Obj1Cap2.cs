using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj1Cap2 : MonoBehaviour
{
    public DialogueManager Dialog;
    public GameObject CHANGE;


    // Update is called once per frame
    void Update()
    {
        if(Dialog.Action == true)
        {
            CHANGE.SetActive(true);
        }
    }
}
