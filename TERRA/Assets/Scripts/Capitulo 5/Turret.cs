using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject canon;
    private Animator Anim;

    static public bool act;
    void Start()
    {
        act = true;
        Anim = GetComponent<Animator>();
        StartCoroutine(Active());
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    IEnumerator Active()
    {
        if (PlayerCorredores.turret && !EnemigosEsferas.effecting && act)
        {
            Anim.Rebind();
            Anim.enabled = true;

            Anim.Play("Fire_Turret", -1, 0f);


            
            if (!EnemigosEsferas.effecting) Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            if (!EnemigosEsferas.effecting) Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            if (!EnemigosEsferas.effecting) Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            Anim.enabled = false;
        }
        yield return new WaitForSeconds(2.6f);
        StartCoroutine(Active());
    }
}
