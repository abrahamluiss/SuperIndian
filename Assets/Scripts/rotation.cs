using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform elObjeto;
    public float velocidad;
    public int t=30;
    //float posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        elObjeto = gameObject.GetComponent<Transform>();
        //posX = elObjeto.transform.position.x;
        //posY = elObjeto.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        elObjeto.transform.rotation = Quaternion.AngleAxis(t*velocidad, Vector3.forward);
        t++;
    }
}
