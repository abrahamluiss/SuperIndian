using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    Collider2D shootTo = null;
    public float probabilityShoot = 0.5f;
    //public GameObject bulletPrototype;
    Enemy ctr;

    void start()
    {
        ctr = GameObject.Find("enemy").GetComponent<Enemy>();
    }
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
//            Debug.Log("Choque");
        }
    }
    void Shoot(){
        ctr.Disparar();
    }
}
