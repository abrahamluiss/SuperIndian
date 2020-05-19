using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator compartirInstancia;
    public List<LevelBlock> todosLosLevelBlock = new List<LevelBlock>();//los lvls en el prefap
    public Transform puntoInicioLevel;//saber donde se generara
    public List<LevelBlock> actualBloques = new List<LevelBlock>();//los que hay actualmente en la escena

    void Awake()
    {
        compartirInstancia = this;
    }
 
    void Start()
    {
        GenerarBloquesIniciales();

    }
  /// <param name="actualBloque">bloque que se genero</param>

    public void AgregarLevelBloque(){
        int pocisionAleatoria = Random.Range(0,todosLosLevelBlock.Count);
        LevelBlock actualBloque = (LevelBlock)Instantiate(todosLosLevelBlock[pocisionAleatoria]);
        actualBloque.transform.SetParent(this.transform, false);//añade como hijo de la jerarquia
        Vector3 aparecerEnPocision = Vector3.zero;
        if(actualBloques.Count ==0){
            aparecerEnPocision = puntoInicioLevel.position;
        }else{
            aparecerEnPocision = actualBloques[actualBloques.Count-1].puntoSalida.position;
        }

        Vector3 correccion = new Vector3(aparecerEnPocision.x - actualBloque.puntoEntrada.position.x, 
                                        aparecerEnPocision.y-actualBloque.puntoEntrada.position.y,0);

        actualBloque.transform.position = correccion;//nueva pocision q se colocara 
        actualBloques.Add(actualBloque);
    }
    public void RemoverLevelBloqueMasViejo(){
        //Debug.Log("Se destruira un bloque");
        LevelBlock bloqueMasViejo = actualBloques[0];
        actualBloques.Remove(bloqueMasViejo);
        Destroy(bloqueMasViejo.gameObject);//pulling de un objeto -> otra tecnica
    }
    public void RemoverTodosBloques(){
        while(actualBloques.Count>0){
            RemoverLevelBloqueMasViejo();
        }
    }
    public void GenerarBloquesIniciales(){
        for(int i = 0; i < 2; i++){
            AgregarLevelBloque();
        }
    }

}
