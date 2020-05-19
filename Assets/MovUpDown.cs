using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovUpDown : MonoBehaviour
{
    public Transform objetoActual;
    public int vel;
    public int distancia;
    float posX, posY;
    void Start()
    {
        objetoActual = gameObject.GetComponent<Transform>();
        posX = objetoActual.transform.position.x;
        posY = objetoActual.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        objetoActual.transform.position = new Vector2(posX, posY+(Mathf.PingPong(Time.time*vel,distancia)));
    }
}
