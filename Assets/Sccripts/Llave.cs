using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteAlways]
public partial class Llave : ObjetoInteraccionable
{
    public int id = -1;

    public override void Interaccionar()
    {
        if (id == -1)
        {
            Debug.LogError("Invalid Key ID.");
            return;
        }

        Destroy(gameObject);

        PuertaObstruida[] todasLasPuertas = Object.FindObjectsOfType<PuertaObstruida>();

        //                                  ( ALGO QUE EVALUE A BOOL )
        // for( DECLARAMOS UNA VARIABLE ; CONDICION PARA REPETIR EL LOOP ; ACCION AL ACABAR EL LOOP )
        for (int x = 0; x < todasLasPuertas.Length; x++)
        {
            PuertaObstruida puerta = todasLasPuertas[x];
            if (puerta.id == id)
            {
                puerta.tengoLlave = true;
            }
        }
    }

#if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        PuertaObstruida[] todasLasPuertas = Object.FindObjectsOfType<PuertaObstruida>();

        //                                  ( ALGO QUE EVALUE A BOOL )
        // for( DECLARAMOS UNA VARIABLE ; CONDICION PARA REPETIR EL LOOP ; ACCION AL ACABAR EL LOOP )
        for (int x = 0; x < todasLasPuertas.Length; x++)
        {
            PuertaObstruida puerta = todasLasPuertas[x];
            if (puerta.id == id)
            {
                Debug.DrawLine(puerta.transform.position, transform.position, Color.green);
            }
        }
    }
#endif
}


// public partial class Llave : ObjetoInteraccionable
// {
//     
// }
