using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Puerta : ObjetoInteraccionable
{
    public override void Interaccionar()
    {
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
    }
}