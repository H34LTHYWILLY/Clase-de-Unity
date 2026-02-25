using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaObstruida : Puerta
{
    public int id = -1;
    [HideInInspector] public bool tengoLlave = false;
    protected override bool PuedoAbrirPuerta()
    {
        return tengoLlave;
    }
}