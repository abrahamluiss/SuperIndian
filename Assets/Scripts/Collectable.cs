using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool esRecogida = false;
    public int valorMoneda =0;
    public AudioClip sonidoColeccionable;
    void Mostrar(){//activa la moneda y su collider
        this.GetComponent<SpriteRenderer>().enabled = true;//activación el sprite y la animación
        this.GetComponent<CircleCollider2D>().enabled = true;//activacion del srpite para ser recogida
        esRecogida = false;//no hemos cogido la moneda actual
    }

    void Ocultar(){//desactiva la moneda y su collider
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
    
    void Recoger(){//recolectar la moneda
        esRecogida = true;
        Ocultar();
        GameManager.compartirInstancia.ColeccionarObjeto(valorMoneda);
        AudioSource audio = GetComponent<AudioSource>();
        if(audio != null && this.sonidoColeccionable != null){
            audio.PlayOneShot(this.sonidoColeccionable);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherollider) {
        if(otherollider.tag == "Player"){
            Recoger();
            Debug.Log("Moneda Recogida");
        }
    }
}
