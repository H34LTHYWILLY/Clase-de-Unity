using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : ObjetoInteraccionable
{
    private float interacciones = 0;
    
    public override void Interaccionar()
    {
       

        if (interacciones > 0)
        {
            return;
        }

        interacciones += 1;

        Vector3 rotacion = transform.parent.rotation.eulerAngles;

        while (interacciones == 0)
        {
            rotacion += new Vector3(0, -5, 0);

            transform.parent.rotation.SetEulerAngles(rotacion);
        }

    }
}