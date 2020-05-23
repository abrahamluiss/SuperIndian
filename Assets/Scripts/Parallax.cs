using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    public float velocidad = 0f;
    private void Awake() {
        this.m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        this.m_Rigidbody.velocity = new Vector2(velocidad, 0);
        float parentPosition = this.transform.parent.transform.position.x;
        Debug.Log(parentPosition);
        if(this.transform.position.x - parentPosition >= 22.20f){//si se ha desplazado mas alla dela camara
            this.transform.position = new Vector3(parentPosition - 22.0f, this.transform.position.y, this.transform.position.z);//coordinadas correlativas
        }
    }
}
