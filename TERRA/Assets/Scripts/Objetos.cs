using UnityEngine;

public class Objetos : MonoBehaviour
{
    private bool agarrar;
    private string nombre, tag;
    public void Start()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        radial.basura[0] = GameController.pila;
        radial.basura[1] = GameController.bolsa;
        radial.basura[2] = GameController.carton;
        radial.basura[3] = GameController.manzana;
        radial.basura[4] = GameController.platano;
        radial.basura[5] = GameController.lata;

        radial.esfera[0] = GameController.normal;
        radial.esfera[1] = GameController.paralizante;
        radial.esfera[2] = GameController.desactivadora;
        radial.esfera[3] = GameController.tranquilizante;
        radial.esfera[4] = GameController.pesada;


        radial.especiales[0] = GameController.energia;
        radial.especiales[1] = GameController.curacion;
        radial.especiales[2] = GameController.ganzua;


    }
    void Update()
    {
        if (agarrar)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            if (tag == "lata")
            {
                
                GameController.lata++;
                radial.basura[5]++;
                Destroy(GameObject.Find(nombre));
                
            }
            else if(tag == "platano" )
            {
                GameController.platano++;
                radial.basura[4]++;
                Destroy(GameObject.Find(nombre));
            }
            else if (tag == "manzana")
            {
                GameController.manzana++;
                radial.basura[3]++;
                Destroy(GameObject.Find(nombre));
            }
            else if (tag == "carton" )
            {
                GameController.carton++;
                radial.basura[2]++;
                Destroy(GameObject.Find(nombre));
            }
            else if (tag == "bolsa" )
            {
                GameController.bolsa++;
                radial.basura[1]++;
                Destroy(GameObject.Find(nombre));
            }
            else if (tag == "pila")
            {
                GameController.pila++;
                radial.basura[0]++;
                Destroy(GameObject.Find(nombre));
            }
            else if (tag == "LataRECHARGED")
            {
                radial.latas_recharge++;
                Destroy(GameObject.Find(nombre));
            }
            agarrar = false;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        if (other.gameObject.tag == "pila" && PlayerController.Equip == "Recogedor")
        {

            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;
        }

        if (other.gameObject.tag == "bolsa" && PlayerController.Equip == "Recogedor")
        {

            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;

        }

        if (other.gameObject.tag == "carton" && PlayerController.Equip == "Recogedor")
        {
            
            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;
        }

        if (other.gameObject.tag == "manzana" && PlayerController.Equip == "Recogedor")
        {
            
            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;
        }

        if (other.gameObject.tag == "platano" && PlayerController.Equip == "Recogedor")
        {
            
            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;
        }

        if (other.gameObject.tag == "lata" && PlayerController.Equip == "Recogedor")
        {
            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;
        }

        if (other.gameObject.tag == "LataRECHARGED" && PlayerController.Equip == "Recogedor")
        {
            tag = other.gameObject.tag;
            nombre = other.gameObject.name;
            agarrar = true;
        }
    }

}

