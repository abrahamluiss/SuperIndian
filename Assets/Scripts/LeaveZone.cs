using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveZone : MonoBehaviour
{
    //Al tener 1 personaje y tener 2 collider el bloque de zona de exit colisiona 2 veces
    float tiempoDesdeLaUltimaDestruccion = 0.0f;
    private void OnTriggerEnter2D(Collider2D otraColision) {
        if(tiempoDesdeLaUltimaDestruccion > 3.0f){
            LevelGenerator.compartirInstancia.AgregarLevelBloque();
            LevelGenerator.compartirInstancia.RemoverLevelBloqueMasViejo();
            //Debug.Log("Zona exit");
            tiempoDesdeLaUltimaDestruccion = 0.0f;
        }

    }

    void Update()
    {
        tiempoDesdeLaUltimaDestruccion += Time.deltaTime;
    }
}
