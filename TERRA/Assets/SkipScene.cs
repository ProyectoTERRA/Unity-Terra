using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScene : MonoBehaviour
{


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) { 
                
            SceneManager.LoadScene("Lab2");
        }    
    }
}
    