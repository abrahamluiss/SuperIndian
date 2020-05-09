using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDanioEnemy : MonoBehaviour
{
    Collider2D colliderEnemy = null;
    public int delayBajarPuntosEnergy = 1;
     
    void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.name.Equals("Enemy") && colliderEnemy == null){
            Debug.Log("colision con el enemigo");
            colliderEnemy = other;
            Invoke("BajarPuntosEnemigo",delayBajarPuntosEnergy);
         }
     }
    void OnTriggerExit2D(Collider2D other) {
        if(other == colliderEnemy){
            Debug.Log("Salir de colisión con el enmigo");
            colliderEnemy = null;
            CancelInvoke("BajarPuntosEnemigo");
        }
    }
    void BajarPuntosEnemigo(){
        Debug.Log("BajarPuntosEnemigo");
//        colliderEnemy.gameObject.GetComponent<Enemy>().BajarPuntosPorOrcoCerca();
    }

}
