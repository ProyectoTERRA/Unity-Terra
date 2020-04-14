using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject canon;
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        StartCoroutine(Active());
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    IEnumerator Active()
    {
        if (PlayerCorredores.turret)
        {
            Anim.Rebind();
            Anim.enabled = true;

            Anim.Play("Fire_Turret", -1, 0f);


            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            Instantiate(Bullet, canon.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(.4f);
            Anim.enabled = false;
        }
        yield return new WaitForSeconds(2.6f);
        StartCoroutine(Active());
    }
}
