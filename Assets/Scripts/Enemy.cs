using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyRunning = 1f;
    private Rigidbody2D m_Rigidbody;
    Animator m_Animator;

    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        Vector2 currentRunningSpeed = new Vector2(enemyRunning,0);
        m_Rigidbody.velocity = currentRunningSpeed;
        if(m_Animator.GetCurrentAnimatorStateInfo (0).IsName("Enemy1") && Random.value <1f/(60f*3f)){
            m_Animator.SetTrigger("apuntar");
        }else if(m_Animator.GetCurrentAnimatorStateInfo(0).IsName("aim"))
        if(Random.value <1f/3f){
            m_Animator.SetTrigger("disparar");
        }
        else{
            m_Animator.SetTrigger("caminar");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Flip();
    }
    void Flip(){
        enemyRunning *= -1;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
