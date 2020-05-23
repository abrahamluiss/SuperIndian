using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public Text ColeccionableLabel;
    public Text scoreLabel;
    public Text maxScoreLabel;


    // Update is called once per frame
    void Update()
    {
        if(GameManager.compartirInstancia.currentGameState == GameState.inGame || GameManager.compartirInstancia.currentGameState==GameState.gameOver){
            int objetosActuales = GameManager.compartirInstancia.objetosColeccionados;
            this.ColeccionableLabel.text = objetosActuales.ToString();
        }
        if(GameManager.compartirInstancia.currentGameState == GameState.inGame){
            float distanciaRecorrida = PlayerController.compartirInstancia.GetDistance();
            this.scoreLabel.text = "Score\n" + distanciaRecorrida.ToString("f0");
        }
    }
}
