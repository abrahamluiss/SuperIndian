using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform objetivo;
    public Vector3 seguirDeLejos = new Vector3(0.1f,0.0f,-10f);//dejar una pequeña distancia
    public float dampTime = 0.3f;//pequeño inicio y despues seguira
    public Vector3 velocidad = Vector3.zero;

   void Awake()
   {
       //la actualización de frame sea contante
        Application.targetFrameRate = 60;//targetFrameRate intenta renderizar al numero de frame q le indique


   }
    public void ReiniciarPosicionCamara(){//la camara saltara directamente, solo cuando se reinicia
        Vector3 punto = GetComponent<Camera>().WorldToViewportPoint(objetivo.position);
        //Debug.Log(punto);
        //donde quiero ir menos donde esta ahora
        Vector3 delta = objetivo.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(seguirDeLejos.x, seguirDeLejos.y, punto.z));//cuanto tiene q moverse la camara para q el personaje siga en el centro
        Vector3 destino = punto + delta;
        destino = new Vector3(objetivo.position.x, seguirDeLejos.y, seguirDeLejos.z);//correción para q la camara no salte con el personaje
        this.transform.position = destino;
    }
    // Update is called once per frame
    void Update()
    {
        //WorldToViewportPoint 2 sistemas de coordenadas diferente se uniran
        Vector3 punto = GetComponent<Camera>().WorldToViewportPoint(objetivo.position);
        //Debug.Log(punto);
        //donde quiero ir menos donde esta ahora
        Vector3 delta = objetivo.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(seguirDeLejos.x, seguirDeLejos.y, punto.z));//cuanto tiene q moverse la camara para q el personaje siga en el centro
        Vector3 destino = punto + delta;
        destino = new Vector3(objetivo.position.x, objetivo.position.y+2.3f, seguirDeLejos.z);//correción para q la camara no salte con el personaje
        this.transform.position = Vector3.SmoothDamp(this.transform.position, destino, ref velocidad, dampTime);
    }
}
