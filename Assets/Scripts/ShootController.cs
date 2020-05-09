using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    Collider2D shootTo = null;
    public float probabilityShoot = 1.0f;
    public GameObject bulletPrototype;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Equals("tree") && shootTo == null){
            DecidaSiDispara(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other == shootTo){
            shootTo = null;
        }
    }
    void DecidaSiDispara(Collider2D other){
        if(Random.value < probabilityShoot){
            Shoot();
            shootTo = other;
            Debug.Log("Choque");
        }
    }
    void Shoot(){
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = new Vector3(transform.parent.position.x,transform.parent.position.y, -1.0f);
        bulletCopy.GetComponent<BulletController>().direction = new Vector3(transform.parent.localScale.x,0,0);
        Debug.Log("saliendo");
    }
}
