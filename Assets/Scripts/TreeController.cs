using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public int numGolpesParaCaer = 3;
    public int numBalasParaCaer = 3;

    Animator m_Animator;
    SpriteRenderer m_Renderer;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Renderer = GetComponent<SpriteRenderer>();
    }
    public bool RecibirDisparo(){
        bool resp = false;
        numBalasParaCaer--;
        switch(numBalasParaCaer){
            case 2: 
                m_Renderer.color = new Color(1f/242,1f/155,1f/155.1f);
                Debug.Log("cambio color 1");
                break;
            case 1:
                m_Renderer.color = new Color(1f/216,1f/10,1f/10);
                Debug.Log("cambio color 2");
                break;
        }
        if(numBalasParaCaer <= 0){
            m_Animator.SetTrigger("fall");
            resp = true;
        }
        return resp;
    }
}
