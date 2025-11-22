using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoTemporal : MonoBehaviour, IBaseReact
{
    public void DejarDeInteraccionar()
    {
   
    }

    public void Interaccionar()
    {
        Destroy(gameObject);
    }
}
