using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D otraColision)
    {
        if(otraColision.tag == "Player"){
            Debug.Log("El heroe ha entrado a una zona de muerte");
            //pasar a canvas GameOver
            PlayerController.compartirInstancia.Muerte();
        }
    }
}
