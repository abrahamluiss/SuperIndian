using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 6.0f;
    public float lifeTime = 2.0f;
    public Vector3 direction = new Vector3(-1,0,0);
    Vector3 stepVector;
    Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        m_Rigidbody = GetComponent<Rigidbody2D>();
        stepVector = speed * direction.normalized;
        Debug.Log("Sali bala");
    }

    private void FixedUpdate() {
        m_Rigidbody.velocity = stepVector;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Equals("tree")){
            TreeController ctr = other.gameObject.GetComponent<TreeController>();
            if(ctr != null) ctr.RecibirDisparo();
            Destroy(gameObject);
        }
    }
}
