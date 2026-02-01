using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : ObjetoInteraccionable
{
    public override void Interaccionar()
    {
        transform.parent.rotation.SetEulerRotation(0,-90,0);
    }
}
