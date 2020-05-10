using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7.0f;
    public float runningSpeed = 1.5f;
    public float health = 100.0f;
    public float costoBala = 20.0f;
    Rigidbody2D m_Rigidbody;
    public Animator m_Animator;
    public LayerMask groundLayer;//detectara la capa del suelo
    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        m_Animator.SetBool("isAlive",true);
        m_Animator.SetBool("isGrounded",true);
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameManager.sharedInstance.currentGameState == GameState.inGame){ //solo debemos jugar si esta en modo inGame
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                Jump();
            }
            m_Animator.SetBool("isGrounded", IsTouchingTheGround());
       // }
    }

    void FixedUpdate()
    {
       // if(GameManager.sharedInstance.currentGameState == GameState.inGame){ //solo debemos jugar si esta en modo inGame
            if(m_Rigidbody.velocity.x < runningSpeed){
                m_Rigidbody.velocity = new Vector2(runningSpeed, m_Rigidbody.velocity.y);
            }
        // }
    }
    void Jump(){
        if(IsTouchingTheGround()){
            //F =m*a
            m_Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//fuerza vertical hacia arriba por JumpForce, las fierzas son en modo impulso
        
        }

        }


    /// method <IsTouchingTheGround> -> devolvera true si esta tocando el suelo y false si no se toca
    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.7f,groundLayer)){
            return true;
        }
        else{
            return false;
        }
    }

    public void RecibirDisparoIndian(){
        health -= costoBala;
    }
    
}
    


