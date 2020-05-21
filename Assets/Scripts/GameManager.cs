using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{//estados del juego
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager compartirInstancia;//la propia clase se creera asi misma
    public GameState currentGameState = GameState.menu;//variable para saber en q estado del juego estamos 
    //al inicio quermos q empieze en el menu principal
    public Canvas menuCanvas, gameCanvas, gameOverCanvas;
    public int objetosColeccionados = 0;
    private void Awake() {
        compartirInstancia = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        BackToMenu();
    }

    // Update is called once per frame
    void Update()
    {

         if(Input.GetButtonDown("Start") && this.currentGameState != GameState.inGame){
            StartGame();
        }
        //if(Input.GetButtonDown("Pause")){//GetKeyDown(KeyCode.S)){
         //   BackToMenu();
        //}
        if(Input.GetKeyDown(KeyCode.Escape)){
            ExitGame();
        }
    }
    public void StartGame(){
       SetGameState(GameState.inGame);

        GameObject camara = GameObject.FindGameObjectWithTag("MainCamera");
        CameraFollow cameraFollow = camara.GetComponent<CameraFollow>();
        cameraFollow.ReiniciarPosicionCamara();

        if(PlayerController.compartirInstancia.transform.position.x > 10){//si el player se movio
            LevelGenerator.compartirInstancia.RemoverTodosBloques();
            LevelGenerator.compartirInstancia.GenerarBloquesIniciales();
        }

        PlayerController.compartirInstancia.StartGame();
        this.objetosColeccionados = 0;
    }
    public void GameOver(){
        SetGameState(GameState.gameOver);
    }
    //metodo para volver al menu principal cuando el usuario lo quiera hacer
    public void BackToMenu(){
        SetGameState(GameState.menu);
    }
    //Metodo para finalizar la ejecucion del juego
    public void ExitGame(){
        //Application.Quit();//metodo para salir, no en dispositivos moviles
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void SetGameState(GameState newGameState){
        if(newGameState == GameState.menu){
            //hay que preparar la escena de unity para mostrar el menu
            menuCanvas.enabled = true;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }else if(newGameState == GameState.inGame){
            //preparar la escena de unity para jugar
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
            Debug.Log(gameCanvas.enabled);
            gameOverCanvas.enabled = false;
        }else if(newGameState == GameState.gameOver){
            //hay que prepar la escena para el gameover
            menuCanvas.enabled = false;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
        //asiganamos el estado del juego actual al que no ha llegado por paramterpo
        this.currentGameState = newGameState;
    }

    public void ColeccionarObjeto(int valorObjeto){
        this.objetosColeccionados += valorObjeto;
        Debug.Log("Recogiste: "+this.objetosColeccionados);
    }
}
