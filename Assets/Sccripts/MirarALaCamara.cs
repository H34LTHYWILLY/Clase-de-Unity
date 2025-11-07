using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarALaCamara : MonoBehaviour
{
    public Transform camara;
    
    void Update()
    {

        transform.LookAt(camara, Vector3.up);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
