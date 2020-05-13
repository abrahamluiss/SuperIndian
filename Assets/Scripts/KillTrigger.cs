using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="otraColision">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D otraColision)
    {
        if(otraColision.tag == "Player"){
            Debug.Log("El heroe ha entrado a una zona de muerte");
            //pasar a canvas GameOver
            PlayerController.compartirInstancia.Muerte();
        }
    }
}
