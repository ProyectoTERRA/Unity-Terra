using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comportamiento : MonoBehaviour
{
    public bool Terrestre = true;
    public GameObject[] HitosPatronMovimiento;
    public float[] VelocidadesPatronMovimiento;
    public GameObject sedante;

    public float scale;
    public static float scal;
    public int SIDE;
    public static int side;
    public float x;
    public float y;
    public float z;
    // Private variables
    private Transform thisTransform;
    private Rigidbody2D thisRigidbody;
    private int HitoSiguiente = 0;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        thisRigidbody = GetComponentInParent<Rigidbody2D>();
        CanGoToNextMilestone = true;
    }

    // Update is called once per frame
    void Update()
    {
        var pl = GameObject.Find("JefeMisterioso");

        if(Input.GetKeyDown(KeyCode.L))
        {
            if (pl != null)
            {
                Instantiate(sedante, pl.transform.position, Quaternion.identity);
            }

        }
        /*
        // Activamos o desactivamos la gravedad en función de la variable 'Terrestre'
        thisRigidbody.useAutoMass = Terrestre;

        // Calculamos la velocidad hacia el siguiente hito (si no hubiese velocidad definida para
        // alguno de los hitos, asumiremos que es 0 y por tanto el objeto quedará parado)
        float VelocidadHaciaHito = 0;
        try
        {
            VelocidadHaciaHito = VelocidadesPatronMovimiento[HitoSiguiente];
        }
        catch
        {
            VelocidadHaciaHito = 0;
        }

        // Comprobamos si podemos ir hacia el siguiente hito
        if (CanGoToNextMilestone)
        {
            try
            {
                // Movemos al objeto hacia el siguiente hito
                if (IrHaciaHito(HitosPatronMovimiento[HitoSiguiente].transform.position, VelocidadHaciaHito))
                {
                    // Justo cuando lleguemos a un hito, paramos al objeto
                    CanGoToNextMilestone = false;

                    // Activamos el/los script/s de comportamiento correspondiente/s al hito actual (los que
                    // su nombre empiecen contengan la palabra 'Patron').
                    // Explicaremos estos scripts más adelante.
                    bool patronFound = false;
                    MonoBehaviour[] milestoneScripts = HitosPatronMovimiento[HitoSiguiente].GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour script in milestoneScripts)
                    {
                        if (script.GetType().Name.Contains("Patron"))
                        {
                            patronFound = true;
                            script.enabled = true;
                        }
                    }

                    // Si no encontramos ningún script de comportamiento en el hito, continuamos al siguiente
                    if (!patronFound)
                    {
                        CanGoToNextMilestone = true;
                    }

                    // Calculamos cual será el próximom hito
                    if (HitoSiguiente != HitosPatronMovimiento.Length - 1)
                    {
                        HitoSiguiente++;
                    }
                    else
                    {
                        HitoSiguiente = 0;
                    }
                }
            }
            catch
            {
                HitoSiguiente++;
            }
        }*/
    }

    private bool IrHaciaHito(Vector3 PosicionHito, float Velocidad)
    {
        // Calculamos la distancia entre el hito y el objeto
        Vector3 VectorHaciaObjetivo = PosicionHito - thisTransform.position;
        if (Terrestre)
        {
            // Si estamos en modo 'Terrestre', calculamos la distancia ignorando el eje Y
            VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);
        }

        // Con esta condición comprobamos si el objeto aún no ha llegado a las coordenadas del hito
        if (Math.Abs(VectorHaciaObjetivo.x) > 0.2F ||
            Math.Abs(VectorHaciaObjetivo.y) > 0.2F ||
            Math.Abs(VectorHaciaObjetivo.z) > 0.2F)
        {
            // Calculamos el vector de movimiento hacia el hito
            VectorHaciaObjetivo.Normalize();
            VectorHaciaObjetivo *= Velocidad;
            VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x,
                                              VectorHaciaObjetivo.y,
                                              VectorHaciaObjetivo.z);

            // Movemos el objeto hacia el hito
            thisTransform.Translate(VectorHaciaObjetivo * Time.deltaTime, Space.World);

            // El objeto aún no ha llegado al hito
            return false;
        }
        else
        {
            // El objeto ha llegado al hito
            Debug.Log("Ha llegado al hito");
            return true;
        }
    }
    public bool CanGoToNextMilestone { get; set; }

}
