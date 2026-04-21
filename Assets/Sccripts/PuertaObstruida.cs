using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaObstruida : Puerta
{
    public int id = -1;
    
    protected override bool PuedoAbrirPuerta()
    {
        return Llave.idList.Contains(id);
    }
}