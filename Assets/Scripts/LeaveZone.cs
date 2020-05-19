using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otraColision) {
        LevelGenerator.compartirInstancia.AgregarLevelBloque();
        LevelGenerator.compartirInstancia.RemoverLevelBloqueMasViejo();
        Debug.Log("Zona exit");
    }
}
