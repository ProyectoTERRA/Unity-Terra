using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextEscene : MonoBehaviour
{
    public string nombreEscena;

    public void Update()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
