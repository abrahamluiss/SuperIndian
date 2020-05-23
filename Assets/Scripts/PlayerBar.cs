using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarTipo{
    vida,
    mana
}
public class PlayerBar : MonoBehaviour
{
    private Slider slider;
    public BarTipo tipo;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(tipo){
            case BarTipo.vida:
                slider.value = PlayerController.compartirInstancia.GetVida();
                break;
            case BarTipo.mana:
                slider.value = PlayerController.compartirInstancia.GetMana();
                break;
        }
    }
}
